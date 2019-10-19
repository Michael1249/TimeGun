using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billet : Movable
{

    private Rigidbody2D body;

    [SerializeField]
    private Vector2 default_vector;

    void set_velocity()
    {
        body.velocity = body.velocity.normalized * get_time_scale();
        //body.velocity -= body.velocity * (float)(body.velocity.magnitude - get_time_scale()) * 0.5f;
    }

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        body = GetComponent<Rigidbody2D>();
        body.freezeRotation = true;

        if (body.velocity.magnitude == 0)
        {
            body.velocity = default_vector;
        }
        set_velocity();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        base.FixedUpdate();
        set_velocity();
    }

    void Update()
    {
        
    }
}
