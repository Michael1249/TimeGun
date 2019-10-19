using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour
{
    private float time_scale;
    private float target_time_scale;

    private float timer = 0f;

    [SerializeField]
    private bool locked = false;
    [SerializeField]
    private float default_scale = 1f;
    [SerializeField]
    private float freeze_scale = 0.3f;
    [SerializeField]
    private float hot_scale = 1.7f;
    [SerializeField]
    private float time_to_reset = 2f; // sec
    [SerializeField]
    private float change_speed = 2f;
    [SerializeField]
    private float linear_change_speed = 0.05f;


    void set_time_scale(float value)
    {
        target_time_scale = value;
    }

    void reset()
    {
        target_time_scale = default_scale;
    }

    public void freeze()
    {
        if (!locked)
        {
            target_time_scale = freeze_scale;
            timer = time_to_reset;
        }
    }

    public void hot()
    {
        if (!locked)
        {
            target_time_scale = hot_scale;
            timer = time_to_reset;
        }
    }

    public float get_time_scale()
    {
        return time_scale;
    }

    // Start is called before the first frame FixedUpdate
    public void Start()
    {
        time_scale = default_scale;
        target_time_scale = default_scale;
    }

    // FixedUpdate is called once per frame
    public void FixedUpdate()
    {
        float delta = target_time_scale - time_scale;
        if (Mathf.Abs(delta) > linear_change_speed * 2)
        {
            time_scale += delta * change_speed;
            time_scale += delta > 0 ? linear_change_speed : -linear_change_speed;
        }
        if (timer > 0)
        {
            timer -= Time.fixedTime;
            if (timer <= 0)
            {
                timer = 0;
                reset();
            }
        }
    }
}
