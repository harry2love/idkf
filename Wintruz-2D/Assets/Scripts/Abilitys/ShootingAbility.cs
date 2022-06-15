using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAbility : MonoBehaviour
{
    private GameObject Player;
    public GameObject ProjectTile;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == Player)
        {
            Destroy(gameObject);
            StartCoroutine(ShootAbility(10));
        }
    }

    public IEnumerator ShootAbility(int waitSeconds)
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            Shoot();
        }

        yield return new WaitForSeconds(waitSeconds);
    }

    public void Shoot()
    {
        Debug.Log("Yes you shot");
        Instantiate(ProjectTile, Player.transform.position, Player.transform.rotation);
    }
}
