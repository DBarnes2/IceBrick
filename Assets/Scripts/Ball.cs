using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public float ballInitialVelocity = 600f;
	public float verticalBounceLimit;
	public float horizontalBounceLimit;

	private Rigidbody2D rb;
	private bool ballInPlay;
	private Vector3 tipperForce;
	private Vector3 lastPosition;

	void Awake () {
		rb = GetComponent<Rigidbody2D>();
		lastPosition = transform.position;
	}

	void Update () 
	{
		if (Input.GetButtonDown("Fire1") && ballInPlay == false)
		{
			transform.parent = null;
			ballInPlay = true;
			// Random amount to tip the ball if it gets stuck
			tipperForce = new Vector3(0f, Random.Range(0, ballInitialVelocity), 0f);
			rb.isKinematic = false;
			rb.AddForce(new Vector3(ballInitialVelocity, ballInitialVelocity, 0));
		}
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		/* This condition ensures that the ball is never bouncing back and forth
		 * across the walls for a boringly long period of time. This effect only
		 * comes into play when the horizontal distance between bounces is large
		 */
		if (Mathf.Abs(transform.position.y-lastPosition.y)
				<= verticalBounceLimit
				&& Mathf.Abs(transform.position.x-lastPosition.x)
				>= horizontalBounceLimit)
		{
			int tipperDirection;
			if (transform.position.y > lastPosition.y)
				tipperDirection = 1; // moving up
			else
				tipperDirection = -1; // moving down
			rb.AddForce(tipperForce * tipperDirection);
		}
		lastPosition = transform.position;
	}

	// Getter function for ball being in play
	public bool IsInPlay()
	{
		return ballInPlay;
	}
}
