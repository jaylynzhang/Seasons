using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropWood : MonoBehaviour
{
    public GameObject HittedWood;
    public GameObject WoodOn;
    public GameObject WoodOnHand;
    public GameObject DropText;
    public GameObject NpcOn;


    // Start is called before the first frame update
    void Start()
    {
        HittedWood.SetActive(true);
        WoodOn.SetActive(false);
        DropText.SetActive(false);
        NpcOn.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
       if(other.tag == "Player" && WoodOnHand.activeSelf)
        {
            DropText.SetActive(true);
            if(Input.GetKey(KeyCode.E))
            {
                this.gameObject.SetActive(true);
                WoodOn.SetActive(true);
                DropText.SetActive(false);
                WoodOnHand.SetActive(false);
                NpcOn.SetActive(true);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        DropText.SetActive(false);
    }
}
