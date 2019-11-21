using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//steve code


public class enemymovement : MonoBehaviour
{

    void Start()
    {

    }


    private void OnTriggerEnter(Collider other)
	{
		//if (other.tag == "Player")
		//{
		// Destroy(Player);
		//}
	}

	public Transform Player;
	public float MoveSpeed = 2;
	public int MaxDist = 10;
	public int MinDist = 5;


	void Update()
	{

		if (Vector3.Distance(transform.position, Player.position) <= MinDist)
		{

			transform.LookAt(Player);
			transform.position += transform.forward * MoveSpeed * Time.deltaTime;
		}

		if (Vector3.Distance(transform.position, Player.position) >= MaxDist)
		{


		}
	}
}