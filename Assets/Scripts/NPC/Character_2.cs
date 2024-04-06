using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using BNG;
using UnityEngine.AI;

public class Character_2 : MonoBehaviour
{
    public FacePlayerNormal facePlayer;
    public float WalkValue;
    public float StopValue;
    public NavMeshAgent _agent;
    public Animator _anim;
    private Transform target;
    public Transform targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        target = transform;
    }

    // Update is called once per frame
    void Update()
    {
        _agent.SetDestination(target.transform.position);


        if (Vector3.Distance(transform.position, target.position) > WalkValue)
        {
            //Debug.Log("I am walking");
            _agent.isStopped = false;
            _anim.Play("Walk");
            facePlayer.enabled = false;
        }

        if (Vector3.Distance(transform.position, target.position) < StopValue)
        {
            Debug.Log("I am stop");
            _agent.isStopped = true;
            _anim.Play("Idle");

            facePlayer.enabled = true;
        }
    }

    public void runToPosition()
    {
        target = targetPosition;
    }
}
