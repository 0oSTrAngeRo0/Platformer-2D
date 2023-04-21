using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IBuff
{
    public BuffManager Manager { get; private set; }
    public float Duration { get; protected set; }

    public abstract void Start();

    public void Update(float deltaTime)
    {
        //Debug.Log(Duration);
        Duration -= deltaTime;
        if(Duration<= 0)
        {
            Stop();
            Manager.RemoveBuff(this);
        }
    }

    /// <summary>
    /// Assign the BuffManager. Can be called by once.
    /// </summary>
    /// <param name="manager"></param>
    public void AssignManager(BuffManager manager)
    {
        if (Manager == null)
        {
            Manager = manager;
        }
    }

    public abstract void Stop();
}
