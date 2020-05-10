using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudTrapController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Player")
        {
            collision.gameObject.GetComponent<PlayerMove>().RunSpeed = 5f;
            Debug.Log("He's slower now!");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Player")
        {
            collision.gameObject.GetComponent<PlayerMove>().RunSpeed = 25f;
        }
    }
}
