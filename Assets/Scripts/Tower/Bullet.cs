using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] protected float _speed;

    protected float _damage;

    public virtual void Shoot(Vector3 target, float damage)
    {
        _damage = damage;
    }
}
