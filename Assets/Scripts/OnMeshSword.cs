using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMeshSword : MonoBehaviour
{
    [SerializeField] private GameObject _weapon;


    private void Start()
    {
        _weapon.GetComponent<Collider>().enabled = false;
    }

    private void OnCollider()
    {
        _weapon.GetComponent<Collider>().enabled = true;
    }

    private void OffCollider()
    {
        _weapon.GetComponent <Collider>().enabled = false;
    }
}
