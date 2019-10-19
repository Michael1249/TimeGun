using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    PlayerPl player;

    public UnityEvent OnEnable;
    public UnityEvent OnDisable;

    public float treshold = 0.5f;

    private bool state = false;

    void OnTriggerStay2D(Collider2D other)
    {

        string tag = other.gameObject.tag;
        Transform other_transform = other.gameObject.transform;

        if (tag == "Player" || tag == "Box")
        {
           if ((other_transform.position - transform.position).magnitude < treshold)
           {
                if (state == false)
                {
                    state = true;
                    OnEnable.Invoke();
                }
            }
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {

        string tag = other.gameObject.tag;
        Transform other_transform = other.gameObject.transform;

        if (tag == "Player" || tag == "Box")
        {
            if (state == true)
            {
                state = false;
                OnDisable.Invoke();
            }
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
