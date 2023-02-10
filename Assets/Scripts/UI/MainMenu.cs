using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _levelSelectionButton;
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private Button _closedPanelButton;

    [SerializeField] private GameObject _buttonsPanel;
    [SerializeField] private GameObject _levelPanel;
    [SerializeField] private GameObject _upgradePanel;

    private void OnEnable()
    {
        _levelSelectionButton.onClick.AddListener(ShowLevelPanel);
        _upgradeButton.onClick.AddListener(ShowUpgradePanel);
        _closedPanelButton.onClick.AddListener(ClosePanel);
    }

    private void OnDisable()
    {
        _levelSelectionButton.onClick.RemoveListener(ShowLevelPanel);
        _upgradeButton.onClick.RemoveListener(ShowUpgradePanel);
        _closedPanelButton.onClick.RemoveListener(ClosePanel);
    }

    private void ShowLevelPanel()
    {
        _buttonsPanel.SetActive(false);
        _levelPanel.SetActive(true);
        _closedPanelButton.gameObject.SetActive(true);
    }

    private void ShowUpgradePanel()
    {
        _buttonsPanel.SetActive(false);
        _upgradePanel.SetActive(true);
        _closedPanelButton.gameObject.SetActive(true);
    }

    private void ClosePanel()
    {
        _closedPanelButton.gameObject.SetActive(false);
        _levelPanel.SetActive(false);
        _upgradePanel.SetActive(false);
        _buttonsPanel.SetActive(true);
    }
}
