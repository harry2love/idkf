using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectTileEnemy4 : MonoBehaviour
{
    public Rigidbody2D rb;
    float speed = 20f;
    Enemy4Health health;

    private void Start()
    {
        health = new Enemy4Health(); 
    }
    private void Update()
    {
        rb.velocity = -transform.right * speed;

        if (health.shootFaster)
        {
            Debug.Log("speed = 25");
            speed = 25f;
        }

        if (health.shootAtFastestSpeed)
        {
            Debug.Log("speed = 30");
            speed = 30f;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerHealth playerhealth = collision.GetComponent<PlayerHealth>();
            if (playerhealth != null)
            {
                playerhealth.TakeDamage(20);
            }
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Enemy4Barrier")
        {
            Destroy(gameObject);
        }
    }
}
