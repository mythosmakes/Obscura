using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public void Close()
    {
        gameObject.SetActive(true);
    }

    public void Open()
    {
        gameObject.SetActive(false);
    }
}
