using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class to handle all the sounds that are played
public class SoundController : MonoBehaviour
{
	// Variables to hold the audioclip for each collision
	public AudioClip hitPaddle;
	public AudioClip hitBrick;
	public AudioClip hitWall;
	public AudioClip loseLife;
	public static SoundController instance;

	private AudioSource source;

	// Use this for initialization
	void Start()
	{
		if (instance == null) instance = this;
		else if (instance != this) Destroy(gameObject);

		source = GetComponent<AudioSource>();
	}

	public void BrickHitSound()
	{
		//Debug.Log("Brick Noise");

		source.Stop();
		source.clip = hitBrick;
		source.Play();
	}

	public void PaddleHitSound()
	{
		//Debug.Log("Paddle Noise");

		source.Stop();
		source.clip = hitPaddle;
		source.Play();
	}

	public void LostLifeSound()
	{
		//Debug.Log("Life Lost Noise");

		source.Stop();
		source.clip = loseLife;
		source.Play();
	}

	public void WallHitSound()
	{
		//Debug.Log("Wall Noise");

		source.Stop();
		source.clip = hitWall;
		source.Play();
	}
}
