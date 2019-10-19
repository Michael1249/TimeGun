using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour
{
    [SerializeField]
    private Gradient gradient;
    [SerializeField]
    private bool enable = true;
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

    private float time_scale;
    private float target_time_scale;
    private float timer = 0f;

    public void set_enable(bool value)
    {
        enable = value;
    }

    void set_time_scale(float value)
    {
        target_time_scale = value;
    }

    float get_percentage()
    {
        bool freeze = time_scale < default_scale;
        float target_scale = (freeze) ? freeze_scale : hot_scale;
        float value = (time_scale - default_scale) / (target_scale - default_scale);

        value = (freeze) ? (1 - value) / 2 : (value + 1) / 2;
        return value;
    }

    void set_color()
    { 
    
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();

        renderer.color = gradient.Evaluate(get_percentage());
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
        if (!enable)
        {
            return 0;
        }
        else
        {
            return time_scale;
        }

    }

    void OnMouseDown()
    {
        // this object was clicked - do something
        Destroy(this.gameObject);
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
            timer -= Time.fixedDeltaTime;
            if (timer <= 0)
            {
                timer = 0;
                reset();
            }
        }
        set_color();
    }
}
