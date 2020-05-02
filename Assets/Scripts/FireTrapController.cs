using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrapController : MonoBehaviour
{
    public bool Fire = false;
    public GameObject FireSpout;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Player")
        {
            Fire = true;
            FireSpout.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Player")
        {
            Fire = false;
            FireSpout.SetActive(false);
        }
    }
}
