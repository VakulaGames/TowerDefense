using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private Building _building;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _building.EnterBuild();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            _building.CancelBuilding();
        }
    }
}
