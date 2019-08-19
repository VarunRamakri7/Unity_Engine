using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CubeRScript : MonoBehaviour
{
	public Rigidbody rbPlayer;
	public TrailRenderer trail;
	private bool isGrounded = false;
	private float jumpHeight = 20f;

	private void Start()
	{
		trail.startWidth = 1.0f;
		trail.endWidth = 0;
	}

	// Update is called once per frame
	void Update()
	{
		MovePlayer();
	}

	private void OnCollisionEnter()
	{
		isGrounded = true;
	}

	private void MovePlayer()
	{
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			float xPosition = transform.position.x + (Input.GetAxis("Horizontal") * 1f);

			Vector3 temp = new Vector3(xPosition, transform.position.y, 0);

			transform.position = temp;

			rbPlayer.AddForce(Vector3.left * 0.5f, ForceMode.Impulse);
		}

		if (Input.GetKey(KeyCode.RightArrow))
		{
			float xPosition = transform.position.x + (Input.GetAxis("Horizontal") * 1f);

			Vector3 temp = new Vector3(xPosition, transform.position.y, 0);

			transform.position = temp;

			rbPlayer.AddForce(Vector3.right * 0.5f, ForceMode.Impulse);
		}

		// Player movement
		if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
		{
			rbPlayer.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
			isGrounded = false;
		}

		if (Input.GetKeyDown(KeyCode.DownArrow) && isGrounded)
			rbPlayer.AddForce(Vector3.down * 2, ForceMode.Impulse);
	}

	private void ChangeAttribute()// Not used
	{
		if (Input.GetKeyDown(KeyCode.LeftShift)) jumpHeight++;
		if (Input.GetKeyDown(KeyCode.RightShift)) jumpHeight--;
		if (Input.GetKeyDown(KeyCode.LeftControl)) GameManager.gameManager.speedPlat++;
		if (Input.GetKeyDown(KeyCode.RightControl)) GameManager.gameManager.speedPlat--;
	}

	private bool SideCollisionCheck(Collision collision)
	{
		Collider player = GetComponent<Collider>();
		Collider platform = collision.collider;

		if (player.bounds.Intersects(platform.bounds)) return true;

		return false;
	}
}
