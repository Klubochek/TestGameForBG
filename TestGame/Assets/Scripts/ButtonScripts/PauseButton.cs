using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    public GameObject menu;
    public void PauseButtonClick()
    {
        menu.SetActive(true);
        Time.timeScale = 0;

        MenuFadeout();

    }

    public void MenuFadeout()
    {
        for (byte i = 255; i > 0; i--)
            menu.GetComponent<Image>().color =new Color32(i, i, i, 100);
        
    }
}
