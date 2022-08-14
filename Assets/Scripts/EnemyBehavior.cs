using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public Transform patlorRoute;

    public List<Transform> locations;

    private int locationIndex = 0;
    private NavMeshAgent agent;
    public Transform player;
    private int _enemyLives = 3;

  
    public int EnemyLives
    {
        get { return _enemyLives; }
        set
        {
            _enemyLives = value;
            if (_enemyLives <= 0)
            {
                Destroy(gameObject);
                Debug.Log("Enemy Down");

                
            }
        }
    }
    private void Start()
    {
        InitializePatrolRoute();

        agent = GetComponent<NavMeshAgent>();
        MoveToNextPatrolLocation();
        player = GameObject.Find("Player").transform;

       
    }
    void InitializePatrolRoute()
    {
        foreach (Transform item in patlorRoute)
        {
            locations.Add(item);
        }
    }
    void Update()
    {

        if (agent.remainingDistance < 0.2f && !agent.pathPending)
        {

            MoveToNextPatrolLocation();
        }
    }


    void MoveToNextPatrolLocation()
    {
        if (locations.Count == 0)
        {
            return;
        }
        agent.destination = locations[locationIndex].position;

        locationIndex = (locationIndex + 1) % locations.Count;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Ataaaack");
            agent.destination = player.position;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("I lost him, Were is He?! ");

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Bullet(Clone)")
        {
            EnemyLives -= 1;
            Debug.Log("Critical HIT");
        }
    }


    
}