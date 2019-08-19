using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 *	BrickBreaker Excercise - UI Buttons Script
 *	
 *	By, Varun Ramakrishnan, 26/6/18
 */

public class RandomColourScript : MonoBehaviour
{
	[SerializeField] private Material brickMaterial;
	Color[] colors = new Color[3];

	// Use this for initialization
	void Start()
	{
		colors[0] = Color.red;
		colors[1] = Color.blue;
		colors[2] = Color.green;

		brickMaterial.color = colors[Random.Range(0, 3)];
	}
}
