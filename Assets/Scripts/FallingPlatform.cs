using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
	Rigidbody2D rb;
	private Vector3 originalPosition;
	public float resetPositionAfterSeconds = 10f;

	// Use this for initialization
	void Start()
	{
		rb = gameObject.GetComponent<Rigidbody2D>();
		originalPosition = this.gameObject.transform.position;
	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			rb.gravityScale = .5f;
			StartCoroutine(Delay(resetPositionAfterSeconds));
		}
	}

	void ResetPlatform()
	{
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
