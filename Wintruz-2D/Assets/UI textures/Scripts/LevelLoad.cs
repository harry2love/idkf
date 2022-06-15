using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour
{
    public void LoadLv1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Loadlv2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void Loadlv3()
    {
        SceneManager.LoadScene("Level3");
    }
}
