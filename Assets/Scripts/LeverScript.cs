using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    public GameObject DoorToControl;
    public AudioClip DoorOpening;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("regular collision works");
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Player")
        {
            Destroy(DoorToControl);
            AudioSource.PlayClipAtPoint(DoorOpening, transform.position);
            Debug.Log("player Collision lever works");
        }
    }
}
