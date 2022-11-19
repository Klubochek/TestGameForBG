using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShieldButton : MonoBehaviour
{
    public GameObject player;
    public Material mt;

    public bool clickedIs = false;
    public void OnButtonDown()
    {
        print("buttonDown");
        clickedIs = true;
        player.GetComponent<PlayerController>().isActiveShield = true;
        mt.color = new Color32(173, 255, 47,255);
        StartCoroutine(ButtonRealese());
    }
    public void OnButtonUp()
    {
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
            yield return new WaitForSeconds(0.5f);
            GetComponent<EventTrigger>().enabled = true;
            mt.color = new Color32(255, 255, 0, 255);
            player.GetComponent<PlayerController>().isActiveShield = false;
            print("buttonRealeseCoroutine");
        }
    }
    
}
