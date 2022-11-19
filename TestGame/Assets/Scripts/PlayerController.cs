using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public bool isActiveShield = false;
    public GameObject FadeIn;
    public GameObject deathAnimation;
    private Vector3 startPos = new Vector3(0.5f, 4, 0.5f);
    [SerializeField] private GameObject target;
    private NavMeshAgent agent;

    void Start()
    {
        transform.position = startPos;


        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(GoToEndArea());

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DeathArea" && !isActiveShield)
        {
            agent.isStopped = true;
            print("DEATHAREA");
            StartCoroutine(Death());

        }
        if (other.gameObject.tag == "EndArea")
        {
            print("ENDAREA");
            FadeIn.SetActive(true);
            StartCoroutine(Win());
        }
    }
    public IEnumerator Death()
    {
        GameObject ex = Instantiate(deathAnimation, transform.position + new Vector3(0, 3, 0), Quaternion.identity);
        transform.position = startPos;
        yield return new WaitForSeconds(2);
        agent.isStopped = false;
        Destroy(ex);


    }
    public IEnumerator Win()
    {
        Image im = FadeIn.GetComponent<Image>();
        byte i = 0;
        while (i!=255)
        {
            i++;
            im.color = new Color32(0, 0, 0, i);
            
            yield return new WaitForSeconds(0.02f);
        }
        SceneManager.LoadScene(0);

    }
    private IEnumerator GoToEndArea()
    {
        yield return new WaitForSeconds(2);
        target = GameObject.FindGameObjectWithTag("EndArea");
        agent.SetDestination(target.transform.position);

    }
}
