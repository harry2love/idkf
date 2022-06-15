using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBulletlvl1 : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Vector3 bulletpos;
    [SerializeField] private float startWaitTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait(startWaitTime));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Fire()
    {
        yield return new WaitForSeconds(2);
        Instantiate(bullet, bulletpos, gameObject.transform.rotation);
        StartCoroutine(Fire());
    }
    private IEnumerator Wait(float sec)
    {
        yield return new WaitForSeconds(sec);
        StartCoroutine(Fire());
    }
}
