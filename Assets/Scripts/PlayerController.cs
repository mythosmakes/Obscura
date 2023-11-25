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
    [SerializeField] bool isPlayingTileRotation;
    [SerializeField] List<Collider> clickRotationColliders;
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
    public bool stopped;
    
    public GameObject destination1;
    public GameObject destination2;
    public GameObject destination3;
    public GameObject destination4;
    public GameObject destination5;
    public GameObject destination6;
    public GameObject destination7;
    public GameObject destination8;
    public GameObject destination9;
    public GameObject destination10;
    public GameObject destination11;
    public GameObject destination12;
    public GameObject destination13;
    public GameObject destination14;
    public GameObject destination15;
    public GameObject destination16;
    public GameObject destination17;
    public GameObject destination18;
    public GameObject destination19;
    public GameObject destination20;
    public GameObject destination21;
    public GameObject destination22;
    public GameObject destination23;
    public GameObject destination24;
    public GameObject destination25;
    public GameObject destination26;
    public GameObject destination27;
    public GameObject destination28;
    public GameObject destination29;
    public GameObject destination30;
    public GameObject destination31;
    public GameObject destination32;
    public GameObject destination33;
    public GameObject destination34;
    public GameObject destination35;
    public GameObject destination36;

    public bool setMovementLevel;

    private void Start()
    {

        characterController = GetComponent<CharacterController>(); // get character controller
        anim = GetComponentInChildren<Animator>();
        input = GetComponent<InputManager>();
        playerInput = GetComponent<PlayerInput>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        saveManager = SaveManager.Instance;
        Time.timeScale = 1;

        if (isPlayingTileRotation == true) 
        {
            saveManager.SetGamemode(1);
        }
        else
        {
            saveManager.SetGamemode(0);
        }

        mirrorShard1.SetActive(false);
        mirrorShard2.SetActive(false);
        mirrorShard3.SetActive(false);

        defaultMoveSpeed = moveSpeed;

        soundEffects.clip = footsteps;
    }

    // Update is called once per frame
    void Update()
    {
        if(!agent.hasPath)
        {
            stopped = true;
        }
        else
        {
            stopped = false;
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            RaycastHit clickTarget;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(touch.position), out clickTarget, 1000, clickableLayers))
            {
                //Check which gamemode player is in so correct behavior is displayed
                if(saveManager.isPlayingTileRotation == true && clickTarget.collider.gameObject.TryGetComponent<TileRotator>(out TileRotator tileRotator))
                {
                    //Debug.Log("Hit tile rotator");
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
                    //Debug.Log("Hit tile rotator");
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
            //Debug.Log("Raycast");
            if (hit.collider.gameObject.TryGetComponent<Tile>(out Tile tile))
            {
                //Debug.Log("Hit tile");
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
        //corruptionText.text = "Health: " + (3 - corruption);
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

    private void HideRotationColliders()
    {
        foreach(Collider collider in clickRotationColliders)
        {
            collider.enabled = false;
        }
    }

    public void Move1()
    {
        HideRotationColliders();
        StartCoroutine(Move1A());
    }
    IEnumerator Move1A()
    {
        stopped = false;
        agent.destination = destination1.transform.position;
        yield return new WaitUntil(() => stopped == true);
        StartCoroutine(Move1B());
    }
    IEnumerator Move1B()
    {
        stopped = false;
        agent.destination = destination2.transform.position;
        yield return new WaitUntil(() => stopped == true);
        StartCoroutine(Move1C());
    }
    IEnumerator Move1C()
    {
        stopped = false;
        yield return new WaitUntil(() => stopped == true);
        agent.destination = destination3.transform.position;
        StartCoroutine(Move1D());
    }
    IEnumerator Move1D()
    {
        stopped = false;
        yield return new WaitUntil(() => stopped == true);
        agent.destination = destination4.transform.position;
        StartCoroutine(Move1E());
    }
    IEnumerator Move1E()
    {
        stopped = false;
        yield return new WaitUntil(() => stopped == true);
        agent.destination = destination5.transform.position;
        StartCoroutine(Move1F());
    }
    IEnumerator Move1F()
    {
        stopped = false;
        yield return new WaitUntil(() => stopped == true);
        agent.destination = destination6.transform.position;
        StartCoroutine(Move1G());
    }
    IEnumerator Move1G()
    {
        stopped = false;
        yield return new WaitUntil(() => stopped == true);
        agent.destination = destination7.transform.position;
        StartCoroutine(Move1H());
    }

    IEnumerator Move1H()
    {
        stopped = false;
        yield return new WaitUntil(() => stopped == true);
        agent.destination = destination8.transform.position;
        StartCoroutine(Move1I());
    }

    IEnumerator Move1I()
    {
        stopped = false;
        yield return new WaitUntil(() => stopped == true);
        agent.destination = destination9.transform.position;
    }


    public void Move2()
    {
        HideRotationColliders();
        StartCoroutine(Move2A());
    }
    IEnumerator Move2A()
    {
        stopped = false;
        agent.destination = destination1.transform.position;
        yield return new WaitUntil(() => stopped == true);
        StartCoroutine(Move2B());
    }
    IEnumerator Move2B()
    {
        stopped = false;
        agent.destination = destination2.transform.position;
        yield return new WaitUntil(() => stopped == true);
        StartCoroutine(Move2C());
    }
    IEnumerator Move2C()
    {
        stopped = false;
        agent.destination = destination3.transform.position;
        yield return new WaitUntil(() => stopped == true);
        StartCoroutine(Move2D());
    }
    IEnumerator Move2D()
    {
        stopped = false;
        agent.destination = destination4.transform.position;
        yield return new WaitUntil(() => stopped == true);
        StartCoroutine(Move2E());
    }
    IEnumerator Move2E()
    {
        stopped = false;
        agent.destination = destination5.transform.position;
        yield return new WaitUntil(() => stopped == true);
        StartCoroutine(Move2F());
    }
    IEnumerator Move2F()
    {
        stopped = false;
        agent.destination = destination6.transform.position;
        yield return new WaitUntil(() => stopped == true);
        StartCoroutine(Move2G());
    }
    IEnumerator Move2G()
    {
        stopped = false;
        agent.destination = destination7.transform.position;
        yield return new WaitUntil(() => stopped == true);
        StartCoroutine(Move2H());
    }
    IEnumerator Move2H()
    {
        stopped = false;
        agent.destination = destination8.transform.position;
        yield return new WaitUntil(() => stopped == true);
        StartCoroutine(Move2I());
    }
    IEnumerator Move2I()
    {
        stopped = false;
        agent.destination = destination9.transform.position;
        yield return new WaitUntil(() => stopped == true);
        StartCoroutine(Move2J());
    }
    IEnumerator Move2J()
    {
        stopped = false;
        agent.destination = destination10.transform.position;
        yield return new WaitUntil(() => stopped == true);
        StartCoroutine(Move2K());
    }
    IEnumerator Move2K()
    {
        stopped = false;
        agent.destination = destination11.transform.position;
        yield return new WaitUntil(() => stopped == true);
        StartCoroutine(Move2L());
    }
    IEnumerator Move2L()
    {
        stopped = false;
        agent.destination = destination12.transform.position;
        yield return new WaitUntil(() => stopped == true);
        StartCoroutine(Move2M());
    }
    IEnumerator Move2M()
    {
        stopped = false;
        agent.destination = destination13.transform.position;
        yield return new WaitUntil(() => stopped == true);
        StartCoroutine(Move2N());
    }
    IEnumerator Move2N()
    {
        stopped = false;
        agent.destination = destination14.transform.position;
        yield return new WaitUntil(() => stopped == true);
        StartCoroutine(Move2O());
    }
    IEnumerator Move2O()
    {
        stopped = false;
        agent.destination = destination15.transform.position;
        yield return new WaitUntil(() => stopped == true);
        StartCoroutine(Move2P());
    }
    IEnumerator Move2P()
    {
        stopped = false;
        agent.destination = destination16.transform.position;
        yield return new WaitUntil(() => stopped == true);
        StartCoroutine(Move2Q());
    }
    IEnumerator Move2Q()
    {
        stopped = false;
        agent.destination = destination17.transform.position;
        yield return new WaitUntil(() => stopped == true);
        StartCoroutine(Move2R());
    }
    IEnumerator Move2R()
    {
        stopped = false;
        agent.destination = destination18.transform.position;
        yield return new WaitUntil(() => stopped == true);
        StartCoroutine(Move2S());
    }
    IEnumerator Move2S()
    {
        stopped = false;
        agent.destination = destination19.transform.position;
        yield return new WaitUntil(() => stopped == true);
        StartCoroutine(Move2T());
    }
    IEnumerator Move2T()
    {
        stopped = false;
        agent.destination = destination20.transform.position;
        yield return new WaitUntil(() => stopped == true);
        StartCoroutine(Move2U());
    }
    IEnumerator Move2U()
    {
        stopped = false;
        agent.destination = destination21.transform.position;
        yield return new WaitUntil(() => stopped == true);
        StartCoroutine(Move2V());
    }
    IEnumerator Move2V()
    {
        stopped = false;
        agent.destination = destination22.transform.position;
        yield return new WaitUntil(() => stopped == true);
        StartCoroutine(Move2W());
    }
    IEnumerator Move2W()
    {
        stopped = false;
        agent.destination = destination23.transform.position;
        yield return new WaitUntil(() => stopped == true);
        StartCoroutine(Move2X());
    }
    IEnumerator Move2X()
    {
        stopped = false;
        agent.destination = destination24.transform.position;
        yield return new WaitUntil(() => stopped == true);
        StartCoroutine(Move2Y());
    }
    IEnumerator Move2Y()
    {
        stopped = false;
        agent.destination = destination25.transform.position;
        yield return new WaitUntil(() => stopped == true);
        StartCoroutine(Move2Z());
    }
    IEnumerator Move2Z()
    {
        stopped = false;
        agent.destination = destination26.transform.position;
        yield return new WaitUntil(() => stopped == true);
        StartCoroutine(Move2AA());
    }
    IEnumerator Move2AA()
    {
        stopped = false;
        agent.destination = destination27.transform.position;
        yield return new WaitUntil(() => stopped == true);
        StartCoroutine(Move2AB());
    }
    IEnumerator Move2AB()
    {
        stopped = false;
        agent.destination = destination28.transform.position;
        yield return new WaitUntil(() => stopped == true);
        StartCoroutine(Move2AC());
    }
    IEnumerator Move2AC()
    {
        stopped = false;
        agent.destination = destination29.transform.position;
        yield return new WaitUntil(() => stopped == true);
        StartCoroutine(Move2AD());
    }
    IEnumerator Move2AD()
    {
        stopped = false;
        agent.destination = destination30.transform.position;
        yield return new WaitUntil(() => stopped == true);
        StartCoroutine(Move2AE());
    }
    IEnumerator Move2AE()
    {
        stopped = false;
        agent.destination = destination31.transform.position;
        yield return new WaitUntil(() => stopped == true);
        StartCoroutine(Move2AF());
    }
    IEnumerator Move2AF()
    {
        stopped = false;
        agent.destination = destination32.transform.position;
        yield return new WaitUntil(() => stopped == true);
        StartCoroutine(Move2AG());
    }
    IEnumerator Move2AG()
    {
        stopped = false;
        agent.destination = destination33.transform.position;
        yield return new WaitUntil(() => stopped == true);
        StartCoroutine(Move2AH());
    }
    IEnumerator Move2AH()
    {
        stopped = false;
        agent.destination = destination34.transform.position;
        yield return new WaitUntil(() => stopped == true);
        StartCoroutine(Move2AI());
    }
    IEnumerator Move2AI()
    {
        stopped = false;
        agent.destination = destination35.transform.position;
        yield return new WaitUntil(() => stopped == true);
        StartCoroutine(Move2AJ());
    }

    IEnumerator Move2AJ()
    {
        stopped = false;
        agent.destination = destination36.transform.position;
        yield return new WaitUntil(() => stopped == true);
    }
}
