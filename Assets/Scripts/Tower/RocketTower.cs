using UnityEngine;

public class RocketTower : Tower
{
    [SerializeField] private Bullet _bulletPrefab;

    protected override void Shoot()
    {
        if (_towerAiming.EnemyTarget != null)
        {
            base.Shoot();

            Bullet bullet = Instantiate(_bulletPrefab, _bulletSpawnPoint.position, _bulletSpawnPoint.rotation);
            bullet.Shoot(_towerAiming.EnemyTarget.transform.position, _damage);
        }
    }

    protected override bool IsAimed(Vector3 targetPosition)
    {
        if (Vector3.SignedAngle(_bulletSpawnPoint.forward,
                   targetPosition - _bulletSpawnPoint.position,Vector3.up) < 30)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
