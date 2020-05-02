using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrapController : MonoBehaviour
{
    public bool Fire;
    public GameObject FireSpout;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Player")
        {
            Fire = true;
            Vector3 FirePoint = transform.position;
            FirePoint.y += 1;
            GameObject.Instantiate(FireSpout, FirePoint, transform.rotation);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Player")
        {
            Fire = false;
            Debug.Log("Turned off fire trap");
        }
    }
}
