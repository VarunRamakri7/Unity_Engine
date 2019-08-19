using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControlScript : MonoBehaviour 
{
	public Material material;
	public Slider rotate;
	public Slider moveX, moveY;
	public Slider scale;

	void Start()
	{
		rotate.value = 0;
		moveX.value = moveY.value = 0.5f;
		scale.value = 1;
	}

	public void HasRotated()
	{
		Debug.Log ("Rotated value: " + rotate.value);

		material.SetFloat ("_RotationSpeed", rotate.value);
	}

	public void HasScaled()
	{
		Debug.Log ("Scaled value: " + scale.value);

		material.SetFloat ("_Scale", scale.value);
	}

	public void HasMovedX()
	{
		Debug.Log ("U value: " + moveX.value);

		material.SetFloat ("_SpeedU", moveX.value);
	}

	public void HasMovedY()
	{
		Debug.Log ("Y value: " + moveY.value);

		material.SetFloat ("_SpeedV", moveY.value);
	}
}
