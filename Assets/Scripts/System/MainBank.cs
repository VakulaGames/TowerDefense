using UnityEngine;
using TMPro;
using Zenject;

public class MainBank : MonoBehaviour
{
    [SerializeField] private TMP_Text _money;

    [Inject]
    private void Construct(GameData gameData )
    {
        _money.text = gameData.Money.ToString();
    }
}
