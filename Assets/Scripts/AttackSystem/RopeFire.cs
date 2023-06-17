using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeFire : Fire
{
    private void Awake()
    {
        transform.localScale = new Vector3(transform.localScale.x, Camera.main.orthographicSize * 2, transform.localScale.z);
    }
 
    private void Update()
    {
        transform.position += new Vector3(0f, speed * Time.deltaTime, 0f);
    }
}
