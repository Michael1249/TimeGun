using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guarder : Movable
{
    [SerializeField]
    private GameObject[] targets;

    private int target_indx = 0;

    void next()
    {
        target_indx++;
        if (target_indx == targets.Length)
        {
            target_indx = 0;
        }
    }

    GameObject get_current_target()
    {
        return targets[target_indx];
    }

    // Start is called before the first frame FixedUpdate
    void Start()
    {
        base.Start();
        GetComponent<Rigidbody2D>().freezeRotation = true;
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        base.FixedUpdate();
        float scale = get_time_scale();

        GameObject target = get_current_target();

        Vector3 that_pos = target.transform.position;
        Vector3 this_pos = transform.position;
        Vector3 delta_pos = that_pos - this_pos;
        Vector3 delta_move = delta_pos.normalized * scale;

        if (delta_pos.magnitude < delta_move.magnitude)
        {
            next();
        }

        transform.position += delta_move;
    }
}
