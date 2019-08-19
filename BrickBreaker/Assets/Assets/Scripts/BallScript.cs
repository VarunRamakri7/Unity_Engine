using UnityEngine;
using System.Collections;

/**
 *	BrickBreaker Excercise - Ball Script
 *	
 *	By, Varun Ramakrishnan, 25/6/18
 */

public class BallScript : MonoBehaviour
{
	// Variable to hold ball's information
	public float ballInitialSpeed = 600f;
	public float speed;
	private Rigidbody rb;
	private bool isBallInPlay;

	// Function to get the rigid body component
	void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	// Function to update the screen with the ball's movement
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && isBallInPlay == false)
		{
			transform.parent = null;
			isBallInPlay = true;
			rb.isKinematic = false;
			rb.AddForce(new Vector3(0, ballInitialSpeed, ballInitialSpeed));
		}
	}

	private void FixedUpdate()
	{
		rb.velocity = speed * rb.velocity.normalized * Time.fixedDeltaTime;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag.Equals("SpecialBrick"))
		{
			Game.instance.HitSpecialBrick();
			SoundController.instance.BrickHitSound();
		}

		if (collision.gameObject.tag.Contains("Brick")) SoundController.instance.BrickHitSound();
		else if (collision.gameObject.tag.Equals("Wall")) SoundController.instance.WallHitSound();
		else if (collision.gameObject.tag.Equals("Paddle")) SoundController.instance.PaddleHitSound();
	}
}