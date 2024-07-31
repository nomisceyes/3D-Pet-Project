using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolBehaviour : StateMachineBehaviour
{
    private float _timer;
    private List<Transform> _points = new List<Transform>();
    private NavMeshAgent _agent;

    private Transform _player;
    private int _point = 0;
    private float _chaseRange = 6f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _timer = 0;

        Transform pointsObject = GameObject.FindGameObjectWithTag("Way").transform;

        foreach (Transform point in pointsObject)
            _points.Add(point);

        _agent = animator.GetComponent<NavMeshAgent>();

        _agent.SetDestination(_points[_point].position);

        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector3.Distance(_agent.transform.position, _points[_point].position) < 0.2f)
        {
            if (_point > 0)
            {
                _point = 0;
                _agent.SetDestination(_points[_point].position);
            }
            else
            {
                _point = 1;
                _agent.SetDestination(_points[_point].position);
            }
        }

        _timer += Time.deltaTime;

        if (_timer > 10)
            animator.SetBool("isPatrolling", false);

        float distance = Vector3.Distance(animator.transform.position, _player.position);

        if (distance < _chaseRange)
            animator.SetBool("isChasing", true);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent.SetDestination(_agent.transform.position);
    }
}
