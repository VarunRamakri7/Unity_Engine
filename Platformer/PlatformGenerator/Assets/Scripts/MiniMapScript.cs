using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniMapScript : MonoBehaviour
{
	public GameObject startPosObj;
	public GameObject endPosObj;
	public CubeRScript cubeObject;
	bool isMoving = false;
	public GameObject tempStart;

	public void Start()
	{
		tempStart = startPosObj;
		StartCoroutine(MoveMiniMap(startPosObj.transform, endPosObj.transform.position, 20f));
	}

	IEnumerator MoveMiniMap(Transform fromPosition, Vector3 toPosition, float duration)
	{
		//Make sure there is only one instance of this function running
		if (isMoving) yield break; ///exit if this is still running

		isMoving = true;

		float counter = 0;

		//Get the current position of the object to be moved
		Vector3 startPos = fromPosition.position;

		while (counter < duration)
		{
			counter += Time.deltaTime;
			fromPosition.position = Vector3.Lerp(startPos, toPosition, counter / duration);
			yield return null;
		}

		isMoving = false;

		if(fromPosition.position.x >= 24f)
		{
			Debug.Log("You Won!");
			Time.timeScale = 0.25f;
			Invoke("ChangeScene", 2.0f);
		}
	}

	private void ChangeScene()
	{
		SceneManager.LoadScene("MainScene");
	}
}
