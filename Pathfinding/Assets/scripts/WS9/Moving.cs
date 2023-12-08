using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Moving : MonoBehaviour
{
    //[SerializeField] float speed = 5f;
    //[SerializeField] float factor = 1.5f;
    [SerializeField] public float timeToStop = 0.5f;
    [SerializeField] public float speedIncreasePerPress = 1.0f;
    [SerializeField] public float maxSpeed = 2000.0f;

    [SerializeField] float lastpresstime = 0.0f;
    [SerializeField] float curspeed = 0.0f;
    [SerializeField] float stopTimer = 0.0f;
    //[SerializeField] int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            curspeed += speedIncreasePerPress;
            curspeed = Mathf.Clamp(curspeed, 0.0f, maxSpeed);
            lastpresstime = 0.0f;
            stopTimer = timeToStop; // reset the timer when a button is pressed
        }
        lastpresstime += UnityEngine.Time.deltaTime;
        stopTimer -= UnityEngine.Time.deltaTime;
        if (stopTimer <= 0.0f) {
            curspeed = 0.0f; // stop moving if time is up
        }
        transform.Translate(Vector3.forward * curspeed * UnityEngine.Time.deltaTime);
    }

    
    
}
