using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrapFlamesController : MonoBehaviour
{
    public LivesManager LivesManagerScript;

    //Access LivesManager if player gets killed
    void Start()
    {
        LivesManagerScript = GameObject.Find("LivesManager").GetComponent<LivesManager>();
        //Debug.Log("firetrap turned on");
    }
    /*
    //Checks to see if FireTrap turns off
    void Update()
    {
        if (ParentTrap.GetComponent<FireTrapController>().Fire == false)
        {
            Debug.Log("Why u delete");
            GameObject.Destroy(this.gameObject);
        }
    }    */

    //Flames kill player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject.Destroy(collision.gameObject);
            LivesManagerScript.GetComponent<LivesManager>().Dead = true;
        }
    }
}
