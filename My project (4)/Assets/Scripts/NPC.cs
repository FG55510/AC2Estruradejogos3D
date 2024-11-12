using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    public Transform player;
    public float startSpeed = 2;
    
    public List<GameObject> points;
    NavMeshAgent agent;
    Animator animator;

    int index = 0;

    bool amigo;
    bool final;

    float DistanciaPlayer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();    
        GameManager.INSTANCE.PlayerPegouCristal.AddListener(MudaparaAmigo);
    }

    void Update()
    {
         DistanciaPlayer = Vector3.Distance(player.transform.position, transform.position);


        if (DistanciaPlayer < 5 && !final)
        {
            agent.SetDestination(player.transform.position);
            agent.speed = 4;
            if (!amigo && DistanciaPlayer <= 0.5)
            {
                KillPlayer();
            }
        }
        else if(!amigo)
        {
            agent.SetDestination(points[index].transform.position);
            agent.speed = startSpeed;
        }
        animator.SetFloat("Speed", agent.speed);
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
        else if (other.CompareTag("End") && amigo)
        {
            final = true;
            Door door = other.GetComponent<Door>();
            agent.SetDestination(door.destination);
        }
    }

    private void MudaparaAmigo()
    {
        amigo = true;
    }

    private void OnDestroy()
    {
        GameManager.INSTANCE.PlayerPegouCristal.RemoveListener(MudaparaAmigo);
    }

    private void Attack()
    {
        animator.SetTrigger("Attack");
    }

    private void KillPlayer()
    {
        Attack();
        GameManager.INSTANCE.PlayerDeath.Invoke();
    }
}
