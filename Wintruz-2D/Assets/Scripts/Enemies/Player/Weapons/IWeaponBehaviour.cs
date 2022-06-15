using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public interface IWeaponBehaviour
{
    void Weapon(GameObject player);
    void Passive(GameObject player);
}