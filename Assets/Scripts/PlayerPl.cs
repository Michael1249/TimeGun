using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPl : MonoBehaviour
{
    public float speed = 2.0f;

    private void Start()
    {
    }

    private void Update()
    {
    }

    void move(Vector3 coord) 
    {
        transform.position += coord * speed * Time.deltaTime;
    }

}
