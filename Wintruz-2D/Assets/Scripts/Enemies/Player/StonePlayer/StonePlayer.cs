using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StonePlayer : PlayerMovement
{

    private GameObject Wall;

    private bool shortCooldown = false;

    [SerializeField] private float invulerableTime = 5;

    private int wallCount = 1;
    private int maxWallCount = 2;
    // Start is called before the first frame update
    void Start()
    {
        SetLayout();

        this.rb = GetComponent<Rigidbody2D>();
        this.layout = KeyboardLayout.azerty;
        this.health = 10;
        this.acceleration = 1000;
        this.accelerationMultiplier = 2;
        this.maxVelocity = 10;
        this.maxVelocityMultiplier = 1.5f;
        this.jumpForce = 500;
        this.WeaponBehaviour = gameObject.AddComponent<StartingSet>();
    }

    // Update is called once per frame
    void Update()
    {
        InputDetection();

        if (A1pressedDown)
        {
            StartCoroutine(invulnerable(invulerableTime));
        }

        if (A2pressedDown && wallCount < maxWallCount && !shortCooldown)
        {
            StartCoroutine(StoneWall());
        }
    }


    private IEnumerator StoneWall()
    {

        yield return new WaitUntil(() => Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Escape));

        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(ClickCooldown());

            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;

            GameObject wall = (GameObject)Instantiate(Wall, position, transform.rotation);

        }
        else
        {
            Debug.Log("Cancelled");
            wallCount -= 1;
        }

    }

    private IEnumerator ClickCooldown()
    {
        yield return new WaitForSeconds(0.5f);
        shortCooldown = false;
    }

    public void WallDone()
    {
        wallCount -= 1;
    }
}
