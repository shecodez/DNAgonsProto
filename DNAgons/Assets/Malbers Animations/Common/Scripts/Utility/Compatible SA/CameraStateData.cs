using UnityEngine;
using System.Collections.Generic;
using System;
namespace MalbersAnimations
{
    /// <summary>
    /// Used To change States from a camera to another
    /// </summary>
    [Serializable]
    public class MCamState
    {
        public string Name;
        public Vector3 PivotPos;
        public Vector3 CamPos;
        public float Cam_FOV;

        public MCamState(string name)
        {
            this.Name = name;
            this.Cam_FOV = 45;
            this.PivotPos = new Vector3(0, 1f, 0);
            this.CamPos = new Vector3(0, 0, -4.45f);
        }
    }
    [CreateAssetMenu(menuName = "MalbersAnimations/CameraStateList")]
    public class CameraStateData : ScriptableObject
    {
        public string Name;
        public List<MCamState> StateCameraList;

        public CameraStateData()
        {
            StateCameraList = new List<MCamState>();
            StateCameraList.Add(new MCamState("Default"));
        }
    }
}
