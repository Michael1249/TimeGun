using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPl : MonoBehaviour
{

    public Vector2 speed = new Vector2(30, 30);


    private Vector2 movement;
    public Joystick joystick;
    Rigidbody2D body;
    void Update()
    {

        float inputX = joystick.Horizontal;
        float inputY = joystick.Vertical; 
        movement = new Vector2(speed.x * inputX, speed.y * inputY);

    }

    public void dead()
    {
        Debug.Log("Dead");
    }

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.freezeRotation = true;
    }

    void FixedUpdate()
    { 
        body.velocity = movement;
    }
}
