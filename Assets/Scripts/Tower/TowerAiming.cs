using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class TowerAiming : MonoBehaviour
{
    [SerializeField] private float _speedRotation;
    [SerializeField] private Transform _towerBody;

    public Transform Target { get; private set; }

    private List<Enemy> _enemies;
    private Sequence _sequence;

    private void OnEnable()
    {
        _enemies = new List<Enemy>();
        Events.OnEnemyDeadEvent += CheckDeadEnemy;
    }

    private void OnDisable()
    {
        if (_sequence != null)
            _sequence.Kill();
        Events.OnEnemyDeadEvent -= CheckDeadEnemy;
    }

    public void Aim()
    {
        if (Target != null)
        {
            Vector3 direction = Target.position - _towerBody.position;
            float signedAngle = Vector3.SignedAngle(GetWithoutY(_towerBody.forward), GetWithoutY(direction), Vector3.up);
            Vector3 euler = _towerBody.eulerAngles;
            euler.y = Mathf.LerpAngle(euler.y, euler.y + signedAngle, _speedRotation * Time.deltaTime);
            _towerBody.eulerAngles = euler;
        }
    }

    private Vector3 GetWithoutY(Vector3 v)
    {
        v.y = 0.0f;

        return v;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            _enemies.Add(enemy);

            if (Target == null)
                Target = _enemies[0].ShootTarget;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            if (_enemies.Contains(enemy))
            {
                _enemies.Remove(enemy);
            }

            if (Target != null && Target == enemy.ShootTarget)
            {
                if (_enemies.Count > 0)
                {
                    Target = _enemies[0].ShootTarget;
                }
                else
                {
                    Target = null;
                }
            }
        }
    }

    public void SetRadiusAttack(float radius)
    {
        transform.localScale = new Vector3(radius * 2, 1, radius * 2);
    }

    private void CheckDeadEnemy(Enemy enemy)
    {
        if (_enemies.Contains(enemy))
        {
            _enemies.Remove(enemy);

            if (Target == enemy.ShootTarget)
            {
                if (_enemies.Count > 0)
                {
                    Target = _enemies[0].ShootTarget;
                }
                else
                {
                    Target = null;
                }
            }
        }
    }
}
