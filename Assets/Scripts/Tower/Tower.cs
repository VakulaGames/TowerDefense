using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private int _price;

    public Sprite Sprite => _sprite;
    public int Price => _price;
}
