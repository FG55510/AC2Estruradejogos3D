using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    public Player player;
    public float startSpeed = 2;
    
    public List<GameObject> points;
    NavMeshAgent agent;

    int index = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 5)
        {
            agent.SetDestination(player.transform.position);
            agent.speed = 4;
        }
        else
        {
            agent.SetDestination(points[index].transform.position);
            agent.speed = startSpeed;
        }
    }

    void ChangePoint()
    {
        index++;

        if (index >= points.Count)
        {
            index = 0;
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Point"))
        {
            ChangePoint();
        }
    }
}
