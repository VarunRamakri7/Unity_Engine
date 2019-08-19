using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 *	BrickBreaker Excercise - UI Buttons Script
 *	
 *	By, Varun Ramakrishnan, 28/6/18
 */

public class BrickMovementScript : MonoBehaviour
{
	public float start = 10;
	public float speed = 1.0f;
	private float startTime;
	private float totalLength;
	public Vector3 startVector;
	public Vector3 endVector = new Vector3();
	private bool spawn = false;

	private void Start()
	{
		startTime = Time.time - Time.timeSinceLevelLoad;

		endVector = new Vector3(transform.position.x, transform.position.y + start, transform.position.z);
		startVector = transform.position;

		totalLength = Vector3.Distance(startVector, endVector);
	}

	private void Update()
	{
		if (Game.instance.gameOn)
		{
			float distCovered = (Time.time - startTime) * speed;
			float fracDist = distCovered / totalLength;

			transform.position = Vector3.Lerp(startVector, endVector, fracDist);

			// Increase speed gradually
			speed += 0.001f * Time.deltaTime;
		}
	}
}
