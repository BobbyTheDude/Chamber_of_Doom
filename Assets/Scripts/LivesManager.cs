using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LivesManager : MonoBehaviour
{
    public GameObject PlayerInst;
    public bool Dead = false;
    public int Lives = 3;
    public Transform RespawnPoint;
    public GameObject Camera;
    public GameObject HUD;

    public void UpdateLivesText()
    {
        //GetComponent<Text>().Lives= "Lives: " + Lives;
    }
    //public void Respawn()
    //{
    //    GameObject.Instantiate(PlayerInst, RespawnPoint);
    //}

    //void Start()
    //{

    //}

    //// Update is called once per frame
    void Update()
    {
        if (Dead == true)
        {
            Lives -= 1;
            GameObject NewPlayer = GameObject.Instantiate(PlayerInst, RespawnPoint.transform.position, RespawnPoint.transform.rotation);
            Camera.GetComponent<CameraFollow>().FollowTransform = NewPlayer.transform;
            
            HUD.GetComponent<Text>().text = "Lives: " + Lives;
            Dead = false;
        }
        if (Lives == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
