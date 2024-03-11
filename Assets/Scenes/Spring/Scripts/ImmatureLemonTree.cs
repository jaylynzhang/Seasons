using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmatureLemonTree : MonoBehaviour
{
    public GameObject ImmatureLemonTreeOn;
    public GameObject MatureLemonTreeOn;
    public GameObject LemonTreeHint;
    public GameObject WateringCanOn;
    public MonoBehaviour Outline;
    private bool firstTime;


    // Start is called before the first frame update
    void Start()
    {
        ImmatureLemonTreeOn.SetActive(true);
        MatureLemonTreeOn.SetActive(false);
        LemonTreeHint.SetActive(false);
        Outline.enabled = false;
        firstTime = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Outline.enabled = true;
            if (firstTime)
            {
                LemonTreeHint.SetActive(true);
            }
            if (WateringCanOn.activeSelf && Input.GetKey(KeyCode.E))
            {
                this.gameObject.SetActive(false);
                MatureLemonTreeOn.SetActive(true);
                WateringCanOn.SetActive(false);
                LemonTreeHint.SetActive(false);

            }

        }

    }

    private void OnTriggerExit(Collider other)
    {
        LemonTreeHint.SetActive(false);
        firstTime = false;
        Outline.enabled = false;
    }
}
