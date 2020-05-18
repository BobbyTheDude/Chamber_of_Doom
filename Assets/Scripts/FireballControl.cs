using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FireballControl : MonoBehaviour
{
    public float XSpeed;
    public float YSpeed;
    private Rigidbody2D rb;
    public LivesManager LivesManagerScript;
    public GameObject Skull;

    void Start()
    {
        LivesManagerScript = GameObject.Find("LivesManager").GetComponent<LivesManager>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(XSpeed, YSpeed);
    }

    void Update()
    {
        if (Camera.main.WorldToViewportPoint(transform.position).y > 1 || Camera.main.WorldToViewportPoint(transform.position).y < 0 || 
            Camera.main.WorldToViewportPoint(transform.position).x < 0 || Camera.main.WorldToViewportPoint(transform.position).x > 1)
        {
            Destroy(this.gameObject);
        }
        //float dist = Vector3.Distance(Skull.transform.position, this.gameObject.transform.position);
        //Debug.Log(dist.ToString());
        //if (Mathf.Abs(dist) >= 40.1f)
        //{
        //    Destroy(this.gameObject);
        //}
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject.Destroy(this.gameObject);
            GameObject.Destroy(collision.gameObject);
            LivesManagerScript.GetComponent<LivesManager>().Dead = true;
        }
    }
}
