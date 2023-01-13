using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : Enemy
{
    [SerializeField] private ParticleSystem _damageEffect;

    public override void Init(Vector3 target, int waveCount)
    {
        base.Init(target, waveCount);

        _health.Init(AdditionalHealth(waveCount), this);
    }

    private float AdditionalHealth(int waveCount)
    {
        return 2;
    }

    public override void Attack(float damage)
    {
        base.Attack(damage);
        _damageEffect.Play();
    }
}
