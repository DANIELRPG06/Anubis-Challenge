using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDamage : MonoBehaviour
{
    public int damage = 25;

    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("toma");
            EnemyStats stats = other.GetComponent<EnemyStats>();
            {
                if (stats != null)
                {
                    stats.MakeDammage(damage);
                }
            }

        }

    }
}

