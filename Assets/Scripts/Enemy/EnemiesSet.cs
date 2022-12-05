using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyName
{
    Rat = 0,
    Monster = 1
}

[CreateAssetMenu(menuName = "EnemiesSet")]
public class EnemiesSet : ScriptableObject
{
    public GameObject[] _enemiesPrefab;

    public GameObject GetEnemy(EnemyName enemyName)
    {
        return _enemiesPrefab[enemyName.GetHashCode()];
    }
}
