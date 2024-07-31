using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDamageScript : MonoBehaviour
{
    private int _damage = 100;

    private void Start()
    {
        GetComponent<Collider>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyHealth>().TakeDamage(_damage);
        }
    }
}