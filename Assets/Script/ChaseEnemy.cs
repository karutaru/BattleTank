using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseEnemy : MonoBehaviour
{
    private GameObject target;
    private NavMeshAgent agent;

    void Start()
    {
        target = GameObject.Find("Tank");

        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(target)
        {
            agent.destination = target.transform.position;
        }
    }
}
