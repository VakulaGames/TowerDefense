using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class LevelButton : MonoBehaviour
{
    [SerializeField] private int _level;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(StartLevel);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(StartLevel);
    }

    private void StartLevel()
    {
        SceneManager.LoadScene(_level);
    }
}
