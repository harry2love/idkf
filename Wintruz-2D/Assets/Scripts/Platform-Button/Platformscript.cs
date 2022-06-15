using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformscript : MonoBehaviour, IPlatform
{
    public enum direction { up, down, left, right, neutral }
    public enum collisionaction { neutral, reverse, delete }
    public enum collisiontype { rigidbody, boxcollider}

    private GameObject buttonObject;

    [SerializeField] private bool keepWorkingWithButton;
    [SerializeField] private string buttonName = null;
    [SerializeField] private collisionaction act;
    [SerializeField] private direction dir;
    [SerializeField] private float speed = 1;

    void Start()
    {
        if(buttonName != "")
        {
            if (!keepWorkingWithButton) dir = direction.neutral;

            buttonObject = GameObject.Find(buttonName);
            buttonObject.GetComponent<ButtonScript>().Observing(this);
        }
        GameObject.Find("GameManager").GetComponent<GameManager>().AddPlatform(this);
    }


    void FixedUpdate()
    {
            switch (dir)
            {
                case direction.up:
                    transform.Translate(Vector3.up * Time.fixedDeltaTime * speed);
                    break;
                case direction.down:
                    transform.Translate(Vector3.down * Time.fixedDeltaTime * speed);
                    break;
                case direction.left:
                    transform.Translate(Vector3.left * Time.fixedDeltaTime * speed);
                    break;
                case direction.right:
                    transform.Translate(Vector3.right * Time.fixedDeltaTime * speed);
                    break;
                case direction.neutral:
                //nothing
                default:
                    break;
            }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (act == collisionaction.reverse)
        {
            switch (dir)
            {
                case direction.up:
                    dir = direction.down;
                    break;
                case direction.down:
                    dir = direction.up;
                    break;
                case direction.left:
                    dir = direction.right;
                    break;
                case direction.right:
                    dir = direction.left;
                    break;
                default:
                    break;
            }
        }

        else if (act == collisionaction.delete)
        {
            Destroy(gameObject);
        }

        else if (act == collisionaction.neutral)
        {
            dir = direction.neutral;
        }
    }

    public void ButtonAction()
    {
        direction dir1 = (direction)buttonObject.GetComponent<ButtonScript>().Dir;
        dir = dir1;
        Debug.Log("Werkt");
    }

    public void WorkWhenButtonExists(bool YesNo)
    {
        keepWorkingWithButton = YesNo;
    }

    public void ChangeSpeed(float speed)
    {
        this.speed = speed;
    }

    public void MassDirectionChange(IPlatform.direction dir)
    {
        this.dir = (direction)dir;
    }
}
