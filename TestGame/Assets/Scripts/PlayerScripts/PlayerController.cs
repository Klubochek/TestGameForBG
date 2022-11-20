using DG.Tweening;
using System;
using System.Collections;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isActiveShield = false;
    public Vector3 startPos = new Vector3(-2.5f, 10 , -2.5f);
    public Vector3[] temppos;
    public Vector3[] playerRoad;
    public GameObject target;
    private Rigidbody rb;
    private Tween move;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(GoToEndArea());
    }
    public void SetRoad()
    {
        temppos = PlayerRoad.Instance.road.ToArray();
        Array.Reverse(temppos);
        target = GameObject.FindGameObjectWithTag("EndArea");
        playerRoad = new Vector3[temppos.Length];
        for (int i = 0; i < temppos.Length; i++)
        {
            playerRoad[i] = new Vector3(-2.5f + temppos[i].x * 5, 3, -2.5f + temppos[i].y * 5);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DeathArea" && !isActiveShield)
        {
            print("DEATHAREA");
            DOTween.KillAll();
            StartCoroutine(PlayerAnimation.Instance.Death(transform));
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
        rb.DOMove(startPos, 0.1f);
        yield return new WaitForSeconds(2);
        move=transform.DOPath(playerRoad, 180, PathType.Linear, PathMode.Full3D);
    }
}
