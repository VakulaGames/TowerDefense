using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class Bank : MonoBehaviour
{
    [SerializeField] private int _startMoney;
    [SerializeField] private TMP_Text _moneyText;

    public int Money { get; private set; }

    private void Start()
    {
        Money = _startMoney;
        _moneyText.text = Money.ToString();
    }

    public void Buy(int money)
    {
        if (money <= Money)
        {
            UpdateMoneyAsync(_moneyText, Money, Money - money);
            Money -= money;
        }
        else
        {
            Debug.Log("Недостаточно денег");
        }
    }

    private async void UpdateMoneyAsync(TMP_Text text,int currentValue, int newValue)
    {
        while(currentValue > newValue)
        {
            currentValue -= 5;
            text.text = currentValue.ToString();
            await Task.Yield();
        }

        text.text = newValue.ToString();
    }
}
