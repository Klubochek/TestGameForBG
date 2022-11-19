using UnityEngine;

public class ContinueButton : MonoBehaviour
{
    public GameObject menu;
    public void OnContinueButtonClick()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
    }
}
