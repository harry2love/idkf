using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudio : MonoBehaviour
{
    public GameAudio audio;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(audio);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
