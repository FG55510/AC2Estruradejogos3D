using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Friend : MonoBehaviour
{
    public Player player;
    public float startSpeed = 2;

    public List<GameObject> points;
    NavMeshAgent agent;

    public bool norange;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!norange)
        {
            agent.SetDestination(player.transform.position);
            
        }
        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("End"))
        {
            norange = true;
        }
    }

    private void Gotothedoor(Transform location)
    {
        agent.SetDestination(location.position);
    }
}
