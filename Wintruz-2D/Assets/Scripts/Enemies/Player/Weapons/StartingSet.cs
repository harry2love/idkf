using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingSet : MonoBehaviour, IWeaponBehaviour
{
    private GameObject bullet;
    private List<GameObject> bullets;

    private Vector3 offset;
    private float weaponCooldown = 1;
    private float passiveCooldown = 1;

    private float passiveTime = 5;

    private bool weaponCD = false;
    private bool passiveCD = false;
    private bool passiveActive = false;

    private int damage = 1;
    private int strengthenedDamage = 4;

    // Start is called before the first frame update
    void Start()
    {
        bullets = new List<GameObject>();
        bullet = Resources.Load<GameObject>("Prefabs/Bullet");
    }

    // Update is called once per frame
    void Update()
    {
        if (passiveActive)
        {
            foreach (var bullet in bullets)
            {
                bullet.gameObject.GetComponent<BulletScript>().Strengthen();
            }
            bullets.Clear();
        }
    }

    public void Passive(GameObject player)
    {
        if (!passiveCD)
        {
            StartCoroutine(Passive());
            StartCoroutine(Cooldown(passiveCooldown));
        }
    }

    public void Weapon(GameObject player)
    {
        if (!weaponCD)
        {
            GameObject bul = Instantiate(bullet, player.transform.position + offset, bullet.transform.rotation);
            bul.GetComponent<BulletScript>().Setup(gameObject, damage, strengthenedDamage);
            bullets.Add(bul);
            StartCoroutine(Cooldown(weaponCooldown));
        }
    }

    private IEnumerator Cooldown(float cooldown)
    {
        if(cooldown == weaponCooldown)
        {
            weaponCD = true;
            yield return new WaitForSeconds(weaponCooldown);
            weaponCD = false;
        }
        else if(cooldown == passiveCooldown)
        {
            passiveCD = true;
            yield return new WaitForSeconds(passiveCooldown);
            passiveCD = false;
        }
    }

    private IEnumerator Passive()
    {
        passiveActive = true;
        yield return new WaitForSeconds(passiveTime);
        passiveActive = false;
    }

    public void RemoveFromList(GameObject bullet)
    {
        bullets.Remove(bullet);
    }
}
