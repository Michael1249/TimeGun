using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeGun : MonoBehaviour
{
    private float allowedDistance;
    [SerializeField]
    private bool isIncreasingMode = true;
    [SerializeField]
    public float shotPrice;

    private GameObject player;
    private Camera camera;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // get clicked object
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                // get the nearest object
                var length = Vector3.Distance(player.transform.position, hit.collider.gameObject.transform.position);

                Vector3 direction = hit.collider.gameObject.transform.position - player.transform.position;
                direction.Normalize();

                RaycastHit2D[] hitFinal = Physics2D.RaycastAll(player.transform.position, direction * length);

                if (hitFinal.Length > 1)
                {
                    // checking is nearest object a Movable
                    drawRay(player, hitFinal[1].collider.gameObject, 3);

                    Movable movable = hitFinal[1].collider.gameObject.GetComponent<Movable>();

                    if (movable != null)
                    {
                        Debug.Log("Luck!");

                        if (isIncreasingMode)
                        {
                            movable.hot();
                        } else
                        {
                            movable.freeze();
                        }
                    }  
                }
            }
        }
    }

    private void drawRay(GameObject o1, GameObject o2, float seconds)
    {
        var length = Vector3.Distance(o1.transform.position, o2.transform.position);

        Vector3 direction = o2.transform.position - o1.transform.position;
        direction.Normalize();

        Debug.DrawRay(o1.transform.position, direction * length, Color.green, seconds);
    }

    public void Shot(GameObject gameObject)
    {
        //Debug.Log("Shot");
    }
}
