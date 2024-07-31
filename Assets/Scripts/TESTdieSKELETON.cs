using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTdieSKELETON : MonoBehaviour
{
    private EnemyHealth enemyHealth;

    private void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            enemyHealth.TakeDamage(1000);
        }
    }
}
