using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{

	public float movementSpeed = 10f;
	Rigidbody2D rb;
	float movement = 0f;
	public bool m_FacingRight = true;

	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		movement = Input.GetAxis("Horizontal");
		
		if (transform.position.x >= 3.8 || transform.position.x <= -3.8)
		{
			transform.position = new Vector3(transform.position.x * -0.9f, transform.position.y, 0);
		}

		if(movement < 0 && m_FacingRight) { Flip(); }
		else if (movement > 0 && !m_FacingRight) { Flip(); }
	}

	void FixedUpdate()
	{
		Vector2 velocity = rb.velocity;
		velocity.x = movement * movementSpeed;
		rb.velocity = velocity;
	}

	public void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}