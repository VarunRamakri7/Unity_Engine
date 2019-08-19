using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	public GameObject cube;
	private float xAmp = 10f;
	private float yAmp = 5f;
	private float xSpeed = 1f;
	private float ySpeed = 5f;
	private float index = 0;
	private float xPos;
	private float yPos;

	private void FixedUpdate()
	{
		SineMovement();
	}

	//Function to move the object along a sine wave
	public void SineMovement()
	{
		index += Time.fixedDeltaTime;

		xPos = xAmp * Mathf.Cos(xSpeed * index);
		yPos = yAmp * Mathf.Sin(ySpeed * index);

		cube.transform.localPosition = new Vector3(xPos, yPos, 0);
	}
}
