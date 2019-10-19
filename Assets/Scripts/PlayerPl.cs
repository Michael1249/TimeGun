using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPl : MonoBehaviour
{
    [SerializeField]
    private float speed = 2.0f;
    [SerializeField]
    private bool key_board_controll = false;

    private Rigidbody2D body;

    void move(Vector2 coord) 
    {
        body.AddForce((Vector3)coord * speed * Time.deltaTime);
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

    public void Update()
    {
        if (key_board_controll)
        {
            move(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
        }
    }

}
