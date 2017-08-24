using UnityEngine;
using UnityEngine.UI;

public class RadialMenu : MonoBehaviour {

    public RadialButton buttonPrefab;
    public float size = 100f;

    public RadialButton selected;

	public void SpawnButtons (Interactable go)
    {
        for (int i = 0; i < go.options.Length; i++)
        {
            RadialButton _newButton = Instantiate(buttonPrefab) as RadialButton;
            _newButton.transform.SetParent(transform, false);

            float _theta = (2 * Mathf.PI / go.options.Length) * i;
            float _xPos = Mathf.Sin(_theta);
            float _yPos = Mathf.Cos(_theta);
            _newButton.transform.localPosition = new Vector3(_xPos, _yPos, 0f) * size;

            _newButton.button.GetComponent<Image>().color = go.options[i].color;
            _newButton.rBtnIcon.sprite = go.options[i].icon;
            _newButton.rBtnName = go.options[i].name;
            _newButton.rMenu = this;
        }        
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (selected)
            {
                // Handle button action
                Debug.Log(selected.rBtnName + " was selected");
            }
            Destroy(this.gameObject);
        }
    }
}
