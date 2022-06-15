using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEnemy : MonoBehaviour, IEnemy
{
    public int health { get; private set; }
    [SerializeField] private int Health;

    // Start is called before the first frame update
    void Start()
    {
        health = Health;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) Death();
    }

    public void DoDamage(int damage, string player)
    {
        health -= damage;
    }

    public void Freeze(float time)
    {
        Debug.Log("Freeze doesn't affect non-active enemy");
    }

    public void Slow(float time, float strength)
    {
        Debug.Log("Slow doesn't affect a non-moving enemy");
    }

    public void Experience(float xp, string player)
    {
        Debug.Log("exp systeem moet nog geïmplement worden");
    }

    private void Death()
    {
        Debug.Log(gameObject.name + " has died");
        Destroy(gameObject);
    }

}
