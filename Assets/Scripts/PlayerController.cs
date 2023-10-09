using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    public int ShardsCollected { get; private set; }

    public GameObject mirrorShard1;
    public GameObject mirrorShard2;
    public GameObject mirrorShard3;


    private void Start()
    {
        mirrorShard1.SetActive(false);
        mirrorShard2.SetActive(false);
        mirrorShard3.SetActive(false);

        ShardsCollected = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Simple controls to get player moving, delete later for touch controls
        var inputX = Input.GetAxis("Horizontal");
        var inputY = Input.GetAxis("Vertical");
        Vector3 moveVector = new Vector3(-inputY, 0, inputX) * movementSpeed * Time.deltaTime;

        transform.Translate(moveVector);

        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Pickups");
        }
    }

    public void UpdateShards(int amount)
    {
        ShardsCollected += amount;
        switch (ShardsCollected)
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
            default:
                mirrorShard1.SetActive(false);
                mirrorShard2.SetActive(false);
                mirrorShard3.SetActive(false);
                break;
        }

    }
}
