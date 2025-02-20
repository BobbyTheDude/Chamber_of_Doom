﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionController : MonoBehaviour
{
    public enum PotionType
    {
        Speed,
        Jump
    }

    public PotionType potionType;
    public int PotionModAmount = 0;

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            if (potionType == PotionType.Jump)
            {
                collision.gameObject.GetComponent<PlayerMove>().HasJumpPotion = true;
            }
            else if (potionType == PotionType.Speed)
            {
                collision.gameObject.GetComponent<PlayerMove>().HasSpeedPotion = true;
            }
            collision.gameObject.GetComponent<PlayerMove>().PotionModAmount = PotionModAmount;
            Destroy(this.gameObject);
        }
    }
}
