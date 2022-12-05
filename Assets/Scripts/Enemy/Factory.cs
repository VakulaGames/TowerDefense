using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    [SerializeField] private EnemiesSet _enemiesSet;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private Transform _enemiesParent;
    [SerializeField] private Transform _target;

    private Coroutine _spawnCoroutine;
    private WaitForSeconds _spawnDelayWFS;

    private void OnDisable()
    {
        if (_spawnCoroutine != null)
            StopCoroutine(_spawnCoroutine);
    }

    private void Start()
    {
        _spawnDelayWFS = new WaitForSeconds(_spawnDelay);
    }

    public void Spawn (Wave waves)
    {
        _spawnCoroutine = StartCoroutine(DelayedSpawn(waves));
    }

    private IEnumerator DelayedSpawn(Wave waves)
    {
        foreach (EnemiesPack pack in waves.EnemiesPack)
        {
            for (int i = 0; i < pack.Count; i++)
            {
                GameObject enemyPrefab = _enemiesSet.GetEnemy(pack.Name);
                GameObject enemyGO = Instantiate(enemyPrefab, pack.SpawnPoint.position, Quaternion.identity, _enemiesParent);
                Enemy enemy = enemyGO.GetComponent<Enemy>();
                enemy.Init(_target.position);
                yield return _spawnDelayWFS;
            }
        }
    }
}
