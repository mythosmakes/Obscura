using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] LayerMask clickableLayers;
    public int shardsCollected = 0;

    public GameObject mirrorShard1;
    public GameObject mirrorShard2;
    public GameObject mirrorShard3;

    public GameObject levelFailUI;
    
    CharacterController characterController;
    private InputManager input;
    private PlayerInput playerInput;
    private UnityEngine.AI.NavMeshAgent agent;

    public float defaultMoveSpeed;
    public float moveSpeed;
    private float verticalSpeed;
    private Vector3 characterVelocity;
    private float rotationVelocity;
    [Range(0.0f, 0.3f)]
    public float turningTime = 0.12f;

    public int corruption = 0;
    public Text corruptionText;

    private void Start()
    {
        characterController = GetComponent<CharacterController>(); // get character controller
        input = GetComponent<InputManager>();
        playerInput = GetComponent<PlayerInput>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        
        mirrorShard1.SetActive(false);
        mirrorShard2.SetActive(false);
        mirrorShard3.SetActive(false);

        defaultMoveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 inputDirection = new Vector3(input.move.x, 0.0f, input.move.y).normalized;
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            
            RaycastHit hit;
            if(Physics.Raycast(Camera.main.ScreenPointToRay(touch.position), out hit, 1000, clickableLayers))
            {
                agent.destination = hit.point;
            }
            /*targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + 45;
            float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref rotationVelocity, turningTime);
            transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);*/
        }
        if(input.click == true)
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000, clickableLayers))
            {
                agent.destination = hit.point;
            }
        }

        if(input.exit)
        {
            Application.Quit();
        }
    }

    public void UpdateShards(int shards)
    {
        shardsCollected += shards;
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

    public void CorruptionEffect()
    {
        corruption += 1;
        corruptionText.text = "Health: " + (3 - corruption);
        if(corruption >= 3)
        {
            levelFailUI.SetActive(true);
            Destroy(this);
        }
        Debug.Log("Corruption level: " + corruption);
    }

    public void SlowEffect()
    {
        moveSpeed /= 2;
    }

    public void ResetSpeed()
    {
        moveSpeed = defaultMoveSpeed;
    }
}
