using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    [SerializeField]
    public float defaultTime;
    private float time;
    private bool isPreviewMode = true;

    // Start is called before the first frame update
    void Start()
    {
        time = defaultTime;

        //startGame();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isPreviewMode) return;
        time -= Time.deltaTime;


        if (this.time <= 0)
        {
            stopGame();
            // Method that calls menu gameover. It must call resetScene() afterwards.
            resetScene();
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
        this.isPreviewMode = false;
    }

    public void stopGame()
    {
        this.isPreviewMode = true;
    }

    public float getTime()
    {
        return time;
    }
}
