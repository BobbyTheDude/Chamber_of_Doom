﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKill : MonoBehaviour
{
    public GameObject Enemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
      void OnCollisionEnter2D(Collision2D other)
        {
            if (LayerMask.LayerToName(other.gameObject.layer) == "Player")
            {
                Destroy(Enemy);
            }
        }
    
}
