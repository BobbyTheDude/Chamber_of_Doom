using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrapFlamesController : MonoBehaviour
{
    public bool isOn;
    private GameObject TrapParent;
    public LivesManager LivesManagerScript;

    //Access LivesManager if player gets killed
    void Start()
    {
        LivesManagerScript = GameObject.Find("LivesManager").GetComponent<LivesManager>();
        Debug.Log("firetrap turned on");
    }
    /*
    //Checks to see if FireTrap turns f
    void Update()
    {
        if (isOn == false)
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    //Trap alerts if player is in range to turn fire trap on
    public FireTrapFlamesController (bool turnOn, GameObject Trap)
    {
        isOn = turnOn;
        TrapParent = Trap;
    }
    */

    //Flames kill player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject.Destroy(collision.gameObject);
            LivesManagerScript.GetComponent<LivesManager>().Dead = true;
        }
    }
}
