using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        bullet = (GameObject)Instantiate(Resources.Load("Circle 1"));
        StartCoroutine(Fire());
    }

    // Update is called once per frame
    void Update()
    {
        LookAt2D(transform, GameObject.Find("Player").transform.position);
    }

    public static void LookAt2D(Transform transform, Vector2 target)
    {
        Vector2 current = transform.position;
        var direction = target - current;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    IEnumerator Fire()
    {
        if (GetComponent<Renderer>().isVisible)
        {
            Debug.Log("Visible");
        }
            Instantiate(bullet, transform.position, transform.rotation);
        
        yield return new WaitForSeconds(3);
        StartCoroutine(Fire());
    }
}
