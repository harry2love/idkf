using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private GameObject owner;
    private int damage = 1;
    private int strengthenedDamage = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * 10);
    }

    public void Strengthen()
    {
        damage = strengthenedDamage;
        Debug.Log("strengthened");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<IEnemy>() != null)
        {
            collision.gameObject.GetComponent<IEnemy>().DoDamage(damage, owner.name);
            owner.GetComponent<StartingSet>().RemoveFromList(gameObject);
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.GetComponent<IPlayer>() != null)
        {
            collision.gameObject.GetComponent<IPlayer>().DoDamage(2);
            Destroy(gameObject);
        }




        if (collision.gameObject.tag == "Player")
        {
            PlayerHealth playerhealth = collision.GetComponent<PlayerHealth>();
            if (playerhealth != null)
            {
                playerhealth.TakeDamage(20);
            }
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Enemy2Barriers")
        {
            Destroy(gameObject);
        }
    }

    public void Setup(GameObject owner, int damage, int strengthenedDamage)
    {
        this.owner = owner;
        this.damage = damage;
        this.strengthenedDamage = strengthenedDamage;
    }
}
