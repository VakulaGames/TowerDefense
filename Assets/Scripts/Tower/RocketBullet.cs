using UnityEngine;
using DG.Tweening;

public class RocketBullet : Bullet
{
    [SerializeField] private AnimationCurve _pathCurve;
    [SerializeField] private AnimationCurve _rotateCurve;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private AudioSource _source;
    [SerializeField] private float _damageRadius;
    [SerializeField] private GameObject _mesh;

    private Sequence _sequence;

    public override void Shoot(Vector3 target, float damage)
    {
        base.Shoot(target, damage);
        BulletFly(target, damage);
    }

    private void BulletFly(Vector3 target, float damage)
    {
        Vector3 firstPoint = transform.position + (transform.forward * 4) + Vector3.down;
        Vector3 direction = target - firstPoint;
        
        Vector3[] path = new Vector3[]
                {
            firstPoint,
            transform.position + transform.forward,
            transform.position + (transform.forward * 3),
            target,
            target + (Vector3.up/3),
            target + (Vector3.up/5)
                };

        _sequence = DOTween.Sequence();
        _sequence.Append(transform.DOPath(path, _speed, PathType.CubicBezier).SetEase(_pathCurve));
        _sequence.Join(transform.DORotateQuaternion(Quaternion.LookRotation(direction), _speed).SetEase(_rotateCurve));
        _sequence.AppendCallback(() =>
        {
            Explosion(target, damage);
        });
    }

    private void Explosion(Vector3 target, float damage)
    {
        Collider[] hits = Physics.OverlapSphere(target, _damageRadius);
        foreach (Collider hit in hits)
        {
            if (hit.transform.TryGetComponent<Enemy>(out Enemy enemy))
            {
                Vector3 direction = hit.transform.position - transform.position;

                enemy.Attack(damage, direction);
            }
        }

        _particleSystem.Play();
        _source.Play();
        _mesh.SetActive(false);
        Destroy(gameObject, 1);
    }
}
