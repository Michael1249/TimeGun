using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPl : MonoBehaviour
{
    public Vector2 speed = new Vector2(30, 30);

    private Vector2 movement;
    public Joystick joystick;

    void Update()
    {
        float inputX = joystick.Horizontal;
        float inputY = joystick.Vertical; 
        movement = new Vector2(speed.x * inputX, speed.y * inputY);
    }

    void FixedUpdate()
    { 
        GetComponent<Rigidbody2D>().velocity = movement;
    }
}
