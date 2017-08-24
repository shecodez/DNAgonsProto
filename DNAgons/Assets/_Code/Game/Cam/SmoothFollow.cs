using UnityEngine;

public class SmoothFollow : MonoBehaviour {

    public Transform target;
    public float cameraSpeed = 12f;
    public float zOffset = 9f;
    public bool smoothFollow = true;
	
	void Update () {

        if (target)
        {
            Vector3 _newPos = transform.position;
            _newPos.x = target.position.x;
            _newPos.z = target.position.z - zOffset;

            if (smoothFollow)
                transform.position = Vector3.Lerp(transform.position, _newPos, cameraSpeed * Time.deltaTime);
            else
                transform.position = _newPos;
        }
        else
            Debug.LogError("SmoothFollow.cs missing a target");
	}
}
