using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    [SerializeField]
    public float defaultTime;
    private float time;
    private bool isPrevueMode = false;

    // Start is called before the first frame update
    void Start()
    {
        time = defaultTime;

        startGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPrevueMode) return;
        time -= Time.deltaTime;


        if (this.time <= 0)
        {
            this.isPrevueMode = true;
            // Method that calls menu gameover. It must call resetScene() afterwards.
        }
    }

    public void resetScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void resetTime()
    {
        time = defaultTime;
    }

    public void decreaseTime(float seconds)
    {
        if (seconds < 0) seconds = -seconds;
        this.time -= seconds;
    }

    public void startGame()
    {
        this.isPrevueMode = true;
    }

    public void stopGame()
    {
        this.isPrevueMode = false;
    }

    public float getTime()
    {
        return time;
    }
}
