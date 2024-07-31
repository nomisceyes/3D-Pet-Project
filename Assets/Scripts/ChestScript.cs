using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    private Animator _animator;

    private void Start() => _animator = GetComponent<Animator>();

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Weapon"))
            _animator.SetBool("isOpen",true);
    }
}
