using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager gameManager;
	public GameObject playerCube;
	public ObjectPooling platformPool = new ObjectPooling();
	public Transform platParent;
	private Vector3 lastActPlat;
	public float speedPlat = 0f;
	public int lives = 3;
	private bool GameOn = true;
	public bool isOut = false;
	public bool hasSpawned = true;

	private const int MAX_HEIGHT = 3;
	private const int MIN_HEIGHT = -4;
	private const float LEFT_BOUND = -98;
	private const float RIGHT_BOUND = 100;
	private const float xGAP = 5;
	private readonly float[] POSSIBLE_HEIGHTS = { 3, 1, -1, -3 };

	private void Awake()
	{
		gameManager = this;
		Time.timeScale = 1f;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (!CheckGameOn())
		{
			Debug.Log("Game Over");
			Time.timeScale = 0.25f;
			SceneManager.LoadScene("MainScene");
		}
		else Debug.Log("Lives: " + lives);

		//GenerateRows();

		if (playerCube.transform.position.y > -5f) isOut = false;
	}

	public void GenerateRows()// Not used
	{
		int randHeight = Random.Range(0, 4);
		Vector3 position;

		MovePlatforms();

		lastActPlat = platformPool.objects[platformPool.LastDeacObj].transform.position;

		if (lastActPlat.x < LEFT_BOUND)
		{
			platformPool.DeactivateObject();

			position = new Vector3(RIGHT_BOUND + xGAP, POSSIBLE_HEIGHTS[randHeight], 0);

			platformPool.ActivateObject(position);
		}
	}

	public void MovePlatforms()// Not used
	{
		platParent.Translate(-speedPlat * Time.fixedDeltaTime, 0, 0);
	}

	public bool CheckGameOn()
	{
		if (playerCube.transform.position.y < -5f && !isOut)
		{
			lives--;
			playerCube.transform.position = new Vector3(0, 4f, 0);

			hasSpawned = true;
			Invoke("Respawn", 2f);

			isOut = true;
		}

		if (lives == 0) GameOn = false;

		return GameOn;
	}

	public void Respawn()
	{
		hasSpawned = false;
	}
}


//Class for Object Pooling
[System.Serializable]
public class ObjectPooling
{
	public GameObject[] objects;
	private int lastActObj;
	private int lastDeacObj;

	public ObjectPooling()
	{
		LastActObj = 14;
		LastDeacObj = 0;
	}

	public void ActivateObject(Vector3 position)
	{
		objects[LastActObj].SetActive(true);
		objects[LastActObj].transform.position = position;

		if (LastActObj < objects.Length - 1) LastActObj++;
		else LastActObj = 0;
	}

	public void DeactivateObject()
	{
		objects[LastDeacObj].SetActive(false);

		if (LastDeacObj < objects.Length - 1) LastDeacObj++;
		else LastDeacObj = 0;
	}

	// Properties
	public int LastActObj
	{
		get
		{
			return lastActObj;
		}

		set
		{
			lastActObj = value;
		}
	}

	public int LastDeacObj
	{
		get
		{
			return lastDeacObj;
		}

		set
		{
			lastDeacObj = value;
		}
	}
}
