using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrapController : MonoBehaviour
{
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Player")
        {
            animator.SetBool("FireOn", true);
            Debug.Log("fireon");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Player")
        {
            animator.SetBool("FireOn", false);
            Debug.Log("Fireoff");
        }
    }
}
