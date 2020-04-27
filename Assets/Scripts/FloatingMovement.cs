using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingMovement : MonoBehaviour
{
    public float FloatingTimer = 0f;
    public float FloatingMax = 1f;
    public float Floatingdir = .01f;

    private void FixedUpdate()
    {
        if (FloatingTimer < FloatingMax)
        {
            transform.position = new Vector2(transform.position.x, 
                transform.position.y + (Time.fixedDeltaTime * Floatingdir));
            FloatingTimer += Time.fixedDeltaTime;
        }
        else
        {
            Floatingdir *= -1;
            FloatingTimer = 0f;
        }
    }
}
