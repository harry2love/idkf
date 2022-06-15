using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private List<IPlatform> platforms = new List<IPlatform>();
    [SerializeField] private GameObject player;
    [SerializeField] private string finalEnemy;

    public AudioSource source;
    public AudioClip gameOverSound;
    bool gameOver = false;

    public PlayerHealth playerHealth;
    //TODO Remove platform implementatie in GameManager

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (finalEnemy != "" && GameObject.Find(finalEnemy) == null)
        {
            SceneManager.LoadScene("Level2");
        }

        if (playerHealth.currentHealth <= 0)
        {
            Debug.Log("GAME OVER");
            gameOver = true;
            Invoke("Restart", 1.2f);
            source.PlayOneShot(gameOverSound);
        }
            
    }

    public void AddPlatform(IPlatform platform)
    {
        platforms.Add(platform);
    }


    void Restart()
    {
        SceneManager.LoadScene("Level1");
    }
}
