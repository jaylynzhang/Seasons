using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrainTrigger : MonoBehaviour
{
    public GameObject UI;

    void OnTriggerEnter(Collider Obj)
    {
        if (Obj.tag == "Player")
        {
            UI.SetActive(true);
        }
    }
}
