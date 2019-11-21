
//WITH STEVE



using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
using System;
using Random = UnityEngine.Random;
public class AIPatrolwithChasing : MonoBehaviour
{
    public Transform[] points;
    private int destPoint = 0;
    private Animator anim;
    private NavMeshAgent agent;
    private float timer = 3f;
    Vector2 smoothDeltaPosition = Vector2.zero;
    Vector2 velocity = Vector2.zero;



    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();    
        agent.autoBraking = false;
        agent.updatePosition = false;

        // GotoNextPoint();

    }


    void GotoNextPoint()
    {
        
        if (points.Length == 0)    // Returns if no points have been set up
            return;             

        agent.destination = points[destPoint].position;  // Choose the next point in the array as the destination,
        destPoint = (destPoint + 1) % points.Length;    // cycling to the start if necessary.
    }


    void Update()
    {
        if (timer < 0)
        {
            timer = UnityEngine.Random.Range(3, 8);
            StartCoroutine(wait(UnityEngine.Random.Range(1, 3)));
        }

        else
        {
            timer -= Time.deltaTime;
        }
        //Debug.Log(“timer is now” + timer);
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();


        Vector3 worldDeltaPosition = agent.nextPosition - transform.position;


        //Map ‘worldDeltaPosition’ to local space
        float dx = Vector3.Dot(transform.right, worldDeltaPosition);
        float dy = Vector3.Dot(transform.forward, worldDeltaPosition);
        Vector2 deltaPosition = new Vector2(dx, dy);


        //Low-pass filter the deltaMove
        float smooth = Mathf.Min(1.0f, Time.deltaTime / 0.15f);
        smoothDeltaPosition = Vector2.Lerp(smoothDeltaPosition, deltaPosition, smooth);
        //Update velocity if time advances
        if (Time.deltaTime > 1e-5f)
            velocity = smoothDeltaPosition / Time.deltaTime;
        bool shouldMove = velocity.magnitude > 0.5f && agent.remainingDistance > agent.radius;
        //Update animation parameters
        anim.SetBool("isWalking", shouldMove);
        anim.SetFloat("velx", velocity.x);
        anim.SetFloat("vely", velocity.y);
    }
    private void OnAnimatorMove()
    {
        //Update position to agent position
        transform.position = agent.nextPosition;
    }



    //tell the program to wait for i sec
    IEnumerator wait(float i)
    {
        agent.speed = 0;
        yield return new WaitForSeconds(i);
        //Debug.Log(“Waiting for ” + i + ” seconds.“);
        agent.speed = 1;
    }
}
