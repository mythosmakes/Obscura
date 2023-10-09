using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    private int shardsCollected = 0;

    public GameObject mirrorShard1;
    public GameObject mirrorShard2;
    public GameObject mirrorShard3;
    
    CharacterController characterController;
    private InputManager input;
    private PlayerInput playerInput;

    public float moveSpeed;
    private float targetRotation = 0.0f;
    private float verticalSpeed;
    private Vector3 characterVelocity;
    private float rotationVelocity;
    [Range(0.0f, 0.3f)]
    public float turningTime = 0.12f;

    private void Start()
    {
        characterController = GetComponent<CharacterController>(); // get character controller
        input = GetComponent<InputManager>();
        playerInput = GetComponent<PlayerInput>();
        
        mirrorShard1.SetActive(false);
        mirrorShard2.SetActive(false);
        mirrorShard3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Simple controls to get player moving, delete later for touch controls
        float targetSpeed = moveSpeed;
        if (input.move == Vector2.zero) targetSpeed = 0.0f;
        float currentSpeed = new Vector3(characterController.velocity.x, 0.0f, characterController.velocity.z).magnitude;
        float inputMagnitude = input.move.magnitude; //if using analog stick, scale with input. Else, magnitude is 1f

        Vector3 inputDirection = new Vector3(input.move.x, 0.0f, input.move.y).normalized;
        if (input.move != Vector2.zero)
        {
            targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + 45;
            float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref rotationVelocity, turningTime);
            transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
            Debug.Log("Move input!");
        }
        Vector3 targetDirection = Quaternion.Euler(0.0f, targetRotation, 0.0f) * Vector3.forward;
        characterVelocity = targetDirection.normalized * (targetSpeed * Time.deltaTime) + new Vector3(0.0f, verticalSpeed, 0.0f);
        characterController.Move(targetDirection.normalized * (targetSpeed * Time.deltaTime) + new Vector3(0.0f, verticalSpeed, 0.0f) * Time.deltaTime); //move player
    }

    public void UpdateShards()
    {
        shardsCollected++;
        switch (shardsCollected)
        {
            case 1:
                mirrorShard1.SetActive(true);
                mirrorShard2.SetActive(false);
                mirrorShard3.SetActive(false);
                break;
            case 2:
                mirrorShard1.SetActive(true);
                mirrorShard2.SetActive(true);
                mirrorShard3.SetActive(false);
                break;
            case 3:
                mirrorShard1.SetActive(true);
                mirrorShard2.SetActive(true);
                mirrorShard3.SetActive(true);
                break;
        }

    }
}
