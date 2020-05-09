using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    public GameObject DoorToControl;
    //public AudioClip DoorOpening;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Player")
        {
            Destroy(DoorToControl);
            //AudioSource.PlayClipAtPoint(DoorOpening, transform.position);
        }
    }
}
