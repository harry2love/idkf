using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2DealDamage : MonoBehaviour
{
    public Transform firePoint;
    public GameObject Bullet;

    float timer;
    int waitTime = 2;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > waitTime)
        {
            Instantiate(Bullet, firePoint.position, firePoint.rotation);
            timer = 0;
        }
    }

}
