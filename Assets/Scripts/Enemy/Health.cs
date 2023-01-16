using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _baseHealth;
    [SerializeField] private EnemySound _enemySound;

    private IDamageble _damageble;

    public void Init(float additionalHealth, IDamageble damageble)
    {
        _baseHealth += additionalHealth;
        _damageble = damageble;
    }

    public void TakeDamage(float damage)
    {
        if (damage < _baseHealth)
        {
            _baseHealth -= damage;
            _enemySound.PlayHit();
        }
        else
        {
            _damageble.Dead();
            _enemySound.PlayDeath();
        }
    }
}
