using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowStormEffect : MonoBehaviour
{
    private GameObject Owner;

    float expansionRate;
    float stormSize;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.localScale.x < stormSize) transform.localScale = new Vector3(transform.localScale.x + expansionRate * Time.deltaTime, transform.localScale.y, transform.localScale.z);
    }

    public void StartStorm(float stormSize, float expansionRate, GameObject owner)
    {
        this.stormSize = stormSize;
        this.expansionRate = expansionRate;
        this.Owner = owner;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<IEnemy>() != null)
        {
            collision.gameObject.GetComponent<IEnemy>().DoDamage(1, Owner.name);
            collision.gameObject.GetComponent<IEnemy>().Slow(2, 10);
        }
    }
}
