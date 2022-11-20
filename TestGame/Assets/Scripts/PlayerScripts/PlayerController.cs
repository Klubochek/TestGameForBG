using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public bool isActiveShield = false;
    private Vector3 startPos = new Vector3(-2.5f, 3 , -2.5f);
    private GameObject target;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.Warp(startPos);
        StartCoroutine(GoToEndArea());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DeathArea" && !isActiveShield)
        {
            print("DEATHAREA");
            StartCoroutine(PlayerAnimation.Instance.Death(transform));
            agent.Warp(startPos);
            StartCoroutine(GoToEndArea());
        }
        if (other.gameObject.tag == "EndArea")
        {
            print("ENDAREA");
            StartCoroutine(PlayerAnimation.Instance.Win(target.transform));
        }
    }


    private IEnumerator GoToEndArea()
    {
        yield return new WaitForSeconds(2);
        target = GameObject.FindGameObjectWithTag("EndArea");
        agent.SetDestination(target.transform.position);
    }
}
