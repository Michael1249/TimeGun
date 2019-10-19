using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour
{
    PlayerPl player;

    void OnTriggerEnter2D(Collider2D other)
    {
        string tag = other.gameObject.tag;

        switch (tag)
        {
            case "box":
                Destroy(other.gameObject);
                break;
            case "bullet":
                Destroy(other.gameObject);
                break;
            case "Player":
                player.dead();
                break;
            default:
                break;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerPl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
