using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TempButton : MonoBehaviour
{
    public GameObject player;
    public Material mt;
    public void OnTempButtonClick()
    {
        print("buttonDown");
        player.GetComponent<PlayerController>().isActiveShield = true;
        mt.color = new Color32(173, 255, 47, 255);
        StartCoroutine(ButtonRealese());
    }
    public IEnumerator ButtonRealese()
    {
        yield return new WaitForSeconds(2);
        GetComponent<Button>().interactable = false;
        yield return new WaitForSeconds(0.5f);
        GetComponent<Button>().interactable = true;
        mt.color = new Color32(255, 255, 0, 255);
        player.GetComponent<PlayerController>().isActiveShield = false;
    }
}
