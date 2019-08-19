using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 *	BrickBreaker Excercise - Paddle Script
 *	
 *	By, Varun Ramakrishnan, 25/6/18
 */

// Class to control paddle's movements
public class PaddleScript : MonoBehaviour
{
	// Variable that controls paddle
	public float speedPaddle = 1f;
	private Vector3 paddlePosition = new Vector3(-5.12f, -9.5f, -5.51f);
	public int numGrows = 0;

	private const int MAX_GROWS = 5;

	// Update's paddle's position as player plays game
	void Update()
	{
		// Variable that update's paddle's horizontal movement
		float zPosition = transform.position.z + (Input.GetAxis("Horizontal") * speedPaddle);
		Vector3 paddleLength = transform.localScale;

		paddlePosition = new Vector3(-5.12f, -9.5f, Mathf.Clamp(zPosition, -8.66f + paddleLength.z / 2, -2.6f - paddleLength.z / 2));

		transform.position = paddlePosition;

		GrowUp();
		SpeedUp();
	}

	// Function to increase length of paddle
	private void GrowUp()
	{
		Vector3 paddleLength = transform.localScale;

		if (Game.instance.brokenBricks == 3 && paddleLength.z < 5f && numGrows < MAX_GROWS)
		{
			StartCoroutine(GradualGrow());

			numGrows++;

			Game.instance.brokenBricks = 0;
		}
	}

	// Function to increase the speed of the paddle
	private void SpeedUp()
	{
		if (Game.instance.lives % 4 == 0) speedPaddle += 0.002f;
	}

	// Coroutine to show gradual growth of length
	private IEnumerator GradualGrow()
	{
		Vector3 paddleLength = transform.localScale;

		for (int i = 0; i < 20; i++)
		{
			paddleLength.z += 0.01f;
			transform.localScale = paddleLength;
			yield return null;
		}
	}
}
