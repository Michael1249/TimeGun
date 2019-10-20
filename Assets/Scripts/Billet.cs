using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billet : MonoBehaviour
{

    PlayerPl player;

    private Rigidbody2D body;

    [SerializeField]
    private Vector2 default_vector;

    [SerializeField]
    private float speed = 3;

    public void OnTriggerEnter2D(Collider2D other)
    {
        string tag = other.tag;

        switch (tag)
        {
            case "box":
                Destroy(other.gameObject);
                break;
            case "rotor":
                Destroy(this.gameObject);
                break;
            case "platform":
                Destroy(this.gameObject);
                break;
            case "bullet":
                Destroy(this.gameObject);
                break;
            case "Player":
                player.dead();
                break;
            default:
                break;
        }
    }

    void set_velocity()
    {
        body.velocity = body.velocity.normalized * speed;// * get_time_scale();
        //body.velocity -= body.velocity * (float)(body.velocity.magnitude - get_time_scale()) * 0.5f;
    }

    // Start is called before the first frame update
    void Start()
    {
        //FindObjectOfType<SoundsManager>().Play("Saw");
        //base.Start();
        player = GameObject.FindWithTag("Player").GetComponent<PlayerPl>();
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
        //base.FixedUpdate();
        //set_velocity();
    }

    void Update()
    {
        
    }
}
