using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmatureLemonTree : MonoBehaviour
{
    public GameObject ImmatureLemonTreeOn;
    public GameObject MatureLemonTreeOn;
    public GameObject LemonTreeHint;
    public GameObject WateringCanOn;
    public GameObject Lemon;
    private bool firstTime;


    // Start is called before the first frame update
    void Start()
    {
        ImmatureLemonTreeOn.SetActive(true);
        MatureLemonTreeOn.SetActive(false);
        Lemon.SetActive(false);
        LemonTreeHint.SetActive(false);
        firstTime = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (firstTime)
            {
                LemonTreeHint.SetActive(true);
            }
            if (WateringCanOn.activeSelf && Input.GetKey(KeyCode.E))
            {
                this.gameObject.SetActive(false);
                MatureLemonTreeOn.SetActive(true);
                Lemon.SetActive(true);
                WateringCanOn.SetActive(false);
                LemonTreeHint.SetActive(false);

                wait(3);

            }

        }

    }



    private void OnTriggerExit(Collider other)
    {
        LemonTreeHint.SetActive(false);
        firstTime = false;
    }

    IEnumerator wait(int time)
    {
        yield return new WaitForSeconds(3); // Wait for 3 seconds
    }
}
