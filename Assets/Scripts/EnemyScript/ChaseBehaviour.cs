using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseBehaviour : StateMachineBehaviour
{
    private NavMeshAgent _agent;
    private Transform _player;

    private float _attackRange = 1.2f;
    private float _chaseRange = 6f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent = animator.GetComponent<NavMeshAgent>();
        _agent.speed = 2;

        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }
  
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent.SetDestination(_player.position);
        float distance = Vector3.Distance(animator.transform.position, _player.position);

        if (distance < _attackRange) 
             animator.SetBool("isAttacking",true);

        if(distance > _chaseRange)
            animator.SetBool("isChasing",false);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent.SetDestination(_agent.transform.position);
        _agent.speed = 0.5f;
    }
}
