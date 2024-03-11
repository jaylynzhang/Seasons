using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWateringCan : MonoBehaviour
{
    public GameObject WateringCanOnPlayer;
    public MonoBehaviour Outline;

    // Start is called before the first frame update
    void Start()
    {
        WateringCanOnPlayer.SetActive(false);
        Outline.enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Outline.enabled = true;
            if (Input.GetKey(KeyCode.E))
            {
                this.gameObject.SetActive(false);
                WateringCanOnPlayer.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Outline.enabled = false;
    }
}
