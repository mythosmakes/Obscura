using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileRotator : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    private int rotationIncrement = 90;
    private int rotationThreshold = 0;
    bool activated = false;
    bool canActivate = true;
    float t;

    private void Start()
    {
        SaveManager.Instance.SetGamemode(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Activate();
        }

        if (activated == true)
        {
            t += rotationSpeed * Time.deltaTime;
            transform.localEulerAngles = new Vector3(0, 0, Mathf.Lerp(transform.localEulerAngles.z, rotationThreshold, t));

        }

        if (t >= 1 && activated == true)
        {
            Debug.Log("activated = false");
            activated = false;
            canActivate = true;
        }
    }
    public void Activate()
    {
        if(canActivate == true)
        {
            canActivate = false;
            rotationThreshold += rotationIncrement;
            if (rotationThreshold > 360)
            {
                rotationThreshold = rotationIncrement;
            }
            t = 0;
            activated = true;
        }
        
    }
}

