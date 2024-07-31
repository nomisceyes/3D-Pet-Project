using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] GameObject _spineSword;
    [SerializeField] GameObject _handSword;
    [SerializeField] private float duration = 1f;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _handSword.SetActive(false);
    }

    private void Update()
    {
        AttackLogic();
    }

    private void AttackLogic()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            _animator.SetTrigger("isSheath");
            StartCoroutine(WaitTime());
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            _animator.SetTrigger("asSheath");
            _spineSword.SetActive(true);
            _handSword.SetActive(false);
        }
    }
    private IEnumerator WaitTime()
    {
        yield return  new WaitForSeconds(duration);

        _spineSword.SetActive(false);
        _handSword.SetActive(true);
    }
}

