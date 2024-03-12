using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickWood : MonoBehaviour
{
    public GameObject WoodOnPlayer;
    public GameObject PickUpText;
    // Start is called before the first frame update
    void Start()
    {
        WoodOnPlayer.SetActive(false);
        PickUpText.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PickUpText.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                this.gameObject.SetActive(false);
                WoodOnPlayer.SetActive(true);
                PickUpText.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PickUpText.SetActive(false);
    }

}