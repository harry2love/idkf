using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealAbility : MonoBehaviour
{
    public GameObject player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == player)
        {
            PlayerHealth health = collision.gameObject.GetComponent<PlayerHealth>();
            HealtBar healthBar = collision.gameObject.GetComponent<HealtBar>();
            if(health != null)
            {
                health.Heal();
            }
            Destroy(gameObject);
        }
    }
}
