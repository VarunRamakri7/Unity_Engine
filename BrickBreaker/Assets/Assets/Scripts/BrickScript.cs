using UnityEngine;
using System.Collections;

/**
 *	BrickBreaker Excercise - Brick Script
 *	
 *	By, Varun Ramakrishnan, 25/6/18
 */

// Class to handle behaviour of Bricks
public class BrickScript : MonoBehaviour
{
	// Variable for the particle system
	public GameObject brickParticles;
	public GameObject specialBrick;
	private Color color;
	public float alpha;
	private int numSpecial = 0;
	private int numHits = 0;

	private const int MAX_HITS = 3;

	private void Start()
	{
		alpha = 5;
		color = gameObject.GetComponent<Renderer>().material.color;
	}

	// Function to handle Brick behaviour on collision
	public void OnCollisionEnter()
	{
		if (!gameObject.tag.Contains("Multi") && !gameObject.tag.Contains("Special")) DestroyBrick();
		else if (numHits > 0 && numHits % 3 == 0)
		{
			DestroyBrick();
			numHits++;

			RespawnBrick(true);
		}
		else
		{
			numHits++;
			ChangeColour(false);
		}

		if (gameObject.tag.Equals("Brick")) RespawnBrick(false);
		else if (gameObject.tag.Equals("SpecialBrick"))
		{
			if (numSpecial % 3 == 0) RespawnBrick(false);

			numSpecial++;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Finish") Game.instance.GameOver(false);
	}

	// Function ot destroy brick
	private void DestroyBrick()
	{
		// Make particles and change their colour
		GameObject particles = Instantiate(brickParticles, transform.position, Quaternion.identity);

		Color32 color = new Color((byte)this.color.r, (byte)this.color.g, (byte)this.color.b, alpha);
		particles.GetComponent<ParticleSystem>().startColor = color;

		gameObject.SetActive(false);

		Game.instance.DestroyBrick();
		Game.instance.brokenBricks++;
	}

	// Function to respawn the destroyed bricks
	private void RespawnBrick(bool isMulti)
	{
		if(!isMulti) gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + 4.5f, transform.position.z);
		else gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + 8f, transform.position.z);

		ChangeColour(true);
		gameObject.SetActive(true);
	}

	private void ChangeColour(bool respawn)
	{
		//Debug.Log("Colour changed! Respawn:" + respawn);
		Color originalColor = gameObject.GetComponent<Renderer>().material.color;

		if(!respawn) originalColor.a -= 0.2f;
		else originalColor.a = 1;

		gameObject.GetComponent<Renderer>().material.color = originalColor;
	}
}
