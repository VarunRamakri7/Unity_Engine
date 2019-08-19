using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/**
 *	BrickBreaker Excercise - Game Script
 *	
 *	By, Varun Ramakrishnan, 25/6/18
 */

// Class for the main Gameplay
public class Game : MonoBehaviour
{
	// Global variables for the player
	public int lives = 3;
	public int score = 0;
	private int highScore = 0;
	private float resetDelay = 1f;
	public Text livesText;
	public Text scoreText;
	public Text highScoreText;
	public GameObject gameOver;
	public GameObject rowGeneratePrefab;
	public GameObject victory;
	public GameObject bricksPrefab;
	public GameObject paddle;
	public GameObject deathParticles;
	public static Game instance = null;
	public bool gameOn = true;
	public int brokenBricks = 0;
	public GameObject ball;
	public GameObject[] allBricks;
	public int ballCount = 1;
	private GameObject clonePaddle;
	public GameObject specialBrick;
	private Vector3[] startPos;
	private int numSpecialHits = 0;
	private Vector3 specialBrickPos;

	// Local constant variables
	private const int MAX_BALLCOUNT = 5;
	private const int INITIAL_MULTIBALL_SCORE = 20;
	private const int FINAL_MULTIBALL_SCORE = 30;
	private const int MAX_LIVES = 6;

	private void Start()
	{
		allBricks = GameObject.FindGameObjectsWithTag("Brick");

		startPos = new Vector3[allBricks.Length];

		for (int i = 0; i < allBricks.Length; i++)
		{
			startPos[i] = allBricks[i].transform.position;
		}

		specialBrickPos = specialBrick.transform.position;
	}

	// Use this for initialization
	void Awake()
	{
		if (instance == null) instance = this;
		else if (instance != this) Destroy(gameObject);

		Setup();
	}

	// Function to generate new rows
	public void GenerateRow()
	{
		Instantiate(rowGeneratePrefab);
	}

	public void Setup()
	{
		clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
	}

	// Function to check if game over
	public void CheckGameOver()
	{
		// Checks if no lives remaining
		if (lives < 1)
		{
			GameOver(false);
		}

	}

	public void GameOver(bool win)
	{
		if (win) victory.SetActive(true);
		else
		{
			gameOver.SetActive(true);
			ballCount = 1;
		}
		gameOn = false;
		Time.timeScale = .25f;
		Invoke("Reset", resetDelay);
	}

	private void Reset()
	{
		Time.timeScale = 1f;
		Application.LoadLevel(Application.loadedLevel);
	}

	// Function to handle player losing a life
	public void LoseLife()
	{
		lives--;
		ballCount--;
		livesText.text = "Lives: " + lives;

		if (clonePaddle != null)
			Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);

		brokenBricks = 0;

		Destroy(clonePaddle);
		Invoke("SetupPaddle", resetDelay);
		AlterScore(false);
		CheckGameOver();
	}

	// Function to increase player score
	public void AlterScore(bool increase)
	{
		if (increase)
		{
			score += 5;
			scoreText.text = "Score: " + score;

			if (score > highScore)
			{
				highScore = score;
				highScoreText.text = "High Score: " + highScore;
			}
		}
		else
		{
			if (score > 15) score -= 15;
			else score = 0;
			scoreText.text = "Score: " + score;
		}

		// Increase number of balls every 20 points
		if (lives < MAX_LIVES && ballCount < MAX_BALLCOUNT)
		{
			if (score > 0 && score <= 100)
			{
				if (score % INITIAL_MULTIBALL_SCORE == 0)
				{
					lives++;
					livesText.text = "Lives: " + lives;

					MultiBall();
				}
			}
			else if (score > 100 && score % (FINAL_MULTIBALL_SCORE + 10) == 0)
			{
				lives++;
				livesText.text = "Lives: " + lives;

				MultiBall();
			}
		}
	}

	// Function to setup paddle
	void SetupPaddle()
	{
		if (clonePaddle == null) clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
	}

	// Function to handle destruction of a brick
	public void DestroyBrick()
	{
		AlterScore(true);
		CheckGameOver();
	}

	// Function to make multiple balls for the player
	public void MultiBall()
	{
		if (ballCount < MAX_BALLCOUNT)
		{
			lives++;
			livesText.text = "Lives: " + lives;
			ballCount++;

			GameObject newBall = Instantiate(ball, paddle.transform.position, Quaternion.identity);

			newBall.transform.localScale = Vector3.one * 0.5f;
			newBall.transform.position = new Vector3(newBall.transform.position.x, newBall.transform.position.y + 0.5f, newBall.transform.position.z);
		}
	}

	// Function to destroy all bricks when special brick is hit
	public void HitSpecialBrick()
	{
		if (numSpecialHits % 3 == 0)
		{
			for (int i = 0; i < allBricks.Length; i++)
			{
				Game.instance.brokenBricks++;

				allBricks[i].transform.position = new Vector3(startPos[i].x, startPos[i].y + 3f, startPos[i].z);
			}

			specialBrick.transform.position = new Vector3(specialBrickPos.x, specialBrickPos.y + 3f, specialBrickPos.z);
			specialBrick.SetActive(true);
		}

		numSpecialHits++;

		Game.instance.score += 100;
	}
}
