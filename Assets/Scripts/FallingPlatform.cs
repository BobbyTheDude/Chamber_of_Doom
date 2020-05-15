using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
	Rigidbody2D rb;
	private Vector2 originalPosition;
	public float resetPositionAfterSeconds = 2f;
	public GameObject NewPlatform;


	// Use this for initialization
	void Start()
	{
		rb = gameObject.GetComponent<Rigidbody2D>();
		originalPosition = this.gameObject.transform.position;
		rb.isKinematic = true;
	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			rb.isKinematic = false;
			rb.gravityScale = .05f;
			StartCoroutine(Delay(resetPositionAfterSeconds));

		}
	}

	void ResetPlatform()
	{
		rb.isKinematic = true;
		rb.velocity = Vector2.zero;
		rb.angularVelocity = 0f;
		transform.rotation = Quaternion.identity;
		//Turn Gravity Off
		rb.gravityScale = 0f;
		//Move Platform back to original position
		this.gameObject.transform.position = originalPosition;
	}

	IEnumerator Delay(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		ResetPlatform();
	}
}
