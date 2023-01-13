using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private int _price;
    [SerializeField] private float _radiusAttack;
    [SerializeField] private float _intervalAttack;
    [SerializeField] private float _damage;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private TowerAiming _towerAiming;
    [SerializeField] private DrawRadius _drawRadius;
    [SerializeField] private Transform _bulletSpawnPoint;
    [SerializeField] private ParticleSystem _flash;

    public Sprite Sprite => _sprite;
    public int Price => _price;
    public float RadiusAttack => _radiusAttack;

    private Coroutine _aimAndAttack;
    private Queue<Bullet> _bulletPool;

    private void OnDisable()
    {
        if (_aimAndAttack != null) StopCoroutine(_aimAndAttack);
    }

    private void Start()
    {
        _towerAiming.SetRadiusAttack(RadiusAttack);
        ShowRadius(true);

        _bulletPool = FillBulletPool(_bulletPrefab, 5);
    }

    private IEnumerator AimAndAttack()
    {
        float attackCounter = _intervalAttack;

        while (true)
        {
            _towerAiming.Aim();

            attackCounter -= Time.deltaTime;
            if (attackCounter <= 0 && _towerAiming.Target != null)
            {
                if (Vector3.Angle(_bulletSpawnPoint.forward,
                    _towerAiming.Target.position - _bulletSpawnPoint.position) < 30)
                {
                    Shoot();

                    attackCounter = _intervalAttack;
                }
            }

            yield return null;
        }
    }

    public void BuildFinish()
    {
        _aimAndAttack = StartCoroutine(AimAndAttack());
        ShowRadius(false);
    }

    public void ShowRadius(bool enable)
    {
        if (enable == true)
            _drawRadius.ShowRadius(RadiusAttack);
        else
            _drawRadius.EndShow();
    }

    private Queue<Bullet> FillBulletPool (Bullet bulletPrefab, int count)
    {
        Queue<Bullet> bullets = new Queue<Bullet>();

        for (int i = 0; i < count; i++)
        {
            Bullet bullet = Instantiate(bulletPrefab);
            bullet.gameObject.SetActive(false);
            bullets.Enqueue(bullet);
        }

        return bullets;
    }

    private void Shoot()
    {
        Bullet bullet = _bulletPool.Dequeue();
        bullet.transform.position = _bulletSpawnPoint.position;
        bullet.transform.rotation = _bulletSpawnPoint.rotation;
        bullet.gameObject.SetActive(true);
        bullet.Shoot(_towerAiming.Target.position, _damage);
        _flash.Play();
        _bulletPool.Enqueue(bullet);
    }
}
