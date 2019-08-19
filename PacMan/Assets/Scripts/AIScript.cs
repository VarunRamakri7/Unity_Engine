using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIScript : MonoBehaviour 
{

    public Transform player;            
    NavMeshAgent navMeshAgent;

    private Color initialColor;
    private Vector3 randPos = new Vector3();
    private float timeLeft;
    private Color targetColor;
    private Renderer renderer;

    private const float WIDTH = 2.0f;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        renderer = GetComponent<Renderer>();

        navMeshAgent.speed = 2.0f;
    }

    private void Start()
    {
        initialColor = GetComponent<Renderer>().material.color;
    }

    void Update()
    {
        // Move AIs to player
        navMeshAgent.SetDestination(player.position + randPos);

        if (timeLeft <= Time.deltaTime)
        {
            // Colour transition complete, Assign target colour
            renderer.material.color = targetColor;

            // start a new transition
            targetColor = new Color(Random.value, Random.value, Random.value);
            timeLeft = 2.0f;
        }
        else
        {
            // Colour transition is in progress, Calculate the interpolated colour
            renderer.material.color = Color.Lerp(renderer.material.color, targetColor, Time.deltaTime / timeLeft);

            // Update the timer
            timeLeft -= Time.deltaTime;
        }

        ChangeColour();
    }

    private void ChangeColour()
    {
        if (GetComponent<NavMeshAgent>().speed > 2) targetColor = Color.red;
        else if (GetComponent<NavMeshAgent>().speed < 2) targetColor = Color.grey;
        else targetColor = initialColor;
    }

    private void RandomElement()
    {
        randPos.x = Random.Range(-2, 2) * WIDTH;
        randPos.y = player.position.y;
        randPos.z = Random.Range(-1, 1) * WIDTH;
    }
}
