using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BoatPlayerController : MonoBehaviour
{
    [SerializeField, Range(0f, 18f)]
    private float Acceleration = 10f;

    [SerializeField, Range(0f, 30f)]
    private float MaxSpeed = 12f;

    [SerializeField]
    private float PlayerRotationSpeed = 0.15f;

    // some private-ish variables
    private Rigidbody Rigidbody;
    private Vector3 Velocity, DesiredVelocity;
    private Transform CameraTransform;

    // non-dependency private variables
    private PlayerInputActions PlayerInput;
    private bool Aiming = false;

    private void Awake()
    {
        PlayerInput = new PlayerInputActions();
        PlayerInput.GameBoat.Enable();
        Rigidbody = GetComponent<Rigidbody>();

        CameraTransform = Camera.main.transform;
    }

    private void Start()
    {
        PlayerInput.GameBoat.Aim.started += Aim_started;
        PlayerInput.GameBoat.Aim.canceled += Aim_canceled;

        // hide the mouse and stuffs tho
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnDestroy()
    {
        PlayerInput.GameBoat.Aim.started -= Aim_started;
        PlayerInput.GameBoat.Aim.started -= Aim_canceled;
    }

    private void Aim_started(InputAction.CallbackContext obj)
    {
        Aiming = true;
    }

    private void Aim_canceled(InputAction.CallbackContext obj)
    {
        Aiming = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movementDirection = GetMovementInput();

        var desiredVelocity = this.transform.forward * movementDirection.y;

        //var desiredVelocity = new Vector3(movementDirection.x, 0f, movementDirection.y);
        //desiredVelocity = desiredVelocity.x * CameraTransform.right.normalized + desiredVelocity.z * CameraTransform.forward.normalized;
        //desiredVelocity.y = 0;

        DesiredVelocity = desiredVelocity * MaxSpeed;

        Debug.DrawLine(transform.position, transform.position + desiredVelocity.normalized * 1, Color.red);

        if (Aiming)
        {
            gameObject.transform.eulerAngles = new Vector3(
                gameObject.transform.eulerAngles.x,
                Camera.main.transform.eulerAngles.y,
                gameObject.transform.eulerAngles.z
            );
        }
        else if (movementDirection.magnitude > 0.0f)
        {
            //gameObject.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(desiredVelocity), Time.deltaTime * PlayerRotationSpeed);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredVelocity.normalized), PlayerRotationSpeed);
        }
    }

    private void FixedUpdate()
    {
        if (DesiredVelocity.magnitude == 0.0f) return;
        // get the velocity
        Velocity = Rigidbody.velocity;

        // calculate some acceleration
        float speedChange = Acceleration * Time.deltaTime;

        // set velocity
        Velocity.x = Mathf.MoveTowards(Velocity.x, DesiredVelocity.x, speedChange);
        Velocity.z = Mathf.MoveTowards(Velocity.z, DesiredVelocity.z, speedChange);

        // set the velocity after nerdy calculations
        Rigidbody.velocity = Velocity;
    }

    private Vector2 GetMovementInput()
    {
        Vector2 movementDirection = PlayerInput.GameBoat.Move.ReadValue<Vector2>();

        return movementDirection;
    }
}
