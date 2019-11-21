using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerStats : MonoBehaviour
{

    public GameEnding gameEnding;

    //----------------------------------original Values
	public float Hunger = 100f;



    //----------------------------------Depleting factors
    public static float hungerOverTime;

    //----------------------------------Slider Bar
    public Slider HungerBar;

    //----------------------------------HungerValue UItext
    public Text hungerValue;

    //------------------------------------------------------Other depleting factors
    public float runSpeedCap = 1.0f; //if running, stamina drops



    //------------------------------------------------------PostProcessing
    [SerializeField] private PostProcessVolume blurVolume;
    public float blurVolumeFocalLength = 140.0f;
    public float backToOriginalFocalLength = 10.0f;
    DepthOfField depthOfField;


    //----------------------------Other naming
    Rigidbody myBody;
    public float newRunningSpeed = 2.0f;
    public float regularRunningSpeed = 4.0f;
    public float seperationValue = 20.0f;




    void Start()
    {
        SetMaxValue();

        GetRigidbodyComponent();

        PPgetDepthOfFieldSetting();
    }

    private void SetMaxValue()
    {
        HungerBar.maxValue = 100;
    }

    private void PPgetDepthOfFieldSetting()
    {
        blurVolume.profile.TryGetSettings(out depthOfField);
    }

    private void GetRigidbodyComponent()
    {
        myBody = GetComponent<Rigidbody>();
    }



    //----------------------------//--------------UPDATE--------------//----------------------------

    void Update()
    {
        CalculateValues();
        HungerValueEffectReactor();
    }

    private void HungerValueEffectReactor()
    {
        if (Hunger <= seperationValue)
        {
            hungerValue.GetComponent<Text>().color = Color.red; //Change color of HungerValue UI to red

            blurVolume.profile.TryGetSettings(out depthOfField); //Get depth of field value

            depthOfField.enabled.value = true;

            depthOfField.focalLength.value = blurVolumeFocalLength;  //change value to certain value

            gameObject.GetComponent<FirstPersonController>().m_RunSpeed = newRunningSpeed;


        }

        if (Hunger > seperationValue)
        {
            hungerValue.GetComponent<Text>().color = Color.white; //Change color of HungerValue UI back to white
            depthOfField.focalLength.value = backToOriginalFocalLength;

            gameObject.GetComponent<FirstPersonController>().m_RunSpeed = regularRunningSpeed;



        }
    }

    private void CalculateValues()
    {

        Hunger -= hungerOverTime * Time.deltaTime;

        if(Hunger <= 0)
        {
            gameEnding.CaughtPlayer();
        }

        UIupdater();
    }

    private void UIupdater()
    {
        //giving boundaries
        Hunger = Mathf.Clamp(Hunger, 0, 100f);


        HungerBar.value = Hunger;
        hungerValue.text = " " + Mathf.RoundToInt(Hunger);

    }

}
