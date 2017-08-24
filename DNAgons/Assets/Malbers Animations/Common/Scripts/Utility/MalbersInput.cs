using UnityEngine;
using System.Collections.Generic;
using System;
#if CROSS_PLATFORM_INPUT
using UnityStandardAssets.CrossPlatformInput;
#endif

namespace MalbersAnimations
{
    public enum InputType
    {
        Input, Key
    }

    public enum InputButton
    {
        Press, Down, Up
    }

    /// <summary>
    /// Input Class to change directly between Keys and Unity Inputs
    /// </summary>
    [Serializable]
    public class InputRow
    {
        public bool active = true;
        public string name = "Variable";
        public InputType type;
        public string input = "Value";
        public KeyCode key;
        public InputButton GetPressed;

        /// <summary>
        /// Return True or False to the Selected type of Input of choice
        /// </summary>
        public bool GetInput
        {
            get{
                if (!active) return false;
                switch (type)
                {
                    case InputType.Input:
                        switch (GetPressed)
                        {
                            case InputButton.Press:
                                #if !CROSS_PLATFORM_INPUT
                                return Input.GetButton(input);
                                #else
                                return  CrossPlatformInputManager.GetButton(input);
                                #endif
                            case InputButton.Down:
                                #if !CROSS_PLATFORM_INPUT
                                return Input.GetButtonDown(input);
                                #else
                                return  CrossPlatformInputManager.GetButtonDown(input);
                                #endif
                            case InputButton.Up:
                                #if !CROSS_PLATFORM_INPUT
                                return Input.GetButtonUp(input);
                                #else
                                return  CrossPlatformInputManager.GetButtonUp(input);
                                #endif
                        }
                        break;
                    case InputType.Key:
                        switch (GetPressed)
                        {
                            case InputButton.Press:
                                return Input.GetKey(key);
                            case InputButton.Down:
                                return Input.GetKeyDown(key);
                            case InputButton.Up:
                                return Input.GetKeyUp(key);
                        }
                        break;
                    default:
                        break;
                }
                return false;
            }
        }

#region Constructors
        public InputRow(string i)
        {
            active = true;
            type = InputType.Input;
            input = i;
            GetPressed = InputButton.Down;
        }

        public InputRow(KeyCode k)
        {
            active = true;
            type = InputType.Key;
            key = k;
            GetPressed = InputButton.Down;
        }

        public InputRow(string i, KeyCode k)
        {
            active = true;
            type = InputType.Key;
            key = k;
            input = i;
            GetPressed = InputButton.Down;
        }
#endregion
    }

    public class MalbersInput : MonoBehaviour
    {
        private iMalbersInputs character;
        private Vector3 m_CamForward;
        private Vector3 m_Move;
        private Transform m_Cam;
        public List<InputRow> inputs = new List<InputRow>();
        public bool cameraBaseInput;

        private float h;  //Horizontal Right & Left   Axis X
        private float v;  //Vertical   Forward & Back Axis Z
        private float ud; //Up&Down    Up & Down      Axis Y

        void Awake()
        {
            //get the animalScript
            character = GetComponent<iMalbersInputs>();
        }

        private void Start()
        {
            if (Camera.main != null)   // get the transform of the main camera
                m_Cam = Camera.main.transform;
        }


        // Fixed update is called in sync with physics
        void FixedUpdate()
        {
#if !CROSS_PLATFORM_INPUT
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");
#else
            h = CrossPlatformInputManager.GetAxis("Horizontal");
            v = CrossPlatformInputManager.GetAxis("Vertical");
#endif
            SetInput();
        }

      public virtual Vector3 CameraInputBased()
        {
            // calculate move direction to pass to character
            if (m_Cam != null)
            {
                // calculate camera relative direction to move:
                m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 1, 1)).normalized;
                m_Move = v * m_CamForward + h * m_Cam.right;
            }
            else
            {
                // we use world-relative directions in the case of no main camera
                m_Move = v * Vector3.forward + h * Vector3.right;
            }
            return m_Move;
        }

        /// <summary>
        /// Send all the Inputs to the Animal
        /// </summary>
        protected virtual void SetInput()
        {
            if (cameraBaseInput)
            {
                character.Move(CameraInputBased());
            }
            else
            {
                character.Move(new Vector3(h, 0, v), false);
            }

            if (isActive("Attack1")) character.Attack1 = GetInput("Attack1");         //Get the Attack1 button
            if (isActive("Attack2")) character.Attack2 = GetInput("Attack2");         //Get the Attack1 button

            if (isActive("Action")) character.Action = GetInput("Action");  //Get the Action/Emotion button

            if (isActive("Jump")) character.Jump = GetInput("Jump");

            if (isActive("Shift")) character.Shift = GetInput("Shift");           //Get the Shift button

            if (isActive("Fly")) character.Fly = GetInput("Fly");                //Get the Fly button 
            if (isActive("Down")) character.Down = GetInput("Down");             //Get the Down button
            if (isActive("Dodge")) character.Dodge = GetInput("Dodge");             //Get the Down button

            if (isActive("Stun")) character.Stun = GetInput("Stun");             //Get the Stun button change the variable entry to manipulate how the stun works
            if (isActive("Death")) character.Death = GetInput("Death");            //Get the Death button change the variable entry to manipulate how the death works
            if (isActive("Damaged")) character.Damaged = GetInput("Damaged");

            if (isActive("Speed1")) character.Speed1 = GetInput("Speed1");                //Walk
            if (isActive("Speed2")) character.Speed2 = GetInput("Speed2");                //Trot
            if (isActive("Speed3")) character.Speed3 = GetInput("Speed3");                //Run

            //Get the Death button change the variable entry to manipulate how the death works
        }

        /// <summary>
        /// Enable/Disable the Input
        /// </summary>
        public void EnableInput(string inputName, bool value)
        {
            foreach (InputRow item in inputs)
            {
                if (item.name.ToUpper() == inputName.ToUpper())
                {
                    item.active = value;
                    return;
                }
            }
        }

        /// <summary>
        /// Thit will set the correct Input, from the Unity Input Manager or Keyboard.. you can always modify this code
        /// </summary>
        protected bool GetInput(string name)
        {
            foreach (InputRow item in inputs)
            {
                if (item.name.ToUpper() == name.ToUpper() && item.active)
                {
                    return item.GetInput;
                }
            }
            return false;
        }

        /// <summary>
        /// Check if the input is active
        /// </summary>
        bool isActive(string name)
        {
            foreach (InputRow item in inputs)
            {
                if (item.name.ToUpper() == name.ToUpper()) return item.active;
            }
            return false;
        }
    }
}