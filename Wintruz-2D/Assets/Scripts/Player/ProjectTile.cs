using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectTile : MonoBehaviour
{
    public Rigidbody2D rb;
    float speed = 30f;

    private void Update()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy1")
        {
            Enemy1Health enemy1Health = collision.GetComponent<Enemy1Health>();

            if (enemy1Health != null)
            {
                enemy1Health.TakeDamage(20);
            }
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Enemy2")
        {
            Enemy2Health enemy2Health = collision.GetComponent<Enemy2Health>();

            if (enemy2Health != null)
            {
                enemy2Health.TakeDamage(20);
            }
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Enemy3")
        {
            Enemy3Health enemy3Health = collision.GetComponent<Enemy3Health>();

            if (enemy3Health != null)
            {
                enemy3Health.TakeDamage(20);
            }
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Enemy4")
        {
            Enemy4Health enemy4Health = collision.GetComponent<Enemy4Health>();

            if (enemy4Health != null)
            {
                enemy4Health.TakeDamage(20);
            }
            Destroy(gameObject);
        }


    }
}
