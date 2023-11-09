using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
//using UnityEngine.WSA;

public class TestPlayerController : MonoBehaviour
{
    [SerializeField] private GameObject groundCast;
    [SerializeField] LayerMask clickableLayers;
    private Tile currentTile;
    [SerializeField] private float fallSpeed;
    [SerializeField] private float movementSpeed;
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
    private float targetRotation = 0.0f;
    private float verticalSpeed;
    private Vector3 characterVelocity;
    private float rotationVelocity;
    [Range(0.0f, 0.3f)]
    public float turningTime = 0.12f;

    private Animator animator;

    public int corruption = 0;
    public Text corruptionText;

    private void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>(); // get character controller
        input = GetComponent<InputManager>();
        playerInput = GetComponent<PlayerInput>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        Time.timeScale = 1;
        
        mirrorShard1.SetActive(false);
        mirrorShard2.SetActive(false);
        mirrorShard3.SetActive(false);

        defaultMoveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            RaycastHit clickTarget;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(touch.position), out clickTarget, 1000, clickableLayers))
            {
                agent.destination = clickTarget.point;
                animator.SetBool("walk", true);
            }
            /*targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + 45;
            float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref rotationVelocity, turningTime);
            transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);*/
        }
        if (input.click == true)
        {
            RaycastHit clickTarget;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out clickTarget, 1000, clickableLayers))
            {
                agent.destination = clickTarget.point;
            }
        }


        if (input.exit)
        {
            Application.Quit();
        }

        Vector3 targetDirection = Quaternion.Euler(0.0f, targetRotation, 0.0f) * Vector3.forward;
    }

    private void FixedUpdate()
    {
        // Raycast for tile activation without collision
        RaycastHit hit;
        if (Physics.Raycast(groundCast.transform.position, Vector3.down, out hit, 5.0f))
        {
            if (hit.collider.gameObject.TryGetComponent<Tile>(out Tile tile))
            {
                if (tile != currentTile && currentTile != null)
                {
                    currentTile.Deactivate();
                }
                currentTile = tile;
                tile.Activate(this);
            }
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

    public void Slow(float divisor)
    {
        moveSpeed /= divisor;
    }

    public void ResetSpeed()
    {
        moveSpeed = defaultMoveSpeed;
    }
}
