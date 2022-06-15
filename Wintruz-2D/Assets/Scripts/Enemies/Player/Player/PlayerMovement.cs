using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerMovement : MonoBehaviour, IPlayer
{
    protected Rigidbody2D rb;
    private GameObject pickupObject;
    public HealtBar healthbar;

    protected IWeaponBehaviour WeaponBehaviour;
    protected IWeaponBehaviour possibleWeaponBehaviour;

    public enum KeyboardLayout { azerty, qwerty, custom}
    protected KeyboardLayout layout;

    protected int health;

    protected float acceleration;
    protected float accelerationMultiplier;

    protected float maxVelocity;
    protected float maxVelocityMultiplier;

    protected float jumpForce;

    protected bool UppressedDown;
    protected bool DownpressedDown;
    protected bool LeftpressedDown;
    protected bool RightpressedDown;
    protected bool JumppressedDown;

    protected bool AcceleratepressedDown;
    protected bool A1pressedDown;
    protected bool A2pressedDown;
    protected bool WeaponpressedDown;
    protected bool PassivepressedDown;

    protected bool PickuppressedDown;

    private bool grounded = false;
    private bool canPickup = false;
    private bool unhittable = false;

    protected KeyCode up;
    protected KeyCode down;
    protected KeyCode left;
    protected KeyCode right;
    protected KeyCode jump;

    protected KeyCode accelerate;
    protected KeyCode A1;
    protected KeyCode A2;
    protected KeyCode Weapon;
    protected KeyCode Passive;

    protected KeyCode Pickup;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if(RightpressedDown) rb.AddForce(Vector2.right * acceleration * accelerationMultiplier * Time.fixedDeltaTime);
        if(LeftpressedDown) rb.AddForce(Vector2.left * acceleration * accelerationMultiplier * Time.fixedDeltaTime);

        if (JumppressedDown && grounded) 
        {
            grounded = false;
            rb.AddForce(Vector2.up * Time.fixedDeltaTime * jumpForce, ForceMode2D.Impulse);
        }
    }

    public IEnumerator invulnerable(float time)
    {
        unhittable = true;
        yield return new WaitForSeconds(time);
        unhittable = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") grounded = true;
        else grounded = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") grounded = false;
    }

    public void ChangeLayout(KeyboardLayout layout)
    {
        this.layout = layout;
    }

    public void DoDamage(int damage)
    {
        if (!unhittable)
        {
            health -= damage;
        }
    }

    protected void SetLayout()
    {
        switch (layout)
        {
            case KeyboardLayout.azerty:
                up = KeyCode.Z;
                down = KeyCode.S;
                left = KeyCode.Q;
                right = KeyCode.D;
                jump = KeyCode.Space;

                accelerate = KeyCode.LeftShift;
                A1 = KeyCode.A;
                A2 = KeyCode.E;
                Weapon = KeyCode.F;
                Passive = KeyCode.R;

                Pickup = KeyCode.T;
                
                break;

            case KeyboardLayout.qwerty:
                up = KeyCode.W;
                down = KeyCode.S;
                left = KeyCode.A;
                right = KeyCode.D;
                jump = KeyCode.Space;

                accelerate = KeyCode.LeftShift;
                A1 = KeyCode.Q;
                A2 = KeyCode.E;
                Weapon = KeyCode.F;
                Passive = KeyCode.R;

                Pickup = KeyCode.T;

                break;

            case KeyboardLayout.custom:
                break;
        }
    }

    protected void InputDetection()
    {
        if (Input.GetKeyDown(up)) UppressedDown = true;
        else if (Input.GetKeyUp(up)) UppressedDown = false;

        if (Input.GetKeyDown(down)) DownpressedDown = true;
        else if (Input.GetKeyUp(down)) DownpressedDown = false;

        if (Input.GetKeyDown(left)) LeftpressedDown = true;
        else if (Input.GetKeyUp(left)) LeftpressedDown = false;

        if (Input.GetKeyDown(KeyCode.D)) RightpressedDown = true;
        else if (Input.GetKeyUp(KeyCode.D)) RightpressedDown = false;

        if (Input.GetKeyDown(jump)) JumppressedDown = true;
        else if (Input.GetKeyUp(jump)) JumppressedDown = false;

        if (Input.GetKeyDown(accelerate))
        {
            AcceleratepressedDown = true;
            acceleration *= accelerationMultiplier;
            maxVelocity *= maxVelocityMultiplier;
        }
        else if (Input.GetKeyUp(accelerate))
        {
            AcceleratepressedDown = false;
            acceleration /= accelerationMultiplier;
            maxVelocity /= maxVelocityMultiplier;
        }

        if (Input.GetKeyDown(A1)) A1pressedDown = true;
        else if (Input.GetKeyUp(A1)) A1pressedDown = false;

        if (Input.GetKeyDown(A2)) A2pressedDown = true;
        else if (Input.GetKeyUp(A2)) A2pressedDown = false;

        if(Input.GetKeyDown(Weapon)) WeaponpressedDown = true;
        else if(Input.GetKeyUp(Weapon)) WeaponpressedDown = false;

        if(Input.GetKeyDown(Passive)) PassivepressedDown = true;
        else if(Input.GetKeyUp(Passive)) PassivepressedDown = false;

        //Velocity limitatie
        if (rb.velocity.x > maxVelocity) rb.velocity = new Vector2(maxVelocity, rb.velocity.y);
        if (rb.velocity.x < -maxVelocity) rb.velocity = new Vector2(-maxVelocity, rb.velocity.y);

        //Utility
        if (WeaponpressedDown)
        {
            WeaponBehaviour.Weapon(gameObject);
        }
        if (PassivepressedDown)
        {
            WeaponBehaviour.Passive(gameObject);
        }

        if (PickuppressedDown && canPickup)
        {
            WeaponBehaviour = possibleWeaponBehaviour;
        }
    }

    public void CanChangeWeapon(IWeaponBehaviour weapon, GameObject gameobject)
    {
        possibleWeaponBehaviour = weapon;
        pickupObject = gameobject;
        canPickup = true;
    }

    public void CannotChangeWeapon()
    {
        canPickup = false;
        possibleWeaponBehaviour = null;
    }
}
