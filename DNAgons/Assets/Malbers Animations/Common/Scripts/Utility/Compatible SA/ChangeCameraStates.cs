using UnityEngine;
using System.Collections;


namespace MalbersAnimations
{
    public class ChangeCameraStates : MonoBehaviour
    {
        public MFreeLookCamera mCamera;
        public CameraStateData States;
        public float transition = 1f;
        public MCamState currentState;

        private MCamState NextState;

        bool inTransition;
        private bool isAiming;

        // Use this for initialization
        void Start()
        {
            currentState = FindState("Default");
            inTransition = false;
        }

        public void isMounted(bool enable)
        {
            if (enable)     SetCameraState("Mounted");
            else            SetCameraState("Default");
        }

        public void RiderAimRight()
        {
            SetCameraState("RiderAimRight");
        }

        public void RiderAimLeft()
        {
            SetCameraState("RiderAimLeft");
        }

        // Update is called once per frame
        void Update()
        {
            if (!inTransition)
            {
                UpdateState(currentState);
            }
        }

        void UpdateState(MCamState state)
        {
            mCamera.Pivot.localPosition = state.PivotPos;
            mCamera.Cam.localPosition = state.CamPos;
            mCamera.Cam.GetComponent<Camera>().fieldOfView = state.Cam_FOV;
        }

      public void SetCameraState(string name)
        {
            NextState = FindState(name);

            if (NextState.Name == currentState.Name) return;

            StopAllCoroutines();
            StartCoroutine(StateTransition(transition));
        }

        IEnumerator StateTransition(float time)
        {
            inTransition = true;
            float elapsedTime = 0;
            currentState = NextState;
            while (elapsedTime < time)
            {
                mCamera.Pivot.localPosition = Vector3.Lerp(mCamera.Pivot.localPosition, NextState.PivotPos, Mathf.SmoothStep(0, 1, elapsedTime / time));
                mCamera.Cam.localPosition = Vector3.Lerp(mCamera.Cam.localPosition, NextState.CamPos, Mathf.SmoothStep(0, 1, elapsedTime / time));
                mCamera.Cam.GetComponent<Camera>().fieldOfView = Mathf.Lerp(mCamera.Cam.GetComponent<Camera>().fieldOfView, NextState.Cam_FOV, Mathf.SmoothStep(0, 1, elapsedTime / time));
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            UpdateState(NextState);
            inTransition = false;
        }

        MCamState FindState(string name)
        {
            foreach (MCamState camstate in States.StateCameraList)
            {
                if (camstate.Name == name)
                {
                   return camstate;
                }
            }
            return null;
        }
    }
}