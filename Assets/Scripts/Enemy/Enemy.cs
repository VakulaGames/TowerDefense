using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Health))]
public abstract class Enemy : MonoBehaviour, IDamageble
{
    [SerializeField] private int _reward;
    [SerializeField] private Transform _shootTarget;

    public int Reward => _reward;
    public Transform ShootTarget => _shootTarget;

    protected Health _health;

    private NavMeshAgent _agent;

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

    public virtual void Dead()
    {
        _agent.speed = 0;
        Events.OnEnemyDeadEvent.Invoke(this);
        Destroy(this.gameObject,2f);
    }

}
