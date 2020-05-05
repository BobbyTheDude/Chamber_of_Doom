using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallZone : MonoBehaviour
{
    public LivesManager LivesManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        LivesManagerScript = GameObject.Find("LivesManager").GetComponent<LivesManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "Player")
        {
            GameObject.Destroy(other.gameObject);
            LivesManagerScript.GetComponent<LivesManager>().Dead = true;
        }
    }
}
