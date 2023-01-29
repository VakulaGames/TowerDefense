using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] protected float _damage;
    [SerializeField] protected TowerAiming _towerAiming;
    [SerializeField] protected Transform _bulletSpawnPoint;

    [SerializeField] private Sprite _sprite;
    [SerializeField] private int _price;
    [SerializeField] private float _radiusAttack;
    [SerializeField] private float _intervalAttack;
    [SerializeField] private DrawRadius _drawRadius;
    [SerializeField] private ParticleSystem _flash;
    [SerializeField] private AudioSource _audioSource;

    public Sprite Sprite => _sprite;
    public int Price => _price;
    public float RadiusAttack => _radiusAttack;
    public int Level { get; private set; }
    public virtual int UpgradePrice { get { return Price * (Level + 1); } }
    public virtual int SellPrice { get { return ((Price * Level) / 10) * 9; } }

    private Coroutine _aimAndAttack;

    private void OnDisable()
    {
        if (_aimAndAttack != null) StopCoroutine(_aimAndAttack);
    }

    private void Start()
    {
        Level = 1;
        _towerAiming.SetRadiusAttack(RadiusAttack);
        ShowRadius(true);
    }

    private IEnumerator AimAndAttack()
    {
        float attackCounter = _intervalAttack;

        while (true)
        {
            _towerAiming.Aim();

            attackCounter -= Time.deltaTime;
            if (attackCounter <= 0 && _towerAiming.EnemyTarget != null)
            {
                if (IsAimed(_towerAiming.EnemyTarget.ShootTarget.position))
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

    protected virtual bool IsAimed (Vector3 targetPosition)
    {
        if (Vector3.Angle(_bulletSpawnPoint.forward,
                   targetPosition - _bulletSpawnPoint.position) < 30)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    protected virtual void Shoot()
    {
        _audioSource.Play();
        _flash.Play();
    }
}
