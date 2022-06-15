using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowStorm : MonoBehaviour
{

    private GameObject Storm;
    private GameObject owner;

    GameObject stormEffect;

    private float stormDuration;
    private float stormActivationTime;

    private float maxStormSize;
    private float expansionRate;

    private Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Snowstorm()
    {
        

        yield return new WaitForSeconds(stormActivationTime);

        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.down);
        for(int i = 0; i < hits.Length; i++)
        {
            spawnPosition = hits[i].point;
        }
        Storm = Resources.Load<GameObject>("Prefabs/SnowStormEffect");
        stormEffect = Instantiate(Storm, spawnPosition, Storm.transform.rotation);
        stormEffect.GetComponent<SnowStormEffect>().StartStorm(maxStormSize, expansionRate, owner);


        yield return new WaitForSeconds(stormDuration);
        owner.GetComponent<IcePlayer>().StormDone();
        Destroy(gameObject);
        Destroy(stormEffect);
    }

    public void Activate(GameObject owner, float stormDuration, float stormActivationTime, float maxStormSize, float expansionRate)
    {
        this.owner = owner;

        this.stormDuration = stormDuration;
        this.stormActivationTime = stormActivationTime;
        this.maxStormSize = maxStormSize;
        this.expansionRate = expansionRate;

        StartCoroutine(Snowstorm());
    }
}