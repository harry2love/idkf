using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDealDamage : MonoBehaviour
{
    public GameObject player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            Debug.Log("Touched Player");
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            Debug.Log("Hit player");
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(10);
            }

        }
    }
}
