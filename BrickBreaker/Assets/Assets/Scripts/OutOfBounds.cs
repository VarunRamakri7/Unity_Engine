using UnityEngine;
using System.Collections;

/**
 *	BrickBreaker Excercise - Out of Bounds Script
 *	
 *	By, Varun Ramakrishnan, 25/6/18
 */

// Class to handle lose of life if the ball goes out of bounds
public class OutOfBounds : MonoBehaviour
{
	void OnTriggerEnter()
	{
		Game.instance.LoseLife();
	}
}
