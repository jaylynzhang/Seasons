using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatureLemonTree : MonoBehaviour
{
    public GameObject LemonOnPlayer;
    public GameObject Lemon;
    public MonoBehaviour Outline;

    // Start is called before the first frame update
    void Start()
    {
        LemonOnPlayer.SetActive(false);
        Lemon.SetActive(true);
        Outline.enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Outline.enabled = true;
            if (Input.GetKey(KeyCode.E))
            {
                Lemon.SetActive(false);
                LemonOnPlayer.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Outline.enabled = false;
    }
}
