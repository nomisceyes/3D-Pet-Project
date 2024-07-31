using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendController : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        UpShield();
    }

    public bool UpShield()
    {
        _animator.SetBool("isDefend",Input.GetMouseButton(1));
        return Input.GetMouseButton(1);
    }
}
