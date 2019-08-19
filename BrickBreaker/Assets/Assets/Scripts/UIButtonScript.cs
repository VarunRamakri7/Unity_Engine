using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 *	BrickBreaker Excercise - UI Buttons Script
 *	
 *	By, Varun Ramakrishnan, 26/6/18
 */

public class UIButtonScript : MonoBehaviour
{
	// Varibale for pausing game
	bool pause = false;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.P)) PauseGame();

		if (Input.GetKeyDown(KeyCode.R)) BeginGame();
	}

	// Function to change scene to game
	public void BeginGame()
	{
		SceneManager.LoadScene(2);
	}

	// Function to change scene to info
	public void ShowInfo()
	{
		SceneManager.LoadScene(1);
	}

	// Function to quit game
	public void EndGame()
	{
		Application.Quit();
	}

	// Function to go back from Info scene
	public void GoBack()
	{
		SceneManager.LoadScene(0);
	}

	// Function to pause the game
	public void PauseGame()
	{
		if (Time.timeScale == 1)
		{
			Time.timeScale = 0;
			pause = true;
		}
		else
		{
			Time.timeScale = 1;
			pause = false;
		}
	}
}
