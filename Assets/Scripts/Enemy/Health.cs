using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _baseHealth;

    private IDamageble _damageble;

    public void Init(float additionalHealth, IDamageble damageble)
    {
        _baseHealth += additionalHealth;
        _damageble = damageble;
    }

    public void TakeDamage(float damage)
    {

    }
}
