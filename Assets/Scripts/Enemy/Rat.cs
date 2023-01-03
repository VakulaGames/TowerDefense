using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : Enemy
{
    public override void Init(Vector3 target, int waveCount)
    {
        base.Init(target, waveCount);

        _health.Init(AdditionalHealth(waveCount), this);
    }

    private float AdditionalHealth(int waveCount)
    {
        return 2;
    }
}
