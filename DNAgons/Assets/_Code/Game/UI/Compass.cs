using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour {

    public Vector3 northDir;
    public Transform player;

    public RectTransform needle;

    void Update ()
    {
        OnChangeNorthDirection();
    }

    public void OnChangeNorthDirection()
    {
        northDir.z = player.eulerAngles.y +45;
        needle.localEulerAngles = northDir;
    }
}
