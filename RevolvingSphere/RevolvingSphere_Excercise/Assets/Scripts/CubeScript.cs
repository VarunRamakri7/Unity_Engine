using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
	public Vector3 startPosition;

	// Update is called once per frame
	void Update()
	{
		MoveCube();
	}

	public void MoveCube()
	{
		if (Input.GetKeyDown(KeyCode.LeftArrow)) transform.Translate(Vector3.left);
		else if (Input.GetKeyDown(KeyCode.RightArrow)) transform.Translate(Vector3.right);
		else if (Input.GetKeyDown(KeyCode.UpArrow)) transform.Translate(Vector3.forward);
		else if (Input.GetKeyDown(KeyCode.DownArrow)) transform.Translate(Vector3.back);
	}
}
