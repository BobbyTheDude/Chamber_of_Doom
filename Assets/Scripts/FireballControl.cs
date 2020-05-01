﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FireballControl : MonoBehaviour
{
    public float XSpeed;
    public float YSpeed;
    private Rigidbody2D rb;

    void Start()
    {
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
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject.Destroy(this.gameObject);
            GameObject.Destroy(collision.gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }
}
