using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    int health { get; }
    void DoDamage(int damage, string player);
    void Freeze(float time);
    void Slow(float time, float strength);

    //Is-A implementatie?
    void Experience(float xp, string player);
}
