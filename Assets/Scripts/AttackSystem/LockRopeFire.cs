using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRopeFire : RopeFire
{
    [SerializeField] private int lockTime;
    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ceiling"))
        {
            StartCoroutine(Lock());
            return;
        }
        base.OnCollisionEnter2D(collision);
    }
    IEnumerator Lock()
    {
        yield return new WaitForSeconds(lockTime);
        Pool.Release(this);
    }
}
