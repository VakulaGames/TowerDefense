using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    [SerializeField] private TowerPlace[] _allPlaces;
    [SerializeField] private Tower[] _towers;
    [SerializeField] private TowerButton _buttonPrefab;
    [SerializeField] private Transform _towerPanel;
    [SerializeField] private ErrorMessage _errorMessage;

    private Button[] _buttons;
    private Coroutine _buildMovement;
    private Tower _buildingTower;

    private void OnEnable()
    {
        _buttons = new Button[_towers.Length];

        for (int i = 0; i < _buttons.Length; i++)
        {
            TowerButton towerButton = Instantiate(_buttonPrefab, _towerPanel);
            towerButton.Construct(_towers[i]);
            _buttons[i] = towerButton.GetComponent<Button>();

            int index = i;
            _buttons[i].onClick.AddListener(() => { StartBuilding(index) ; });
        }
    }

    private void OnDisable()
    {
        foreach(Button button in _buttons)
        {
            button.onClick.RemoveListener(ShowPlaces);
        }

        if (_buildMovement != null)
            StopCoroutine(_buildMovement);
    }

    public void EnterBuild()
    {
        if (_buildingTower != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform.TryGetComponent<TowerPlace>(out TowerPlace towerPlace))
                {
                    _buildingTower.transform.position = hit.transform.position;
                    _buildingTower.transform.rotation = hit.transform.rotation;
                    //construct start attack
                    _buildingTower = null;
                }
                else
                {
                    _errorMessage.ShowMessage("Здесь нельзя строить");
                }
            }
        }
    }

    public void CancelBuilding()
    {
        if (_buildingTower != null)
        {
            Destroy(_buildingTower.gameObject);
        }
    }

    private void StartBuilding (int towerIndex)
    {
        ShowPlaces();
        _buildMovement = StartCoroutine(BuildMovement(_towers[towerIndex]));
    }

    private void ShowPlaces()
    {
        foreach (var place in _allPlaces)
        {
            place.ShowPlace();
        }
    }

    private void EndShowPlaces()
    {
        foreach (var place in _allPlaces)
        {
            place.EndShowPlace();
        }
    }

    private IEnumerator BuildMovement(Tower towerPrefab)
    {
        _buildingTower = Instantiate(towerPrefab);

        while (_buildingTower != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray,out RaycastHit hit))
            {
                if (hit.transform.TryGetComponent<TowerPlace>(out TowerPlace towerPlace))
                {
                    _buildingTower.transform.position = hit.transform.position;
                    _buildingTower.transform.rotation = hit.transform.rotation;
                }
                else
                {
                    _buildingTower.transform.position = hit.point;
                }
            }

            yield return null;
        }
    }
}
