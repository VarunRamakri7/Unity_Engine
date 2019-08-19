using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTextureScript : MonoBehaviour 
{
	public Material material;

	void Update()
	{
		if (Input.GetKey (KeyCode.Mouse0))
		{
			material.SetFloat("_SpeedU", Input.GetAxis("Mouse X"));
			material.SetFloat("_SpeedV", Input.GetAxis("Mouse Y"));
		}
	}

	/*private void CheckMouseMove()
	{
		if (Input.GetAxis ("Horizontal") < 0) speedU++;
		else if (Input.GetAxis ("Vertical") > 0) speedV++;

		if(speedU < 10) material.SetFloat;
		if(speedV < 10) material.SetFloat ("_SpeedV", speedV);
	}*/
}
