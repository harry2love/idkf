using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4Health : MonoBehaviour
{
    public int maxHealth = 1000;
    public int currentHealth;
    public HealtBar healtBar;
    public bool startBoss = false;
    public bool shootFaster = false;
    public bool shootAtFastestSpeed = false;

    public AudioSource source;
    public AudioClip hitSound;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healtBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(maxHealth != currentHealth)
        {
            startBoss = true;
        }

        //for the enemy4DealDamage
        if(currentHealth <= maxHealth/1.5f)
        {
            shootFaster = true;
        }
        if(currentHealth <= maxHealth/3)
        {
            shootAtFastestSpeed = true;
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healtBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            source.PlayOneShot(hitSound);
        }
    }
}
