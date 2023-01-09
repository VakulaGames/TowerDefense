using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class TowerAiming : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _towerBody;

    public Transform Target { get; private set; }

    private List<Enemy> _enemies;
    private Sequence _sequence;
    private bool _aimingEnable;

    private void OnEnable()
    {
        _enemies = new List<Enemy>();
    }

    private void OnDisable()
    {
        if (_sequence != null)
            _sequence.Kill();
    }

    private void Update()
    {
        if (_aimingEnable == true && Target != null)
        {
            Vector3 direction1 = Target.position - _towerBody.position;
            float signedAngle1 = Vector3.SignedAngle(GetWithoutY(_towerBody.forward), GetWithoutY(direction1), Vector3.up);
            Vector3 euler1 = _towerBody.eulerAngles;
            euler1.y = Mathf.LerpAngle(euler1.y, euler1.y + signedAngle1, _speed * Time.deltaTime);
            _towerBody.eulerAngles = euler1;
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
                Target = _enemies[0].transform;
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

            if (Target != null && Target == enemy.transform)
            {
                if (_enemies.Count > 0)
                {
                    Target = _enemies[0].transform;
                }
                else
                {
                    Target = null;
                }
            }
        }
    }

    public void StartAiming()
    {
        _aimingEnable = true;
    }

    public void SetRadiusAttack(float radius)
    {
        transform.localScale = new Vector3(radius * 2, 1, radius * 2);
    }
}
