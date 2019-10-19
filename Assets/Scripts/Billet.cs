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
    }

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        body = GetComponent<Rigidbody2D>();

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
    }

    void Update()
    {
        set_velocity();
    }
}
