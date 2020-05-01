using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullControl : MonoBehaviour
{
    public float TimerBullet;
    public float MaxTimerBullet;
    public GameObject FireBall;

    public bool Firing = false;

    public Animator animator;

    public float TimerMin = 5f;
    public float TimerMax = 25f;

    // Start is called before the first frame update

    void EnemyFire()
    {
        float y = 1.25f;
        Vector3 SpawnPoint = transform.position;
        SpawnPoint.y -= (FireBall.GetComponent<Renderer>().bounds.size.y / 2) + (GetComponent<Renderer>().bounds.size.y / 2);
        SpawnPoint.y += 1;
        SpawnPoint.z = 0;
        GameObject.Instantiate(FireBall, SpawnPoint, transform.rotation);
        FireBall.GetComponent<FireballControl>().YSpeed = 0;
        FireBall.GetComponent<FireballControl>().XSpeed = 2f;
        GameObject.Instantiate(FireBall, SpawnPoint, transform.rotation);
        FireBall.GetComponent<FireballControl>().YSpeed = 0;
        FireBall.GetComponent<FireballControl>().XSpeed = -2f;
        GameObject.Instantiate(FireBall, SpawnPoint, transform.rotation);
        FireBall.GetComponent<FireballControl>().YSpeed = 2f;
        FireBall.GetComponent<FireballControl>().XSpeed = 2f;
        GameObject.Instantiate(FireBall, SpawnPoint, transform.rotation);
        FireBall.GetComponent<FireballControl>().YSpeed = 2f;
        FireBall.GetComponent<FireballControl>().XSpeed = -2f;

    }
    void Start()
    {
        TimerBullet = 0;
        MaxTimerBullet = Random.Range(TimerMin, TimerMax);
    }

    // Update is called once per frame
    void Update()
    {
        if (Firing == true)
        {
            animator.SetBool("IsFiring", true);
            StartCoroutine("FireBullet");
        }
        else
        {
            animator.SetBool("IsFiring", false);
        }
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    StartCoroutine("FireBullet");
    //    Firing = true;
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Player")
        {
            EnemyFire();
            Firing = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Player")
        {
            StartCoroutine("FireBullet");
            Firing = false;
        }
    }
    IEnumerator FireBullet()
    {
        if (TimerBullet >= MaxTimerBullet)
        {
            //spawn enemy
            EnemyFire();
            TimerBullet = 0;
            MaxTimerBullet = Random.Range(TimerMin, TimerMax);
        }
        TimerBullet += 0.1f;
        yield return new WaitForSeconds(0.1f);
    }
}
