using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public bool isActiveShield = false;
    public GameObject deathAnimation;
    private Transform playerTransform;
    private Vector3 startPos = new Vector3(0.5f, 2, 0.5f);
    [SerializeField] private GameObject target;
    private NavMeshAgent agent;

    void Start()
    {
        playerTransform = GetComponent<Transform>();
        playerTransform.position = startPos;
        

        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(GoToEndArea());

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "DeathArea"&&!isActiveShield)
        {
            print("DEATHAREA");
            StartCoroutine(Death());

        }
        if (collision.gameObject.tag == "EndArea")
        {
            print("ENDAREA");
        }
    }
    public IEnumerator Death()
    {
        GameObject ex = Instantiate(deathAnimation);
        deathAnimation.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        yield return new WaitForSeconds(1);
        playerTransform.position = startPos;
        yield return new WaitForSeconds(1);
        Destroy(ex);

    }
    private IEnumerator GoToEndArea()
    {
        yield return new WaitForSeconds(2);

        target = GameObject.FindGameObjectWithTag("EndArea");
        agent.SetDestination(target.transform.position);
    }
}
