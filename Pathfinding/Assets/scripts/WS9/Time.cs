using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time : MonoBehaviour
{
    
    [SerializeField]public int minutes;
    [SerializeField]public int hours;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("its started");
        minutes = 0;
        hours = 8;
        InvokeRepeating("Timer", 1.0f, 15.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (minutes >= 60)
        {
            hours++;
            minutes = 0;
        }

        if (hours == 12)
        {
            //call day end func
        }
    }

    void Timer()
    {
        Debug.Log(hours);
        Debug.Log(minutes);
        minutes+=15;
    }
}
