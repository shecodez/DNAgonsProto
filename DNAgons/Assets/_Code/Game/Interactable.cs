using UnityEngine;

[System.Serializable]
public class Action
{
    public string name;
    public Sprite icon;
    public Color color;
}

public class Interactable : MonoBehaviour {

    public Action[] options;

	void OnMouseDown()
    {
        RadialMenuManager.Instance.SpawnRadialMenu(this);
        //MenuManager.Instance.DisplayRadialMenu(this);
    }
}
