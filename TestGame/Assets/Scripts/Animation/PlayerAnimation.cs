using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerAnimation : MonoBehaviour
{
    public static PlayerAnimation Instance;
    public GameObject deathAnimation;
    public GameObject confetti;
    public GameObject FadeIn;

    private void Awake()
    {
        Instance = this;
    }

    public IEnumerator Death(Transform transform)
    {
        GameObject ex = Instantiate(deathAnimation, transform.position + new Vector3(0, 3, 0), Quaternion.identity);
        yield return new WaitForSeconds(2);
        Destroy(ex);
    }
    public IEnumerator Win(Transform target)
    {
        Instantiate(confetti, target.transform.position + new Vector3(0, 3, 0), Quaternion.identity);
        FadeIn.SetActive(true);
        Image im = FadeIn.GetComponent<Image>();
        byte i = 0;
        while (i != 255)
        {
            i++;
            im.color = new Color32(0, 0, 0, i);
            yield return new WaitForSeconds(0.02f);
        }
        SceneManager.LoadScene(0);

    }
}
