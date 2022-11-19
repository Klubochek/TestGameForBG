using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShieldButton : MonoBehaviour
{
    public GameObject player;
    public Material mt;
    public Image buttomImage;

    public bool clickedIs = false;
    public void OnButtonDown()
    {
        buttomImage.color = new Color32(0, 0, 255, 255);
        print("buttonDown");
        clickedIs = true;
        player.GetComponent<PlayerController>().isActiveShield = true;
        mt.color = new Color32(173, 255, 47, 255);
        StartCoroutine(ButtonRealese());
    }
    public void OnButtonUp()
    {
        buttomImage.color = new Color32(255, 255, 255, 255);
        print("buttonUp");
        clickedIs = false;
        mt.color = new Color32(255, 255, 0, 255);
        player.GetComponent<PlayerController>().isActiveShield = false;
        GetComponent<EventTrigger>().enabled = true;
    }


    public IEnumerator ButtonRealese()
    {
        yield return new WaitForSeconds(2);
        if (clickedIs == true)
        {
            GetComponent<EventTrigger>().enabled = false;
            buttomImage.color = new Color32(255, 255, 255, 10);
            yield return new WaitForSeconds(0.5f);
            buttomImage.color = new Color32(255, 255, 255, 255);
            GetComponent<EventTrigger>().enabled = true;
            mt.color = new Color32(255, 255, 0, 255);
            player.GetComponent<PlayerController>().isActiveShield = false;
            print("buttonRealeseCoroutine");
        }
    }

}
