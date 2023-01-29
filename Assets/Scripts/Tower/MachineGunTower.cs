public class MachineGunTower : Tower
{
    protected override void Shoot()
    {
        if (_towerAiming.EnemyTarget != null)
        {
            base.Shoot();

            _towerAiming.EnemyTarget.Attack(_damage, _towerAiming.transform.forward);
        }
    }
}
