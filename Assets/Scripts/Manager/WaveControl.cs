using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveControl : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Factory _factory;
    [SerializeField] private Wave[] _waves;

    private int _currentWave = 0;

    private void OnEnable()
    {
        _startButton.onClick.AddListener(StartWave);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(StartWave);
    }

    private void StartWave()
    {
        if (_currentWave < _waves.Length)
            _factory.Spawn(_waves[_currentWave]);

        _currentWave++;
    }
}

[System.Serializable]
public struct Wave
{
    public EnemiesPack[] EnemiesPack;
}

[System.Serializable]
public struct EnemiesPack
{
    public EnemyName Name;
    public int Count;
    public Transform SpawnPoint;
}

