using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4DealDamage : MonoBehaviour
{
    public GameObject projectTile1;
    public GameObject projectTile2;
    public GameObject projectTile3;
    public GameObject[] ground;
    public GameObject[] platforms;
    public GameObject[] temporaryPlatforms;
    public Transform firePoint;
    Enemy4Health health;

    float RandomY;
    float timerFor1Stage;
    float timerFor2Stage;
    float timerFor3Stage;
    int waitTime = 3;

    Vector3 firePointPos;
    Quaternion firePointRotation;


    private void Start()
    {
        health = GetComponent<Enemy4Health>();
    }

    void Update()
    {
        RandomY = Random.Range(43f, 46f);
        firePointPos = new Vector3(firePoint.position.x, RandomY, firePoint.position.z);
        firePointRotation = Quaternion.Euler(firePoint.position.x, firePoint.position.y, firePoint.position.z);
        if(health.startBoss)
        {
            //for platforms to appear
            for (int i = 0; i < ground.Length; i++)
            {
                Destroy(ground[i]);
            }

            for (int i = 0; i < platforms.Length; i++)
            {
                platforms[i].SetActive(true);
            }

            for (int i = 0; i < temporaryPlatforms.Length; i++)
            {
                Destroy(temporaryPlatforms[i], 3f);
            }
            //for platforms to appear

            timerFor1Stage += Time.deltaTime;
            if (timerFor1Stage > waitTime)
            {
                Instantiate(projectTile1, firePointPos, firePointRotation);
                timerFor1Stage = 0;
            }
            if(health.shootFaster)
            {
                timerFor2Stage += Time.deltaTime;
                if(timerFor2Stage > waitTime)
                {
                    Instantiate(projectTile2, firePointPos, firePointRotation);
                    timerFor2Stage = 0;
                }
            }
            if(health.shootAtFastestSpeed)
            {
                timerFor3Stage += Time.deltaTime;
                if(timerFor3Stage > waitTime)
                {
                    Instantiate(projectTile3, firePointPos, firePointRotation);
                    timerFor3Stage = 0;
                }
            }
        }

        if(health.shootFaster)
        {
            waitTime = 2;
        }

        if(health.shootAtFastestSpeed)
        {
            waitTime = 1;
        }

    }



}
