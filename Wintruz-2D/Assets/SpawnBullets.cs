using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullets : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator spawn()
    {
        yield return new WaitForSeconds(Random.Range(0.5f, 2));
        Instantiate(bullet, gameObject.transform.position - new Vector3(0, 1.5f, 0), gameObject.transform.rotation);
        StartCoroutine(spawn());
    }
}
