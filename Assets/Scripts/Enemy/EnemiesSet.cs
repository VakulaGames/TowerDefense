using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyName
{
    SmallRat = 0,
    SmallRatInHelmet = 1,
    BigRat = 2,
    BigRatInHelmet = 3,
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
