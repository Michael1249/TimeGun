using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : Movable
{
    [SerializeField]
    private float period = 1f;

    [SerializeField]
    private Vector2 offset = new Vector2(0, 0);

    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private float spawn_timer;

    void spawn()
    {
        Instantiate(prefab, transform.position + (Vector3)offset, Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    
    }

    void FixedUpdate()
    {
        base.FixedUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawn_timer >= 0)
        {
            spawn_timer -= Time.deltaTime * get_time_scale();
            if (spawn_timer <= 0)
            {
                spawn_timer += period;
                spawn();
            }
        }
        //Debug.Log(spawn_timer);
    }
}
