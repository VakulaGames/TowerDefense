using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Health))]
public abstract class Enemy : MonoBehaviour, IDamageble
{
    [SerializeField] private Transform _shootTarget;

    public Transform ShootTarget => _shootTarget;

    private NavMeshAgent _agent;
    protected Health _health;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _health = GetComponent<Health>();
    }

    public virtual void Init(Vector3 target, int waveCount)
    {
        _agent.SetDestination(target);
    }

    public virtual void Attack()
    {

    }

    public virtual void Dead()
    {

    }

}
