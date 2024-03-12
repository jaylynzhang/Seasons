using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFlower : MonoBehaviour
{
    public GameObject FlowerOnHand;
    public GameObject SecTask;
    public GameObject Intro;
    public GameObject TalkNPC;


    void Start()
    {
        FlowerOnHand.SetActive(false);
        SecTask.SetActive(false);
        Intro.SetActive(true);
        TalkNPC.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            TalkNPC.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // TalkNPC.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                TalkNPC.SetActive(false);
                Intro.SetActive(false);
                FlowerOnHand.SetActive(true);
                SecTask.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        TalkNPC.SetActive(false);
    }
}
