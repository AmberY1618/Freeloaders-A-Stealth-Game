using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockAnimator : MonoBehaviour
{
    private const float
        hoursToDegrees = 360f / 12f,
        minutesToDegrees = 360f / 60f,
        secondsToDegrees = 360f / 60f;

    public Transform hours, minutes, seconds;



    void Update()
    {
        /*
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (Time.timeScale == 24.0f)
                        Time.timeScale = 0.7f;
                    else
                        Time.timeScale = 24.0f;
                    // Adjust fixed delta time according to timescale
                    // The fixed delta time will now be 0.02 frames per real-time second
                    Time.fixedDeltaTime = 0.24f * Time.timeScale;
                    this is working */


        System.DateTime time = System.DateTime.Now;
        hours.localRotation = Quaternion.Euler(0f, 0f, time.Hour * -hoursToDegrees);
        minutes.localRotation = Quaternion.Euler(0f, 0f, time.Minute * -minutesToDegrees);
        seconds.localRotation = Quaternion.Euler(0f, 0f, time.Second * -secondsToDegrees);
    }
}