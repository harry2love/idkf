using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    private Rigidbody2D rb;
    public float jumpForce = 300;

    [SerializeField] private float speed = 300;
    [SerializeField] private float maxVelocity = 20;
    [SerializeField] private float health = 10;
    [SerializeField] private float maxShiftVelocity = 30;

    public bool canJump = true;
    private bool dPressedDown = false;
    private bool qPressedDown = false;
    private bool aPressedDown = false;
    private bool spacePressedDown = false;
    public bool shiftPressedDown = false;
    float inputHorizontal;
    float savedMaxVelocity;
    bool facingRight = true;

    public AudioSource source;
    public AudioClip jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        savedMaxVelocity = maxVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        //for animations
        if (qPressedDown || dPressedDown)
        {
            animator.SetFloat("Speed", 1);
        }
        if(!qPressedDown && !dPressedDown)
        {
            animator.SetFloat("Speed", 0);
        }

        if(spacePressedDown)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }

        if (shiftPressedDown)
        {
            animator.SetBool("Shift", true);
        }
        else
        {
            animator.SetBool("Shift", false);
        }

        if(canJump)
        {
            animator.SetBool("isOnGround", true);
        }
        else
        {
            animator.SetBool("isOnGround", false);
        }
        //for animations

        if (Input.GetKey(KeyCode.D))
        {
            dPressedDown = true;
        }
        else 
        {
            dPressedDown = false;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            CounterMovemement(true);
        }


        if (Input.GetKey(KeyCode.Q))
        {
            qPressedDown = true;
        }
        else 
        {
            qPressedDown = false;
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            CounterMovemement(false);
        }



        if (Input.GetKey(KeyCode.Space))
        {
            spacePressedDown = true;
        }
        else 
        {
            spacePressedDown = false;
        }



        if (Input.GetKey(KeyCode.LeftShift))
        {
            shiftPressedDown = true;
        }
        else 
        {
            shiftPressedDown = false;
        }

        if (inputHorizontal > 0 && !facingRight)
        {
            Flip();
        }

        else if (inputHorizontal < 0 && facingRight)
        {
            Flip();
        }

        if(rb.velocity.x < -maxVelocity || rb.velocity.x > maxVelocity)
        {
            if(rb.velocity.x < -maxVelocity)
            {
                rb.velocity = new Vector2(-maxVelocity, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(maxVelocity, rb.velocity.y);
            }
        }

    }

    private void FixedUpdate()
    {
        //player laten bewegen
            if (dPressedDown) rb.AddForce(new Vector2(speed * Time.fixedDeltaTime, 0), ForceMode2D.Force);
            if (qPressedDown) rb.AddForce(new Vector2(-speed * Time.fixedDeltaTime, 0), ForceMode2D.Force);
            if (aPressedDown) rb.AddForce(new Vector2(-speed * Time.fixedDeltaTime, 0), ForceMode2D.Force);
            if (spacePressedDown && canJump == true)
            {
                rb.AddForce(new Vector2(0, jumpForce * Time.fixedDeltaTime), ForceMode2D.Impulse);
                source.PlayOneShot(jumpSound);
            }

            if (shiftPressedDown)
            {
                maxVelocity = maxShiftVelocity;
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                maxVelocity = savedMaxVelocity;
            }
            
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" )
        {
            canJump = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = false;
        }
    }

    public void changeHealth(int value)
    {
        health += value;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void CounterMovemement(bool left)
    {
        if (left)
        {
            rb.AddForce(Vector2.left * rb.velocity.x * 20);
        }
        else
        {
            rb.AddForce(Vector2.right * rb.velocity.x * 20);
        }
    }


    private void Flip()
    {
        facingRight = !facingRight;
        
        transform.Rotate(0f, 180f, 0f);
    }
}