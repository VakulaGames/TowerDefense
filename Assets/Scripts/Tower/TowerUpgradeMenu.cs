using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TowerUpgradeMenu : MonoBehaviour
{
    [SerializeField] private GameObject _upgradeMenu;
    [SerializeField] private Image _towerImage;
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private Button _sellButton;
    [SerializeField] private TMP_Text _upgradePrice;
    [SerializeField] private TMP_Text _sellPrice;

    private Tower _selectedTower;

    private void OnEnable()
    {
        _upgradeButton.onClick.AddListener(Upgrade);
        _sellButton.onClick.AddListener(Sell);

        _upgradeMenu.SetActive(false);
    }

    private void OnDisable()
    {
        _upgradeButton.onClick.RemoveListener(Upgrade);
        _sellButton.onClick.RemoveListener(Sell);
    }

    public void SelectTower()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.transform.TryGetComponent<Tower>(out Tower tower))
            {
                _selectedTower = tower;
                EnableMenu();
            }
            else
            {
                _upgradeMenu.SetActive(false);
            }
        }
    }

    private void EnableMenu()
    {
        _upgradePrice.text = _selectedTower.UpgradePrice.ToString();
        _sellPrice.text = _selectedTower.SellPrice.ToString();
        _towerImage.sprite = _selectedTower.Sprite;
        _upgradeMenu.SetActive(true);
    }

    private void Sell()
    {
        throw new NotImplementedException();
    }

    private void Upgrade()
    {
        throw new NotImplementedException();
    }


}
