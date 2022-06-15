using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoad : MonoBehaviour
{

    void Update()
    {
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Menu"))
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
            DontDestroyOnLoad(gameObject);
        }
       
    }
}
