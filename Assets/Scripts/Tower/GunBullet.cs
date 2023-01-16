using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class GunBullet : Bullet
{
    [SerializeField] private float _force;

    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    public override void Shoot(Vector3 target, float damage)
    {
        base.Shoot(target, damage);

        _rb.AddForce((target - transform.position) * _speed, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.Attack(_damage);
            if (collision.transform.TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
            {
                rigidbody.AddForce(transform.forward * _force, ForceMode.Impulse);
            }
        }

        _rb.velocity = Vector3.zero;
        gameObject.SetActive(false);
    }

}
