using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingText : MonoBehaviour
{
    public GameObject text;
    void Awake()
    {
        text.SetActive(false);
    }

    void OnTriggerEnter(Collider Obj)
    {
        if (Obj.tag == "Player")
        {
            text.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        text.SetActive(false);
    }
}
