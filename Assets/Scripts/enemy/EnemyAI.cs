using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private enemyAwareness awareness;
    private Transform playerTransform;
    private NavMeshAgent agent;
    void Start()
    {
        awareness = GetComponent<enemyAwareness>();
        playerTransform = FindObjectOfType<controller>().transform;
        agent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        if (awareness.isAggro)
        {
            agent.SetDestination(playerTransform.position);
        }

        else
        {
            agent.SetDestination(transform.position);
        }

    }
}
