using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    private int _damageCount = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            other.GetComponent<PlayerManager>().TakeDamage(_damageCount);
        else 
            return;
    }
}
