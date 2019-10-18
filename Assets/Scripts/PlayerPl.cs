using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPl : MonoBehaviour
{
    public float speed = 2.0f;

    void move(Vector3 coord) 
    {
        transform.position += coord * speed * Time.deltaTime;
    }

}
