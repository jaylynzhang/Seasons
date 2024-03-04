using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpHammer : MonoBehaviour
{
    public GameObject HammerOnPlayer;

    // Start is called before the first frame update
    void Start()
    {
        HammerOnPlayer.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                this.gameObject.SetActive(false);
                HammerOnPlayer.SetActive(true);
            }
        }
    }
}
