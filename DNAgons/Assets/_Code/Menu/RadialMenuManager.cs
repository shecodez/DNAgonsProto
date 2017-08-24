using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialMenuManager : MonoBehaviour {

    public static RadialMenuManager Instance;

    public RadialMenu menuPrefab;

    void Awake()
    {
        Instance = this;
    }

    public void SpawnRadialMenu(Interactable go)
    {
        RadialMenu _newMenu = Instantiate(menuPrefab) as RadialMenu;
        _newMenu.transform.SetParent(transform, false);
        _newMenu.transform.position = Input.mousePosition;
        _newMenu.SpawnButtons(go);
    }
}
