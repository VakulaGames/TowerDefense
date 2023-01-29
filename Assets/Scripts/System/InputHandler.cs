using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private Building _building;
    [SerializeField] private TowerUpgradeMenu _upgradeMenu;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_building.IsBuildingMod == true)
            {
                _building.EnterBuild();
            }
            else
            {
                _upgradeMenu.SelectTower();
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            if (_building.IsBuildingMod == true)
            {
                _building.CancelBuilding();
            }
        }
    }
}
