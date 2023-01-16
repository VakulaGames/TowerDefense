using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

[RequireComponent(typeof(NavMeshAgent), typeof(Health))]
public abstract class Enemy : MonoBehaviour, IDamageble
{
    [SerializeField] private int _reward;
    [SerializeField] private Transform _shootTarget;
    [SerializeField] private Animator _animator;
    [SerializeField] private Collider _collider;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Renderer _renderer;
    
    public int Reward => _reward;
    public Transform ShootTarget => _shootTarget;

    protected Health _health;

    private NavMeshAgent _agent;
    private Sequence _sequence;

    private void OnDisable()
    {
        if (_sequence != null) _sequence.Kill();
    }

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _health = GetComponent<Health>();
    }

    public virtual void Init(Vector3 target, int waveCount)
    {
        _agent.SetDestination(target);
    }

    public virtual void Attack(float damage)
    {
        _health.TakeDamage(damage);
    }

    public void StarttEating()
    {
        _agent.enabled = false;
        _animator.SetTrigger("Eat");
    }

    public virtual void Dead()
    {
        _agent.enabled = false;
        _animator.SetTrigger("Dead");
        _collider.enabled = false;
        _rigidbody.isKinematic = true;

        Events.OnEnemyDeadEvent.Invoke(this);

        Disappearance();
    }

    private void Disappearance()
    {
        _sequence = DOTween.Sequence();

        Color targetColor = new Color(0, 0, 0, 0);

        _sequence.Append(_renderer.materials[0].DOColor(targetColor, 2f));
        _sequence.AppendCallback(() => { Destroy(this.gameObject); });
    }
}
