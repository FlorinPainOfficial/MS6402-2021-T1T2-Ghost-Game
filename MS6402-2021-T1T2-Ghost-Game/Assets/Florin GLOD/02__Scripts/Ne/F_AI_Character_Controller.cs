﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(F_CharacterController))]
public class F_AI_Character_Controller : MonoBehaviour
{
    public NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
    public F_CharacterController character { get; private set; } // the character we are controlling
    public Transform target;                                    // target to aim for


    private void Start()
    {
        // get the components on the object we need ( should not be null due to require component so no need to check )
        agent = GetComponentInChildren<NavMeshAgent>();
        character = GetComponent<F_CharacterController>();

        agent.updateRotation = false;
        agent.updatePosition = true;
    }


    private void Update()
    {
        if (target != null)
            agent.SetDestination(target.position);

        if (agent.remainingDistance > agent.stoppingDistance)
            character.Behaviour_Movement(agent.desiredVelocity);
        else
            character.Behaviour_Movement(Vector3.zero);
    }


    public void SetTarget(Transform target)
    {
        this.target = target;
    }


}//END
