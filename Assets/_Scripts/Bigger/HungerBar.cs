using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerBar : MonoBehaviour
{
    [SerializeField] public float hungerSpeed = 0.1f;
    [SerializeField] [Range(0, 100)] public float hunger = 100.0f;
    [SerializeField] private float food01 = 5.0f;
    private float hungerMax = 100.0f;

    void Start()
    {

    }

    void Update()
    {

        TriggerEating();
        HungerConstantDecreasing();
        Debug.Log(hunger);
        HungerLinkToUIBar();
    }

    private void HungerLinkToUIBar()
    {
        transform.localScale = new Vector3(hunger / hungerMax, 1.0f, 1.0f);
    }

    private void HungerConstantDecreasing()
    {
        hunger -= Time.deltaTime * hungerSpeed;
    }

    private void TriggerEating()
    {
        if (hunger >= 100.0f)
        {
            hunger = 100.0f;
        }

        if (hunger <= 0.0f)
        {
            hunger = 0.0f;
        }

        else
        {
            HungerValueAdd();
        }
    }

    private void HungerValueAdd()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddHungerValue();
        }
    }

    private void AddHungerValue()
    {
        hunger += food01;
    }

}
