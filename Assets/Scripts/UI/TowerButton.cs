using UnityEngine;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(Button), typeof(Image))]
public class TowerButton : MonoBehaviour
{
    public void Construct(Tower tower)
    {
        GetComponent<Image>().sprite = tower.Sprite;
        GetComponentInChildren<TMP_Text>().text = tower.Price.ToString();
    }
}
