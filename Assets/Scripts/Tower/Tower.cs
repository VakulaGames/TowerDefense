using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private int _price;
    [SerializeField] private float _radiusAttack;
    [SerializeField] private TowerAiming _towerAiming;
    [SerializeField] private DrawRadius _drawRadius;

    public Sprite Sprite => _sprite;
    public int Price => _price;
    public float RadiusAttack => _radiusAttack;

    private void Start()
    {
        _towerAiming.SetRadiusAttack(RadiusAttack);
        ShowRadius(true);
    }

    public void BuildFinish()
    {
        _towerAiming.StartAiming();
        ShowRadius(false);
    }

    public void ShowRadius(bool enable)
    {
        if (enable == true)
            _drawRadius.ShowRadius(RadiusAttack);
        else
            _drawRadius.EndShow();
    }
}
