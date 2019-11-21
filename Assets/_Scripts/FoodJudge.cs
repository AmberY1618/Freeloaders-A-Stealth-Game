using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodJudge : MonoBehaviour
{

	public Camera cam;
    public int PizzaPoints = 10;
	public int BurgerPoints = 20;
	public int CoffeePoints = 35;

	public float RetrieveDistance = 3.0f;

    public AudioClip FoodEatClip;
    AudioSource FoodEatEatAudioSource;
    public float FoodEatingVolume;


    //public CanvasGroup winningCanvasGroup;

    public GameObject winningPanel;


    private float m_Time;
    private float fadeDuration = 1.0f;

    void Start()
	{
        FoodEatEatAudioSource = GetComponent<AudioSource>();
	}

	void Update()
	{
        //if (Input.GetKeyDown(KeyCode.E))
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			RaycastHit hit;
			Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
			if (Physics.Raycast(ray, out hit, RetrieveDistance))
			{
				GameObject obj = hit.collider.gameObject;
                Debug.Log(obj.name);

				if (obj.tag == "Pizza")
				{
					obj.SetActive(false);
					GetComponent<PlayerStats>().Hunger += PizzaPoints;
					//print("Hunger value +" + PizzaPoints);


                    //Sound test

                    FoodEatEatAudioSource.PlayOneShot(FoodEatClip, FoodEatingVolume);

                    //Sound test


                }

				if (obj.tag == "Burger")
				{
					obj.SetActive(false);
					GetComponent<PlayerStats>().Hunger += BurgerPoints;
					print("Hunger value +" + BurgerPoints);

                    //Sound test

                    FoodEatEatAudioSource.PlayOneShot(FoodEatClip, FoodEatingVolume);

                    //Sound test


                }

                if (obj.tag == "Coffee")
				{
					obj.SetActive(false);
					GetComponent<PlayerStats>().Hunger += CoffeePoints;
					print("Hunger value +" + CoffeePoints);

                    //Sound test

                    FoodEatEatAudioSource.PlayOneShot(FoodEatClip, FoodEatingVolume);

                    //Sound test

                }



                if (obj.tag == "Treasure")
                {
                    obj.SetActive(false);

                    winningPanel.SetActive(true);



                    m_Time += Time.deltaTime;



                    //Image img = winningPanel.GetComponent<Image>();
                   // img.color.a = m_Time / fadeDuration;
                       // alpha = m_Time / fadeDuration;
                }
            }
		}
	}





}
