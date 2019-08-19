using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
    public GameObject player;
    public GameObject[] enemies;
    CapsuleCollider playerCollider;
    SphereCollider enemyCollider;
    public GameObject[] posPowerup;
    public GameObject negPowerup;
    public ParticleSystem posParticles;
    public ParticleSystem negParticles;
    public ParticleSystem coinParticles;
    public Text livesText;
    public Text enemySpeedText;
    public GameObject coin;
    public int numCollects;
    public Text timerText;

    private int lives = 4;
    private BoxCollider posCollider;
    private BoxCollider negCollider;
    private bool isPresent = true;
    private float timer;

    private void Start()
    {
        Time.timeScale = 1;

        playerCollider = player.GetComponent<CapsuleCollider>();
        negCollider = negPowerup.GetComponent<BoxCollider>();


        livesText.text = "Lives: " + lives;
        enemySpeedText.text = "Enemy Speed: " + enemies[1].GetComponent<NavMeshAgent>().speed;
    }

    private void Update()
    {
        Timer();

        if (lives > 0)
        {
            if (!isPresent) GeneratePowerup();
            CheckTouch();
            DisplayText();

            if (coin.GetComponent<CapsuleCollider>().bounds.Intersects(player.GetComponent<CapsuleCollider>().bounds))
            {
                coinParticles.transform.position = coin.transform.position;
                Instantiate(coinParticles);

                GenerateCoin();

                GameOver(true);
            }
        }
        else GameOver(false);
    }

    private void CheckTouch()
    {
        // Checks if player touches an enemy
        for (int i = 0; i < enemies.Length; i++)
        {
            enemyCollider = enemies[i].GetComponent<SphereCollider>();

            if (enemyCollider.bounds.Intersects(playerCollider.bounds))
            {
                lives--;
                Debug.Log("Life Lost! Lives remaining: " + lives);
            }
        }

        // Checks if player touches a powerup
        PosPowerUp();
        NegPowerUp();
    }

    private void GameOver(bool hasWon)
    {
        if(hasWon)
        {
            if (numCollects == 4)
            {
                Time.timeScale = 0.25f;
                Debug.Log("You won!");

                SceneManager.LoadScene(0);
            }

            numCollects++;
        }
        else  
        {
            Debug.Log("Game Over");
            Time.timeScale = 0.25f;

            SceneManager.LoadScene(0);
        }
    }

    private void PosPowerUp()
    {
        for (int i = 0; i < posPowerup.Length; i++)
        {
            posCollider = posPowerup[i].GetComponent<BoxCollider>();

            if (posCollider.bounds.Intersects(playerCollider.bounds))
            {
                if (i == 0) 
                {
                    lives += 5;
                    Debug.Log("Powerup Obtained! Lives: " + lives);
                }
                else
                {
                    Debug.Log("Powerup Obtained! Enemies slowed down");
                    for (int j = 0; j < enemies.Length; j++)
                    {
                        if(enemies[j].GetComponent<NavMeshAgent>().speed > 0.5f)enemies[j].GetComponent<NavMeshAgent>().speed *= 0.5f;
                    }
                }

                posPowerup[i].SetActive(false);
                posParticles.transform.position = posPowerup[i].transform.position;
                Instantiate(posParticles);

                isPresent = false;
            }
        } 
    }

    private void NegPowerUp()
    {
        if(negCollider.bounds.Intersects(playerCollider.bounds))
        {
            Debug.Log("Oops, Power down obtained! Enemies now move faster");
            
            for (int j = 0; j < enemies.Length; j++)
            {
                enemies[j].GetComponent<NavMeshAgent>().speed *= 2;
            }

            negPowerup.SetActive(false);
            negParticles.transform.position = negPowerup.transform.position;
            Instantiate(negPowerup);

            isPresent = false;
        }
    }

    private void GeneratePowerup()
    {
        for (int i = 0; i < posPowerup.Length; i++)
        {
            posPowerup[i].transform.position = new Vector3(Random.Range(-16, 16), 0, Random.Range(-5, 5));
            posPowerup[i].SetActive(true);
        }

        negPowerup.transform.position = new Vector3(Random.Range(-16, 16), 0, Random.Range(-5, 5));
        negPowerup.SetActive(true);

        isPresent = true;
    }

    private void DisplayText()
    {
        livesText.text = "Lives: " + lives;
        enemySpeedText.text = "Enemy Speed: " + enemies[1].GetComponent<NavMeshAgent>().speed;
    }

    private void GenerateCoin()
    {
        coin.SetActive(false);

        coin.transform.position = new Vector3(Random.Range(12, 15), 0, Random.Range(2.5f, 4));

        coin.SetActive(true);
    }

    private void Timer()
    {
        timer += Time.deltaTime * 1;

        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        int millisec = Mathf.FloorToInt(timer * 1000);
        millisec %= 1000;
        string formatTime = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, millisec);

        timerText.text = "Time: " + formatTime;
    }

    /*void TimerDisp()
    {
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
    }*/
}
