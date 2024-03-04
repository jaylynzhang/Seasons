using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpHammer : MonoBehaviour
{
    public GameObject HammerOnPlayer;
    public GameObject PickUpText;

    // Start is called before the first frame update
    void Start()
    {
        HammerOnPlayer.SetActive(false);
        PickUpText.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            PickUpText.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                this.gameObject.SetActive(false);
                HammerOnPlayer.SetActive(true);
                PickUpText.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PickUpText.SetActive(false);
    }
}
