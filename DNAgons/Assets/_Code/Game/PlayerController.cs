using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour {

    public Transform model;

    public Transform playerHands;

    // Player Movement
    public float movementSpeed;
    public float rotationSpeed;
    float horizontal, vertical;

    // Input
    public VirtualJoystick joystick;

    // Animator
    Animator anim;

    void Start () { anim = GetComponent<Animator>(); }
	
	void Update ()
    {
        Vector3 _mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);

        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            RegisterClick(_mousePos);
        }

        Vector3 _touchPos = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 0f);

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            RegisterTouch(_touchPos);
        }
      
        // quick and dirty
        anim.SetBool("Carrying", playerHands.childCount > 0);
    }

    void FixedUpdate()
    {
        HandleInput();

        Move();
        Turn();
    }

    private void HandleInput()
    {
        if (joystick != null)
        {
            vertical = joystick.Vertical();
            horizontal = joystick.Horizontal();
        }
        else
        {
            vertical = Input.GetAxis("Vertical");
            horizontal = Input.GetAxis("Horizontal");
        }
    }

    void Move()
    {
        ConvertMoveInput();
        UpdatePlayerAnim();
    }

    private void ConvertMoveInput()
    {
        movementSpeed = vertical;
        rotationSpeed = horizontal;
    }

    private void UpdatePlayerAnim()
    {
        anim.SetFloat("Speed", Mathf.Abs(movementSpeed));
    }

    void Turn()
    {
        // Source: bunny83 < http://answers.unity3d.com/questions/1182693/ >
        Vector3 input = new Vector3(horizontal, 0, vertical);
        Vector3 dir = input.normalized;
        dir.x = Mathf.Round(dir.x);
        dir.z = Mathf.Round(dir.z);
        if (dir.sqrMagnitude > 0.1f)
            dir.Normalize();

        if (input != Vector3.zero)
        {
            model.rotation = Quaternion.Slerp(model.rotation,
                Quaternion.LookRotation(dir), Time.deltaTime * 5f);
        }
    }

    private void RegisterClick(Vector3 atMousePosition)
    {
        Vector3 _worldPos;

        Ray ray = Camera.main.ScreenPointToRay(atMousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100f))
        {
            _worldPos = hit.point;
        }
        else
        {
            _worldPos = Camera.main.ScreenToWorldPoint(atMousePosition);
            // **Note** This is where 'click to move' script would go.
        }

        // Is player Carrying an Item?
        if (playerHands.childCount > 0 && Inventory.Instance.CarryingItem)
        {
            _worldPos.y += .2f; // TODO: Add a true snap to ground script
            Inventory.Instance.PutDownItem(playerHands.GetChild(0).gameObject, _worldPos);
        }
    }

    void RegisterTouch(Vector3 atTouchPosition)
    {
        RegisterClick(atTouchPosition);
    }
}
