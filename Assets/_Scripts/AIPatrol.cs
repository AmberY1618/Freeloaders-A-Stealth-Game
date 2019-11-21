// AIPatrol.cs
using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
using System;
using Random = UnityEngine.Random;
public class AIPatrol : MonoBehaviour
{
    public Transform[] points;
    private int destPoint = 0;
    private Animator anim;
    private NavMeshAgent agent;
    private float timer = 3f;
    Vector2 smoothDeltaPosition = Vector2.zero;
    Vector2 velocity = Vector2.zero;


    public Transform Player;
    public float MoveSpeed = 2;
    public int MaxDist = 10;
    public int MinDist = 5;



    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();    
        agent.autoBraking = false;
        agent.updatePosition = false;

        //GotoNextPoint();
    }


    void GotoNextPoint()
    {
        
        if (points.Length == 0)    // Returns if no points have been set up
            return;                 // Set the agent to go to the currently selected destination.


         // Choose the next point in the array as the destination,

           // cycling to the start if necessary.


        if (Vector3.Distance(transform.position, Player.position) <= MinDist)
        {

            //transform.LookAt(Player);
            agent.destination = Player.position;
        }
        if (Vector3.Distance(transform.position, Player.position) >= MaxDist)
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                agent.destination = points[destPoint].position;
                destPoint = (destPoint + 1) % points.Length;
            }
                
        }
        
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
        //if (!agent.pathPending && agent.remainingDistance < 0.5f)
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




    void triggerchasing()
    {
        for (int i = 0; i < points.Length; i++)
        {
            if (points.Length == 0)    // Returns if no points have been set up
                return;







        }


    }
}
