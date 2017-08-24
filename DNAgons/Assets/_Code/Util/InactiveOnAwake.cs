using UnityEngine;

public class InactiveOnAwake : MonoBehaviour {

	void Awake ()
    {
        this.gameObject.SetActive(false);
    }
}
