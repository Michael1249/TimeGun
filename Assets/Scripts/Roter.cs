using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roter : Movable
{
    // Start is called before the first frame FixedUpdate
    void Start()
    {
        base.Start();
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        base.FixedUpdate();
        transform.Rotate(new Vector3(0, 0, get_time_scale()));
    }
}
