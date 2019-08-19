using UnityEngine;
using System.Collections;

/**
 *	BrickBreaker Excercise - Destruction Script
 *	
 *	By, Varun Ramakrishnan, 25/6/18
 */

public class TimeDestruction : MonoBehaviour
{
	public float destroyTime = 1f;

	// Use this for initialization
	void Start()
	{
		Destroy(gameObject, destroyTime);
	}
}
