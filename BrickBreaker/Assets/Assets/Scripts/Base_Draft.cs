using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBreakerScript : MonoBehaviour
{
	// Global varibles for player
	int score = 0;
	int highScore = 0;
	int lives = 3;

	public class Cuboid
	{
		// Common variable for all cuboids
		protected int width, height, position;

		// Common functions for all cuboids
		public void SetWidth(int newWidth)
		{
			if (newWidth != null) this.width = newWidth;
			else return;
		}

		public void SetHeight(int newHeight)
		{
			if (newHeight != null) this.height = newHeight;
			else return;
		}

		public void SetPosition(int newPos)
		{
			if (newPos != null) this.position = newPos;
			else return;
		}

		public int GetWidth()
		{
			if (width != null) return this.width;
			else return -1;
		}

		public int GetHeight()
		{
			if (height != null) return this.height;
			else return -1;
		}

		public int GetPosition()
		{
			if (position != null) return this.position;
			else return -1;
		}
	}

	public class Brick: Cuboid
	{
		// Variables for each Brick
		private bool isBroken;
		private char colour;

		// Functions for each Brick
		private Brick()
		{
			width = 25;
			height = 10;
			position = 0;
			isBroken = false;
			colour = 'W';
		}

		public void SetStatus(bool newStatus)
		{
			if (newStatus != null) isBroken = newStatus;
			else return;
		}

		public void SetColour(char newColour)
		{
			if (newColour != null) colour = newColour;
			else return;
		}

		public bool GetStatus()
		{
			return isBroken;
		}

		public char GetColour()
		{
			if (colour != null) return colour;
			else return 'Z';
		}
	}

	public class Paddle: Cuboid
	{
		// Variables for Paddle
		private bool isBallPresent;

		// Functions for Paddle
		private Paddle()
		{
			width = 50;
			height = 15;
			position = 50;
			isBallPresent = true;
		}

		private void SetBallPresent(bool newBallStatus)
		{
			if (newBallStatus != null) isBallPresent = newBallStatus;
			else return;
		}

		private bool GetBallStatus()
		{
			return isBallPresent;
		}
	}

	public class Ball
	{
		// Variables for Ball
		private int radius;
		private int startAngle;
		private int reflAngle;
		private bool onPaddle;

		// Functions for Ball
		public Ball()
		{
			radius = 10;
			startAngle = 90;
			reflAngle = 0;
			onPaddle = true;
		}

		public void SetRadius(int newRadius)
		{
			if (newRadius != null) radius = newRadius;
		}

		public void SetStartAngle(int newAngle)
		{
			if (newAngle != null) startAngle = newAngle;
		}

		public void SetReflAngle(int newAngle)
		{
			if (newAngle != null) reflAngle = newAngle;
		}

		public void SetOnPaddle(bool newStatus)
		{
			onPaddle = newStatus;
		}

		public int GetRadius()
		{
			if (radius != null) return radius;
			else return -1;
		}

		public int GetStartAngle()
		{
			if (startAngle != null) return startAngle;
			else return -1;
		}

		public int GetReflAngle()
		{
			if (reflAngle != null) return reflAngle;
			else return -1;
		}

		public bool IsOnPaddle()
		{
			return onPaddle;
		}
	}

	// Function to generate bricks
	public void GenerateBricks()
	{

	}

	// Function to move Paddle
	public void MovePaddle()
	{

	}

	// Function to shoot Ball
	public void ShootBall()
	{

	}

	// Function that calculates ball's reflection
	public void ReflectionCalculation(int position, int angle)
	{

	}

	// Funtion that starts the game
	public void BeginGame()
	{

	}

	// Function to displat rules
	public void DisplayRules()
	{

	}

	// Function that displays the Menu UI
	public void Menu()
	{
		
	}

	// Function to exit game
	public void EndGame()
	{
		
	}

	// Use this for initialization
	void Start ()
	{
		Menu();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
