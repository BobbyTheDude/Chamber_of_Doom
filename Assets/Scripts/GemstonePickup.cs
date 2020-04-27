using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemstonePickup : MonoBehaviour
{
    public AudioClip PickupClip;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Player")
        {
            AudioSource.PlayClipAtPoint(PickupClip, transform.position);
            Destroy(this.gameObject);

        }
    }
}
