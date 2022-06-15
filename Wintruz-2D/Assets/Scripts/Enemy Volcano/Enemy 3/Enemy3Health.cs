using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Health : MonoBehaviour, IEnemy
{
    public int maxHealth = 25;
    public int currentHealth;
    public HealtBar healtBar;

    public AudioSource source;
    public AudioClip hitSound;
    public int health => throw new System.NotImplementedException();

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healtBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        source.PlayOneShot(hitSound);
        healtBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    private IEnumerator Slow(float time)
    {
        gameObject.GetComponent<Enemy1Movement>().Slow(2);
        yield return new WaitForSeconds(time);
        gameObject.GetComponent<Enemy1Movement>().Slow(0.5f);
    }

    public void DoDamage(int damage, string player)
    {
        TakeDamage(damage);
    }

    public void Freeze(float time)
    {
        Debug.Log("Enemy cannot be frozen. He melts the ice immediately");
    }

    public void Slow(float time, float strength)
    {
        StartCoroutine(Slow(time));
    }

    public void Experience(float xp, string player)
    {
        throw new System.NotImplementedException();
    }
}
