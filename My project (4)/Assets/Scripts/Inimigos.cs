using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Inimigos : MonoBehaviour
{
    float DistanciaPlayer;
    public Transform player;
    NavMeshAgent agent;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        DistanciaPlayer = Vector3.Distance(player.position, transform.position);
        agent.SetDestination(player.transform.position);
        agent.speed = 2.5f;
        if (DistanciaPlayer <= 1)
        {
            KillPlayer();
        }
        animator.SetFloat("Speed", agent.speed);
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
