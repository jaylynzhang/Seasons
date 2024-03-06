using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrainTrigger : MonoBehaviour
{
    public GameObject UI;

    Collider collider;

    void Start()
    {
        //Fetch the GameObject's Collider (make sure they have a Collider component)
        collider = GetComponent<Collider>();
        //Here the GameObject's Collider is not a trigger
        collider.isTrigger = true;
       
    }


    void OnTriggerEnter(Collider Obj)
    {
        if (Obj.tag == "Player")
        {
            UI.SetActive(true);
        }
    }
}
