using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static GameEvents Ev;

    private void Awake()
    {
        Ev = this;
    }

    public event Action OnPressFloorButtton;
    public void PlatformActive()
    {
        if (OnPressFloorButtton != null)
        {
            OnPressFloorButtton();
        }
    }

    public event Action PlatformDown;
    public void FallDown()
    {
        if (PlatformDown != null)
        {
            PlatformDown();
        }
    }

    public event Action Boost;
    public void BoostSpeed()
    {
        if (Boost != null)
        {
            Boost();
        }
    }
}
