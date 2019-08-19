using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
	public float speed = 1f;
	public Transform[] platformPos;
	private float gravExp = 1f;
	public bool isUnder = false;
	public bool isClose = false;
	public bool isBetween = false;
	public bool canJump = true;

	private const float GRAVITY = 10f;
	private const float JUMP_BOOST = 100f;

	// Update is called once per frame
	void FixedUpdate()
	{
		MovePlayer();
	}

	private void MovePlayer()
	{
		float jumpPosY;
		float fallPosY;
		/*isUnder = false;
		isClose = false;*/

		/*for (int i = 0; i < platformPos.Length; i++)
		{
			edgeRight = platformPos[i].transform.position.x + platformPos[i].transform.localScale.x / 2;
			edgeLeft = platformPos[i].transform.position.x - platformPos[i].transform.localScale.x / 2;

			if (transform.position.x > edgeLeft && transform.position.x < edgeRight)
			{

				if (Mathf.Abs(platformPos[i].transform.position.y - transform.position.y) <= 1.2f)
				{
					isClose = true;
				}

				if (transform.position.y < platformPos[i].transform.position.y) isUnder = true;
			}

		}*/

		ValidMove();

		if (Input.GetKeyDown(KeyCode.Space) && canJump && GameManager.gameManager.hasSpawned)
		{
			jumpPosY = transform.localPosition.y + (JUMP_BOOST * speed * Time.fixedDeltaTime);

			if (isBetween && isClose) transform.localPosition = new Vector3(transform.localPosition.x, jumpPosY, 0);

			gravExp = 1f;
		}
		else
		{
			//Debug.Log("Falling!");
			fallPosY = transform.localPosition.y - ((GRAVITY + gravExp) * Time.fixedDeltaTime);

			if (!isClose && !isBetween)
			{
				transform.localPosition = new Vector3(transform.localPosition.x, fallPosY, 0);
				gravExp += 10f * Time.deltaTime;
			}
		}

		if (Input.GetKeyDown(KeyCode.LeftShift)) PlayerChangeSpeed(true);
		if (Input.GetKeyDown(KeyCode.RightShift)) PlayerChangeSpeed(false);
	}

	public void PlayerChangeSpeed(bool speedUp)
	{
		if (speedUp) speed *= 2f;
		else speed *= 0.5f;
	}

	// Checks if the user can move
	private void ValidMove()
	{
		isUnder = false;
		isClose = false;

		// All edges of pplatform
		Vector3 platRightTop;
		Vector3 platLeftTop;
		Vector3 platRightBot;
		Vector3 platLeftBot;

		// All edges of player cube
		Vector3 cubeRightTop = new Vector3(transform.localPosition.x + transform.localScale.x / 2, transform.localPosition.y + transform.localScale.y / 2, 0.5f);
		Vector3 cubeLeftTop = new Vector3(transform.localPosition.x - transform.localScale.x / 2, transform.localPosition.y + transform.localScale.y / 2, 0.5f);
		Vector3 cubeRightBot = new Vector3(transform.localPosition.x + transform.localScale.x / 2, transform.localPosition.y - transform.localScale.y / 2, 0.5f);
		Vector3 cubeLeftBot = new Vector3(transform.localPosition.x - transform.localScale.x / 2, transform.localPosition.y - transform.localScale.y / 2, 0.5f); ;

		for (int i = 0; i < platformPos.Length; i++)
		{
			platRightTop = new Vector3(platformPos[i].localPosition.x + platformPos[i].localScale.x / 2, platformPos[i].localPosition.y + platformPos[i].localScale.y / 2, 0.5f);
			platLeftTop = new Vector3(platformPos[i].localPosition.x - platformPos[i].localScale.x / 2, platformPos[i].localPosition.y + platformPos[i].localScale.y / 2, 0.5f);
			platRightBot = new Vector3(platformPos[i].localPosition.x + platformPos[i].localScale.x / 2, platformPos[i].localPosition.y - platformPos[i].localScale.y / 2, 0.5f);
			platLeftBot = new Vector3(platformPos[i].localPosition.x - platformPos[i].localScale.x / 2, platformPos[i].localPosition.y - platformPos[i].localScale.y / 2, 0.5f);

			if (cubeRightBot.y >= platRightTop.y) isUnder = false;
			if (Mathf.Abs(cubeLeftBot.y - platLeftTop.y) <= 1.2f) isClose = true;
			if (cubeRightTop.x <= platRightBot.x) isUnder = true;
			if (cubeRightTop.x >= platLeftTop.x && cubeRightTop.x <= platRightTop.x) isBetween = true;

			if (isClose && !isUnder && isBetween)
			{
				canJump = true;
			}
			else canJump = false;
		}
	}

	// Checks if the platform has gone through the cube. Places cube on top of platform if cube has been impaled.
	public bool CubeImpaled()
	{
		bool isImpaled = false;



		return isImpaled;
	}
}
