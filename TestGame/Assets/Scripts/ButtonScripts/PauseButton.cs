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
        StartCoroutine(MenuFadeout());
    }

    public IEnumerator MenuFadeout()
    {
        for (byte i = 255; i > 0; i--)
            menu.GetComponent<Image>().color = new Color32(i, i, i, 200);
        yield return new WaitForSeconds(0.1f);
    }
}
