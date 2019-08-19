using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialItemScript : MonoBehaviour
{
	// Use this for initialization
	void Start()
	{
		this.gameObject.SetActive(false);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			this.gameObject.SetActive(false);
			PlatformItemScript.hasSpawned = false;
		}
	}
}
