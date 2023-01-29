using UnityEngine;

public class RocketTower : Tower
{
    protected override void Shoot()
    {
        if (_towerAiming.EnemyTarget != null)
        {
            base.Shoot();

            _towerAiming.EnemyTarget.Attack(_damage, _towerAiming.transform.forward);
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
