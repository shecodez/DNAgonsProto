using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOnPinch : MonoBehaviour {

    float previousDistance;
    float zoomSpeed = 1.0f;

    // https://www.youtube.com/watch?v=ae6CyngEG-U
    void Update () {
	    if(Input.touchCount == 2 && (Input.GetTouch(0).phase ==TouchPhase.Began || Input.GetTouch(1).phase == TouchPhase.Began))
        {
            // Calibrate distance
            previousDistance = Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);
        }
        else if (Input.touchCount == 2 && (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(1).phase == TouchPhase.Moved))
        {
            float _distance;
            Vector2 _touch1 = Input.GetTouch(0).position;
            Vector2 _touch2 = Input.GetTouch(1).position;

            _distance = Vector2.Distance(_touch1, _touch2);

            // Zoom In/Out On Pinch
            float _pinchAmt = (previousDistance - _distance) * zoomSpeed * Time.deltaTime;
            if (Camera.main.orthographic)
            {
                Camera.main.orthographicSize += _pinchAmt;
            }
            else
            {
                Camera.main.transform.Translate(0, 0, _pinchAmt);
            }

            previousDistance = _distance;
        }
    }
}
