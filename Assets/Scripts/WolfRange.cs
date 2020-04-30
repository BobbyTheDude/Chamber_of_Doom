using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfRange: MonoBehaviour
{
    public bool Chasing = false;
    public Transform RealWaypoint;
    public GameObject Waypoint2;
    public Transform PlayerTransform;
    public GameObject Wolf;
    public Transform WolfTransform;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Player")
        {
            Wolf.GetComponent<WolfControl>().waypoint1 = PlayerTransform;
            Wolf.GetComponent<WolfControl>().Chasing = true;
            Debug.Log("enter works");
            Waypoint2.SetActive(false);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Player")
        {
            Waypoint2.SetActive(true);
            Wolf.GetComponent<WolfControl>().SwitchWaypoint();
            Wolf.GetComponent<WolfControl>().waypoint1 = RealWaypoint;
            if (Waypoint2.GetComponent<WolfToIdle>().Iscolliding == false)
            {
                Vector3 theScale = Wolf.transform.localScale;
                theScale.x *= -1;
                Wolf.transform.localScale = theScale;
            }
        }
    }
}
