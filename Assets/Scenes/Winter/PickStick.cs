using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickStick : MonoBehaviour
{
    public GameObject StickOnPlayer;
    public GameObject PickUpText;

    // Start is called before the first frame update
    void Start()
    {
        StickOnPlayer.SetActive(false);
        PickUpText.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        print(other.gameObject.tag);
        if(other.gameObject.tag == "Player")
        {
            PickUpText.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                this.gameObject.SetActive(false);
                StickOnPlayer.SetActive(true);
                PickUpText.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PickUpText.SetActive(false);
    }
}
