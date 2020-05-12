using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfToIdle : MonoBehaviour
{
    public GameObject Wolf;
    public bool Iscolliding = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Enemy")
        {
            Wolf.GetComponent<WolfControl>().Chasing = false;
            Iscolliding = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Enemy")
        {
            Iscolliding = false;
        }
    }
}
