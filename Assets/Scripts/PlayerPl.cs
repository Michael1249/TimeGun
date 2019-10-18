using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPl : MonoBehaviour
{
    public float speed = 2.0f;

    void move(Vector2 coord) 
    {
        transform.position += (Vector3)coord * speed * Time.deltaTime;
    }

}
