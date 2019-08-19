using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour 
{
    public bool pause = false;

    private Rigidbody rigidBody;
    private const float SPEED = 0.5f;
    /*Unused private variables
     * private const int LEFT_BOUND = -16;
    private const int RIGHT_BOUND = 16;
    private const int UPPER_BOUND = -5;
    private const int LOWER_BOUND = 5;
    */

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update () 
    {
        UIInput();

        MovePlayer();
	}

    public void MovePlayer()
    {
        Transport();

        if (Input.GetKey(KeyCode.LeftArrow)) rigidBody.AddForce(Vector3.left * SPEED, ForceMode.Impulse);
        else if (Input.GetKey(KeyCode.RightArrow)) rigidBody.AddForce(Vector3.right * SPEED, ForceMode.Impulse);
        else if (Input.GetKey(KeyCode.UpArrow)) rigidBody.AddForce(Vector3.forward * SPEED, ForceMode.Impulse);
        else if (Input.GetKey(KeyCode.DownArrow)) rigidBody.AddForce(Vector3.back * SPEED, ForceMode.Impulse);
    }

    private void Transport()
    {
        if (transform.position.x < -16 && transform.position.z < 2 && transform.position.z > -0.3f) transform.position = new Vector3( 15, transform.position.y, transform.position.z);
        if(transform.position.x > 15.5f && transform.position.z < 2 && transform.position.z > -0.5f) transform.position = new Vector3(-15, transform.position.y, transform.position.z);
    }

    private void UIInput()
    {
        if (Input.GetKeyDown(KeyCode.P)) PauseGame();
        if (Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene(0);
    }

    // Function to pause the game
    public void PauseGame()
    {
        if (Time.timeScale >= 1)
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
