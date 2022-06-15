using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlatform
{
    public enum direction { up, down, left, right, neutral }
    abstract void ButtonAction();
    abstract void ChangeSpeed(float speed);
    abstract void WorkWhenButtonExists(bool YesNo);
    abstract void MassDirectionChange(direction dir);
}
