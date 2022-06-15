using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour, IButton
{
    private List<IPlatform> observers = new List<IPlatform>();

    public enum direction { up, down, left, right, neutral }

    private bool clickable = true;

    [SerializeField] private float clickCooldown = 1;
    [SerializeField] private direction dir;
    [SerializeField] private bool reversedActionOnSecondClick = false;
    [SerializeField] private float newSpeed = 0;

    public direction Dir => dir;


    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);


            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if(hit == true && hit.transform.GetComponent<ButtonScript>() != null && clickable)
            {
                Alarm();

                if (reversedActionOnSecondClick)
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
                        case direction.neutral:
                            //Niks veranderd
                            break;
                        default:
                            break;
                    }
                }

                if(newSpeed <= 0)
                {

                }
                else
                {
                    foreach  (IPlatform observer in observers)
                    {
                        observer.ChangeSpeed(newSpeed);
                    }
                }
                StartCoroutine(ClickCooldown());
            }
        }
    }

    public void Observing(IPlatform observer)
    {
        observers.Add(observer);
    }

    private void Alarm()
    {
        foreach (IPlatform observer in observers)
        {
            observer.ButtonAction();
        }
    }


    public void ChangeDirection(direction Dir)
    {
        dir = Dir;
    }

    IEnumerator ClickCooldown()
    {
        if(clickCooldown != 0)
        {
            clickable = false;
            yield return new WaitForSeconds(clickCooldown);
            clickable = true;
        }
        else if(clickCooldown >= 100)
        {
            clickable = false;
        }
    }
}
