using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _baseHealth;
    

    private Enemy _enemy;

    public void Init(float additionalHealth, Enemy enemy)
    {
        _baseHealth += additionalHealth;
        _enemy = enemy;
    }

    public void TakeDamage(float damage)
    {
        if (damage < _baseHealth)
        {
            _baseHealth -= damage;
        }
        else
        {
            _enemy.Dead();
        }
    }
}
