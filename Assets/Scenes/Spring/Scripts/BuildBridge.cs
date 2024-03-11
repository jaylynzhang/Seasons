using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBridge : MonoBehaviour
{
    public GameObject BridgePartsOn;
    public GameObject BridgeOn;
    public GameObject BuildBridgeText;
    public GameObject HammerOn;
    public GameObject bridgeBorder;
    public MonoBehaviour Outline;
    private bool firstTime;
    

    // Start is called before the first frame update
    void Start()
    {
        BridgePartsOn.SetActive(true);
        BridgeOn.SetActive(false);
        BuildBridgeText.SetActive(false);
        bridgeBorder.SetActive(true);
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
                BuildBridgeText.SetActive(true);
            }
            if (HammerOn.activeSelf && Input.GetKey(KeyCode.E))
            {
                this.gameObject.SetActive(false);
                BridgeOn.SetActive(true);
                HammerOn.SetActive(false);
                bridgeBorder.SetActive(false);
                BuildBridgeText.SetActive(false);

            }

        }
        //if (other.tag == "Player" && HammerOn.activeSelf)
        //{
        //    BuildBridgeText.SetActive(true);

        //    if (Input.GetKey(KeyCode.E))
        //    {
        //        this.gameObject.SetActive(false);
        //        BridgeOn.SetActive(true);
        //        BuildBridgeText.SetActive(false);
        //        HammerOn.SetActive(false);
        //        bridgeBorder.SetActive(false);
        //    }
        //}
    
    }

    private void OnTriggerExit(Collider other)
    {
        BuildBridgeText.SetActive(false);
        firstTime = false;
        Outline.enabled = false;
    }
}
