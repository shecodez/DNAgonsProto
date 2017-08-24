using UnityEngine;
using System;
using System.Collections.Generic;
namespace MalbersAnimations
{
    [Serializable]
    public class MaterialItem
    {
        [SerializeField]
        public string name;
        [SerializeField]
        public bool active;
        [SerializeField]
        public Material[] materials;
        [SerializeField]
        public Transform[] meshes;
    }

    public class MaterialChanger : MonoBehaviour
    {
        public List<MaterialItem> materialList = new List<MaterialItem>();
    }
}
