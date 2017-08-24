using UnityEngine;
using System.Collections.Generic;
using System;


[Serializable]
public class Effects
{
    public string Name;

    public Transform AttachTo;
    public bool isChild;
    public GameObject Effect;
    public Vector3 Direction;
    public float LifeTime;
    bool active;

    public bool Active
    {
        get
        {
            return active;
        }

        set
        {
            active = value;
        }
    }
}


