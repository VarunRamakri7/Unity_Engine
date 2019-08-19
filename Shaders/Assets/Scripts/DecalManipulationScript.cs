using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecalManipulationScript : MonoBehaviour 
{
	public Material material;
	public Shader MoveShader;
	public Shader ScaleShader;
	public Shader RotateShader;

	void Start()
	{
		material.shader = MoveShader;
	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey (KeyCode.S)) material.shader = ScaleShader;

		if (Input.GetKey (KeyCode.M)) material.shader = MoveShader;

		if (Input.GetKey (KeyCode.R)) material.shader = RotateShader;
	}
}
