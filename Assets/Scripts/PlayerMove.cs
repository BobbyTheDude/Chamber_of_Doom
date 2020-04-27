using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;

    public float RunSpeed = 25f;
    bool JumpFlag = false;
    bool Jump = false;

    public bool HasJumpPotion = false;
    public bool HasSpeedPotion = false;
    public int PotionModAmount = 0;

    public float PotionTimeMax = 10f;
    public float PotionTimeCur = 0f;

    public AudioClip JumpClip;

    float HorizontalMove = 0f;
    //void Start()
    //{
        
    //}

    void Update()
    {
        HorizontalMove = Input.GetAxisRaw("Horizontal") * RunSpeed;

        animator.SetFloat("Speed", Mathf.Abs(HorizontalMove));

        if (JumpFlag)
        {
            JumpFlag = false;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (animator.GetBool("IsJumping") == false)
            {
                AudioSource.PlayClipAtPoint(JumpClip, transform.position);
                Jump = true;
                animator.SetBool("IsJumping", true);
            }
        }
    }

    public void OnLanding()
    {
        Jump = false;
        animator.SetBool("IsJumping", false);
    }

    private void FixedUpdate()
    {

    if (HasJumpPotion && PotionTimeCur < PotionTimeMax)
        {
            controller.m_JumpForceMod = PotionModAmount;
            PotionTimeCur += Time.fixedDeltaTime;
        }
        else
        {
            PotionTimeCur = 0f;
            controller.m_JumpForceMod = 0;
            HasJumpPotion = false;
        }
        controller.Move(HorizontalMove * Time.fixedDeltaTime, false, Jump);

        if (Jump)
        {
            JumpFlag = true;
        }
    }
}
