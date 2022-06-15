using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject Bullet;

    public AudioSource source;
    public AudioClip shootSound;

    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(Bullet, firePoint.position, firePoint.rotation);
            source.PlayOneShot(shootSound);
        }
    }
}
