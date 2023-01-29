using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUpAiming : MonoBehaviour
{
    [SerializeField] private TowerAiming _aiming;
    [SerializeField] private Transform _body;
    [SerializeField] private float _speed;

    public void Aim()
    {
        if (_aiming.EnemyTarget != null)
        {
            Quaternion lookRotation = Quaternion.LookRotation(_aiming.EnemyTarget.ShootTarget.position - transform.position);
            Quaternion rotateTowards = Quaternion.RotateTowards(transform.rotation, lookRotation, Time.deltaTime * _speed);
            transform.rotation = Quaternion.Euler(rotateTowards.eulerAngles.x, _body.eulerAngles.y, rotateTowards.eulerAngles.z);
        }
    }
}
