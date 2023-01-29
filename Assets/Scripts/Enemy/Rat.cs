using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : Enemy
{
    [SerializeField] private ParticleSystem _damageEffect;
    [SerializeField] private Helmet _helmet;
    [SerializeField] private float _force;

    public override void Init(Vector3 target, int waveCount)
    {
        base.Init(target, waveCount);

        _health.Init(AdditionalHealth(waveCount), this);
    }

    private float AdditionalHealth(int waveCount)
    {
        return 2;
    }

    public override void Attack(float damage, Vector3 direction)
    {
        base.Attack(damage, direction);

        if (_helmet != null)
        {
            _enemySound.PlayHelmetShot();
            _helmet.KnockDown(direction);
            _helmet = null;
        }
        else
        {
            Vector3 horizontalDirection = new Vector3(direction.x, 0, direction.z);
            _rigidbody.AddForce(horizontalDirection * _force,ForceMode.Impulse);
            _enemySound.PlayHit();
            _damageEffect.Play();
        }
    }
}
