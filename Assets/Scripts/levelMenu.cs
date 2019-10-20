using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelMenu : MonoBehaviour
{   
    public void levelOne()
    {
        SceneManager.LoadScene(1);
    }
    public void levelTwo()
    {
        SceneManager.LoadScene(1);
    }
    public void levelThree()
    {
        SceneManager.LoadScene(1);
    }
    public void backToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
