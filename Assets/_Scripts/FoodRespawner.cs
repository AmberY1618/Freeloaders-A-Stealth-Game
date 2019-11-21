using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodRespawner : MonoBehaviour
{
	public GameObject RespawnedPizza;
	public GameObject RespawnedCoffee;
	public GameObject RespawnedBurger;

    public Transform[] Position;

    public float CoffeeProb = 40 / 100f;  //0.4
    public float BurgerProb = 30 / 100f;  //0.3
    public float PizzaProb = 10/100f;     //0.1
    public float NothingProb = 20/100f;   //0.2

    private float RandomValue;

    private int i=0;

    //Vector3 originalPoint = Vector3

	void Start()
    {
        //RandomValueGeneration();

        Position = GetComponentsInChildren<Transform>();

        foreach (Transform child in Position)
        {
            if (child.position != Vector3.zero)
            {
                RandomValue = Random.value;
                DetermineFoodGenerate(child.position);
            }
        }
        Debug.Log(i);
    }

    /*
    private void RandomValueGeneration()
    {
        //RandomValue = Random.value;
        Debug.Log(RandomValue);
    }
    */

    private void DetermineFoodGenerate(Vector3 temp)
    {
        if (RandomValue < CoffeeProb)           // 0 - 0.4    40%     COFFEE
        {
            //Debug.Log("Coffee Generated");
            Instantiate(RespawnedCoffee, temp, Quaternion.identity);
            i = i + 1;

        }

        if (RandomValue > CoffeeProb && RandomValue < CoffeeProb + BurgerProb)    //  0.4 - 0.7  30%    BURGER
        {
            //Debug.Log("Burger Generated");
            Instantiate(RespawnedBurger, temp, Quaternion.identity);
        }

        if (RandomValue > CoffeeProb + BurgerProb && RandomValue < CoffeeProb + BurgerProb + PizzaProb)  // 0.7 - 0.8  10%  PIZZA
        {
            //Debug.Log("Pizza Generated");
            Instantiate(RespawnedPizza, temp, Quaternion.identity);
        }

        if (RandomValue > 1 - NothingProb)    //    0.9 - 1.0   20%   NOTHING
        {
            //Debug.Log("Nothing is Generated");
        }
    }


    void Update()
    {

    }
}
