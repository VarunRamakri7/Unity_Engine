using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformItemScript : MonoBehaviour
{
	public GameObject splItem;
	private int randAppear;
	public static bool hasSpawned = false;

	// Update is called once per frame
	void Update()
	{
		randAppear = Random.Range(0, 2);

		if(randAppear == 1 && !hasSpawned)
		{
			splItem.transform.position = new Vector3(transform.position.x, transform.position.y + 1f, 0);
			splItem.SetActive(true);

			hasSpawned = true;
		}
	}
}
