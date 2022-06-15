using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float maxX;
    [SerializeField] private float minX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.x > maxX)
        {

        }

        if(gameObject.transform.position.x < minX)
        {

        }
    }

    private void FixedUpdate()
    {
        
    }
}
