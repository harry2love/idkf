using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePlayer : PlayerMovement
{

    //Freezeray
    private LineRenderer freezeRay;
    private Vector3 firepos;

    private bool active = false;
    private bool follow = false;

    [SerializeField] private float freezerayFireCooldown = 2;
    [SerializeField] private float freezerayActiveTime = 1;
    [SerializeField] private float freezerayChargeTime = 2;
    [SerializeField] private float freezerayDistance = 10;
    [SerializeField] private float freezerayChargeWidth = 1;
    [SerializeField] private float freezerayFireWidth = 5;

    [SerializeField] private float freezeTime = 5;
    [SerializeField] private int damage = 10;

    //Snowstorm
    private bool shortCooldown = false;
    private float stormCount = 0;
    [SerializeField] private float maxStorms = 1;

    private GameObject snowstorm;

    [SerializeField] private float stormDuration;
    [SerializeField] private float stormActivationTime;
    [SerializeField] private float maxStormSize;
    [SerializeField] private float expansionRate;

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

        snowstorm = Resources.Load<GameObject>("Prefabs/Circle");
    }

    // Update is called once per frame
    void Update()
    {
        InputDetection();

        //Freezeray
        firepos = transform.position + new Vector3(gameObject.GetComponent<Collider2D>().bounds.size.x / 2, 0, 0);

        if (A1pressedDown && !active)
        {
                StartCoroutine(FreezeRay());
                active = true;
        }
        if (follow)
        {
            freezeRay.SetPosition(0, firepos);
            freezeRay.SetPosition(1, firepos + new Vector3(freezerayDistance, 0, 0));
        }

        //Snowstorm
        if (A2pressedDown && stormCount < maxStorms && !shortCooldown)
        {
            shortCooldown = true;
            StartCoroutine(SnowStorm());
            stormCount += 1;
            StartCoroutine(ClickCooldown());
        }
        
    }

    private IEnumerator FreezeRay()
    {

        Debug.Log("Charging");

        freezeRay = new GameObject("ChargeLine").AddComponent<LineRenderer>();
        freezeRay.startColor = Color.blue;
        freezeRay.endColor = Color.blue;
        freezeRay.startWidth = freezerayChargeWidth;
        freezeRay.endWidth = freezerayChargeWidth;
        freezeRay.positionCount = 2;
        freezeRay.useWorldSpace = true;
        follow = true;
        

        yield return new WaitForSeconds(freezerayChargeTime);


        Debug.Log("Fire");

        follow = false;

        freezeRay.startColor = Color.red;
        freezeRay.endColor = Color.red;
        freezeRay.startWidth = freezerayFireWidth;
        freezeRay.endWidth = freezerayFireWidth;
        freezeRay.SetPosition(0, firepos);
        freezeRay.SetPosition(1, firepos + new Vector3(freezerayDistance, 0, 0));

        RaycastHit2D[] hit = Physics2D.CircleCastAll(firepos, freezerayFireWidth, Vector2.right, freezerayDistance);
        foreach (var enemy in hit)
        {
            if (enemy.collider.gameObject.GetComponent<IEnemy>() != null)
            {
                enemy.collider.gameObject.GetComponent<IEnemy>().DoDamage(damage, gameObject.name);
                enemy.collider.gameObject.GetComponent<IEnemy>().Freeze(freezeTime);
                Debug.Log(enemy.collider.name + " is hit");
            }
        }

        yield return new WaitForSeconds(freezerayActiveTime);
        Destroy(freezeRay);


        yield return new WaitForSeconds(freezerayFireCooldown);

        Debug.Log("Weapon Ready");

        active = false;
    }

    //Snowstorm
    private IEnumerator SnowStorm()
    {

        yield return new WaitUntil(() => Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Escape));

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;

            GameObject storm = (GameObject)Instantiate(snowstorm, position, transform.rotation);
            storm.GetComponent<SnowStorm>().Activate(gameObject, stormDuration, stormActivationTime, maxStormSize, expansionRate);

        }
        else
        {
            Debug.Log("Cancelled");
            stormCount -= 1;
        }

    }

    private IEnumerator ClickCooldown()
    {
        yield return new WaitForSeconds(0.5f);
        shortCooldown = false;
    }

    public void StormDone()
    {
        stormCount -= 1;
    }
}
