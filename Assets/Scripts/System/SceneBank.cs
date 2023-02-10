using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class SceneBank : MonoBehaviour
{
    [SerializeField] private int _startMoney;
    [SerializeField] private TMP_Text _moneyText;

    public int Money { get; private set; }

    private void OnEnable()
    {
        Events.OnEnemyDeadEvent += AddReward;
    }

    private void OnDisable()
    {
        Events.OnEnemyDeadEvent -= AddReward;
    }

    private void Start()
    {
        Money = _startMoney;
        _moneyText.text = Money.ToString();
    }

    public void Buy(int money)
    {
        if (money <= Money)
        {
            UpdateMoneyAsync( Money, Money - money);
            Money -= money;
        }
    }

    private void AddReward(Enemy enemy)
    {
        UpdateMoneyAsync(Money, Money + enemy.Reward);
        Money += enemy.Reward;
    }

    private async void UpdateMoneyAsync(int currentValue, int newValue)
    {
        if (newValue < currentValue)
        {
            while (currentValue > newValue)
            {
                currentValue -= 5;
                _moneyText.text = currentValue.ToString();
                await Task.Yield();
            }
        }
        else
        {
            while (currentValue < newValue)
            {
                currentValue += 2;
                _moneyText.text = currentValue.ToString();
                await Task.Yield();
            }
        }

        _moneyText.text = newValue.ToString();
    }
}
