using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackControl : MonoBehaviour
{
    private Animator _animator;

    private int _currentAttack = 0;
    private float _delayAttackTime = 0.3f;
    private float _timeSinceAttack = 0.0f;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if ((_timeSinceAttack += Time.deltaTime) > _delayAttackTime)
        {
            if (_timeSinceAttack > 1.0f)
                _currentAttack = 0;

            Attack();
        }
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0) && _timeSinceAttack > 0.25f)
        {     
            AttackAnimation();
        }
    }

    private void AttackAnimation()
    {
        _currentAttack++;

        if (_currentAttack > 2)
            _currentAttack = 1;

        if (_timeSinceAttack > 1.0f)
            _currentAttack = 1;

        _animator.SetTrigger("Attack" + _currentAttack);

        _timeSinceAttack = 0.0f;
    }
}
