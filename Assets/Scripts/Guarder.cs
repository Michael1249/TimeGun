using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guarder : Movable
{
    [SerializeField]
    private GameObject[] targets;

    private int target_indx = 0;

    private Rigidbody2D body;

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
        body = GetComponent<Rigidbody2D>();
        body.freezeRotation = true;
        //transform.position = get_current_target().transform.position;
        next();
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

        if (delta_pos.magnitude < delta_move.magnitude * 1.1)
        {
            next();
            body.velocity = new Vector3(0, 0, 0);
        }
        Debug.Log(delta_pos);
        body.AddForce(delta_move / Time.fixedDeltaTime * 100);
        //transform.position += delta_move;
    }
}
