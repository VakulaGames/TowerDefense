using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Helmet : MonoBehaviour
{
    [SerializeField] private float _force;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void KnockDown(Vector3 direction)
    {
        gameObject.transform.parent = null;
        _rigidbody.isKinematic = false;
        _rigidbody.AddForce((Vector3.up + direction) * _force, ForceMode.Impulse);
        Destroy(gameObject,1);
    }
}
