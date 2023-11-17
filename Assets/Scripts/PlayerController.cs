using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
//using UnityEngine.WSA;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject groundCast;
    [SerializeField] LayerMask clickableLayers;
    private Tile currentTile;
    [SerializeField] private float movementSpeed;
    public int shardsCollected = 0;
    private SaveManager saveManager;

    private Animator anim;
    [SerializeField] SkinnedMeshRenderer meshRenderer;

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

    public int corruption = 0;
    public Text corruptionText;

    public AudioSource soundEffects;
    public AudioClip footsteps;
    public bool isWalking;

    private void Start()
    {
        characterController = GetComponent<CharacterController>(); // get character controller
        anim = GetComponentInChildren<Animator>();
        input = GetComponent<InputManager>();
        playerInput = GetComponent<PlayerInput>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        saveManager = SaveManager.Instance;
        Time.timeScale = 1;
        
        mirrorShard1.SetActive(false);
        mirrorShard2.SetActive(false);
        mirrorShard3.SetActive(false);

        defaultMoveSpeed = moveSpeed;

        soundEffects.clip = footsteps;
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
                //Check which gamemode player is in so correct behavior is displayed
                if(saveManager.isPlayingTileRotation == true && clickTarget.collider.gameObject.TryGetComponent<TileRotator>(out TileRotator tileRotator))
                {
                    Debug.Log("Hit tile rotator");
                    tileRotator.Activate();
                }
                else if (saveManager.isPlayingTileRotation == false)
                {
                    agent.destination = clickTarget.point;
                }
                

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
                //Check which gamemode player is in so correct behavior is displayed
                if (saveManager.isPlayingTileRotation == true && clickTarget.collider.gameObject.TryGetComponent<TileRotator>(out TileRotator tileRotator))
                {
                    Debug.Log("Hit tile rotator");
                    tileRotator.Activate();
                }
                else if (saveManager.isPlayingTileRotation == false)
                {
                    agent.destination = clickTarget.point;
                }
            }
        }

        if (agent.remainingDistance > 0)
        {
            anim.SetBool("Walk", true);
            isWalking = true;
        }
        else
        {
            anim.SetBool("Walk", false);
            isWalking = false;
        }

        if(isWalking == true)
        {
            soundEffects.Play();
        }
        else
        {
            soundEffects.Stop();
        }



        //Debug.Log(agent.remainingDistance);

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
        float increment = corruption * -0.49f;
        corruptionText.text = "Health: " + (3 - corruption);
        if(corruption >= 3)
        {
            anim.SetBool("Walk", false);
            isWalking = false;
            levelFailUI.SetActive(true);
            Destroy(this);
        }
        Material[] materials = meshRenderer.materials;
        materials[1].SetFloat("_Timer", increment);

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

    public void Move()
    {
        if(saveManager.isPlayingTileRotation == true)
        {

        }
    }
}
