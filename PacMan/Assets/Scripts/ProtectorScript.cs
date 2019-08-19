using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectorScript : MonoBehaviour 
{
    public GameObject VertProtector; // Moves only along Z-Axis between 2 and 4.5
    public GameObject HorzProtector; // Movies only along X-Axis between 12 and 15

    private readonly Vector3 X_MAX = new Vector3(15, 0, 2);
    private readonly Vector3 X_MIN = new Vector3(12, 0, 2);
    private readonly Vector3 Z_MAX = new Vector3(12, 0, 4.5f);
    private readonly Vector3 Z_MIN = new Vector3(12, 0, 2);
    private const float SPEED = 1.0f;

	// Update is called once per frame
	void Update () 
    {
        MoveProtectors();
	}

    private void MoveProtectors()
    {
        VertProtector.transform.position = Vector3.Lerp(Z_MAX, Z_MIN, Mathf.PingPong(Time.time * SPEED, 1.0f));
        HorzProtector.transform.position = Vector3.Lerp(X_MIN, X_MAX, Mathf.PingPong(Time.time * SPEED, 1.0f));
    }
}
