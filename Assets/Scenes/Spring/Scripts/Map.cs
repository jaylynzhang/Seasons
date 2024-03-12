using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject MapObject;
    public GameObject MapOnPlayer;
    public GameObject MapHint;
    public GameObject AdventureText;
    public MonoBehaviour Outline;


    // Start is called before the first frame update
    void Start()
    {
        MapOnPlayer.SetActive(false);
        Outline.enabled = false;
        AdventureText.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Outline.enabled = true;
            if (Input.GetKey(KeyCode.E))
            {
                MapObject.SetActive(false);
                MapOnPlayer.SetActive(true);
                MapHint.SetActive(false);
                AdventureText.SetActive(true);
            }

        }

    }

    private void OnTriggerExit(Collider other)
    {
        Outline.enabled = false;
    }
}
