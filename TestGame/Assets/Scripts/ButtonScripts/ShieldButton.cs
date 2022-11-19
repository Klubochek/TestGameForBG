using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShieldButton : MonoBehaviour
{
    public GameObject player;
    public Material mt;

    public bool clickedIs = false;
    private void OnMouseDown()
    {
        print("buttonDown");
        clickedIs = true;
        player.GetComponent<PlayerController>().isActiveShield = true;
        mt.color = new Color32(173, 255, 47,255);
        StartCoroutine(ButtonRealese());
    }
    void OnMouseUp()
    {
        print("buttonUp");
        clickedIs = false;
        StopCoroutine(ButtonRealese());
        GetComponent<Button>().interactable = true;
        mt.color = new Color32(255, 255, 0, 255);
        player.GetComponent<PlayerController>().isActiveShield = false;
    }


    public IEnumerator ButtonRealese()
    {
        yield return new WaitForSeconds(2);
        GetComponent<Button>().interactable = false;
        yield return new WaitForSeconds(0.5f);
        GetComponent<Button>().interactable = true;
        mt.color = new Color32(255, 255, 0,255);
        player.GetComponent<PlayerController>().isActiveShield = false;
    }
    
}
