using System;
using UnityEngine;

public static class Events
{
    public static Action<Enemy> OnEnemyDeadEvent;

    public static void EnemyDead(Enemy enemy)
    {
        OnEnemyDeadEvent.Invoke(enemy);
    }
}
