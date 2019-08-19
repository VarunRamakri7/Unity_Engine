using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsScript : MonoBehaviour
{
	public float angularSpeed;
	public float zDistance;
	public float angle = 0;
	private Vector2 newPosition;
	public Transform originTrans;
	public Transform sphereTrans;

	// Update is called once per frame
	void FixedUpdate()
	{
		//SetDist();
		CalcOrbit();

		angle += angularSpeed * Time.fixedDeltaTime;
	}

	public void SetDist()
	{
		Vector3 origPosition = sphereTrans.localPosition;

		origPosition.z = zDistance;

		sphereTrans.localPosition = origPosition;

		CalcOrbit();
	}

	public void CalcOrbit()
	{
		//originTrans.Rotate(Vector3.up, angularSpeed, Space.Self);

		float xVal;
		float zVal;

		xVal = (Mathf.Cos(angle * Mathf.Deg2Rad) * zDistance) + originTrans.position.x;
		zVal = (Mathf.Sin(angle * Mathf.Deg2Rad) * zDistance) + originTrans.position.z;

		sphereTrans.position = new Vector3(xVal, sphereTrans.position.y, zVal);
	}

	public void SetRadius(string radius)
	{
		if (radius != null) float.TryParse(radius, out zDistance);
	}

	public void SetSpeed(string speed)
	{
		if (speed != null) float.TryParse(speed, out angularSpeed);
	}
}
