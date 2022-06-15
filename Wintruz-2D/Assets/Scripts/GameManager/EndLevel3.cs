using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel3 : MonoBehaviour
{
    public Enemy4Health health;
    float timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health.currentHealth <= 0)
        {
            timer += Time.deltaTime;
        }
        if (timer > 1.25f)
        {
            SceneManager.LoadScene("ThanksForPlaying");
        }
    }
}
