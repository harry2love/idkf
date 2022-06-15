using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectTileEnemy2 : MonoBehaviour
{
    public Rigidbody2D rb;

    float speed = 17.5f;
    void Update()
    {
        rb.velocity = transform.right * speed;
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

        if(collision.gameObject.tag == "Enemy2Barriers")
        {
            Destroy(gameObject);
        }
    }

}
