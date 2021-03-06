﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private PlayerPl player;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player = GameObject.FindWithTag("Player").GetComponent<PlayerPl>();
            FindObjectOfType<SoundsManager>().Play("Trap");
            player.dead();
        }
    }
}
