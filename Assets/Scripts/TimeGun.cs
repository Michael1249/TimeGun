using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeGun : MonoBehaviour
{
    [SerializeField]
    public float allowedDistance;
    [SerializeField]
    public bool isIncreasingMode = true;
    [SerializeField]
    public float shotPrice;


    private bool isEnable = true;

    private GameObject player;
    private Camera camera;
    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        
        gameController = GameObject.FindWithTag("game_controller").GetComponent<GameController>();
        camera = Camera.main;
        
        //Debug.Log(gameController);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isEnable) return;

        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                // Construct a ray from the current touch coordinates
                shot(player.transform.position, Input.GetTouch(i).position);
                /*
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);

                // Create a particle if hit
                if (Physics.Raycast(ray))
                {
                    Instantiate(particle, transform.position, transform.rotation);
                }*/
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            shot(player.transform.position, Input.mousePosition);
            /*
            // get clicked object
            Vector3 clickPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(clickPoint, Vector2.zero);

            if (hit.collider != null)
            {
                // get the nearest object in the way of shot
                var length = Vector3.Distance(player.transform.position, clickPoint);

                Vector3 direction = clickPoint - player.transform.position;
                direction.Normalize();

                RaycastHit2D[] hitFinal = Physics2D.RaycastAll(player.transform.position, direction * length);

                if (hitFinal.Length > 1) 
                {
                    // check distance
                    if (getDistance(hitFinal[1].point, player.transform.position) > allowedDistance) return;
                    // checking is the nearest object a Movable
                    drawRay(player.transform.position, hitFinal[1].point, 0.4f);

                    Movable movable = hitFinal[1].collider.gameObject.GetComponent<Movable>();

                    if (movable != null)
                    {
                        FindObjectOfType<SoundsManager>().Play("Attack");
                        Debug.Log("Luck!");

                        if (isIncreasingMode)
                        {
                            movable.hot();
                        } else
                        {
                            movable.freeze();
                        }

                        gameController.decreaseTime(shotPrice);
                    }  
                }
            }*/
        }
    }

    private void shot(Vector3 playerV, Vector3 clickV)
    {
        Vector3 clickPoint = Camera.main.ScreenToWorldPoint(clickV);
        RaycastHit2D hit = Physics2D.Raycast(clickPoint, Vector2.zero);

        if (hit.collider != null)
        {
            // get the nearest object in the way of shot
            var length = Vector3.Distance(playerV, clickPoint);

            Vector3 direction = clickPoint - playerV;
            direction.Normalize();

            RaycastHit2D[] hitFinal = Physics2D.RaycastAll(playerV, direction * length);

            if (hitFinal.Length > 1)
            {
                // check distance
                if (getDistance(hitFinal[1].point, playerV) > allowedDistance) return;
                // checking is the nearest object a Movable
                drawRay(playerV, hitFinal[1].point, 0.4f);

                Movable movable = hitFinal[1].collider.gameObject.GetComponent<Movable>();

                if (movable != null)
                {
                    Debug.Log("Luck!");

                    if (isIncreasingMode)
                    {
                        movable.hot();
                    }
                    else
                    {
                        movable.freeze();
                    }

                    gameController.decreaseTime(shotPrice);
                }
            }
        }
    }


    private float getDistance(Vector3 v1, Vector3 v2)
    {
        v1.z = 0;
        v2.z = 0;
        var length = Vector3.Distance(v1, v2);

        return length;
    }

    private void drawRay(Vector3 v1, Vector3 v2, float seconds)
    {
        var length = Vector3.Distance(v1, v2);
        
        Vector3 direction = v2 - v1;
        direction.Normalize();

        Debug.DrawRay(v1, direction * length, Color.green, seconds);
    }
}
