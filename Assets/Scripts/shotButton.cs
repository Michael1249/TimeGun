using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotButton : MonoBehaviour
{
    public GameObject freezButton, speedButton;

    void Start()
    {
    }

    public void BlueShoot()
    {
        freezButton.SetActive(false);
        speedButton.SetActive(true);
    }
    public void RedShoot()
    {
        freezButton.SetActive(true);
        speedButton.SetActive(false);
    }
}
