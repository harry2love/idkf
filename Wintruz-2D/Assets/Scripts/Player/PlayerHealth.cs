using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth = 100;
    public int currentHealth;
    public HealtBar healtBar;

    public AudioSource source;
    public AudioClip hitSound;

    Health health;
    void Start()
    {
        currentHealth = maxHealth;
        healtBar.SetMaxHealth(maxHealth);


        health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        source.PlayOneShot(hitSound);
        healtBar.SetHealth(currentHealth);
    }

    public void Heal()
    {
        if(currentHealth != 0)
        {
            currentHealth += 40;
            healtBar.SetHealth(currentHealth);
        }
    }
}
