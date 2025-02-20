﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GargoyleControl : MonoBehaviour
{
    //Game Manager
    //GameManager gm;
    /// SOUNDS
    //private AudioSource source;
    //public AudioClip enemyDeathSound;
    //public AudioClip enemyHit;
    private int currentWaypoint = 1;
    public Transform waypoint1;
    public Transform waypoint2;
    public LivesManager LivesManagerScript;

    //https://docs.unity3d.com/ScriptReference/Vector3.Lerp.html
    // Transforms to act as start and end markers for the journey.
    private Transform startMarker;
    private Transform endMarker;

    // Movement speed in units per second.
    public float speed = 1.0F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    // Use this for initialization
    void Start()
    {
        //source = GetComponent<AudioSource>();
        //gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        LivesManagerScript = GameObject.Find("LivesManager").GetComponent<LivesManager>();
    }

    private void Update()
    {
        MoveTo();
    }

    void StartTraveling()
    {
        startMarker = transform;
        // Keep a note of the time the movement started.
        startTime = Time.time;

        // Calculate the journey length.
        journeyLength = Vector3.Distance(transform.position, endMarker.position);
    }

    // Move to the target end position.
    void MoveTo()
    {
        if (endMarker != null)
        {
            // Distance moved equals elapsed time times speed..
            float distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed equals current distance divided by total distance.
            float fractionOfJourney = distCovered / journeyLength;

            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fractionOfJourney);
            //Get the distance to see if we're close enough to finish our patrol (within .1 units)
            float distanceToEnd = Vector2.Distance(transform.position, endMarker.position);

            if (distanceToEnd <= 0.1f)
            {
                SwitchWaypoint();
            }
        }
        else
        {
            SwitchWaypoint();
        }
    }

    void SwitchWaypoint()
    {
        if (currentWaypoint == 1)
        {
            currentWaypoint = 2;
            endMarker = waypoint2;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
        else
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
            currentWaypoint = 1;
            endMarker = waypoint1;
            endMarker = waypoint1;
        }
        StartTraveling();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "Player")
        {
            GameObject.Destroy(other.gameObject);
            LivesManagerScript.GetComponent<LivesManager>().Dead = true;
        }
    }
}
