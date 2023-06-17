using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorableBall : Scorable
{
    [SerializeField] private int multiplier;
    public override int CalculatePoints()
    {
        Ball b = GetComponent<Ball>();
        if (b == null)
            Destroy(this);
        return (int)b.Size * multiplier;
    }
}
