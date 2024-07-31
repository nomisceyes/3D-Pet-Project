using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehaviour : StateMachineBehaviour
{
    private Transform _player;

    private float _timer;
    private float _chaseRange = 6f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _timer = 0;

        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _timer += Time.deltaTime;

        if (_timer > 5)
            animator.SetBool("isPatrolling", true);

        float distance = Vector3.Distance(animator.transform.position, _player.position);

        if (distance <= _chaseRange)
            animator.SetBool("isChasing", true);
    }
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }  
}
