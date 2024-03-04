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

    // Start is called before the first frame update
    void Start()
    {
        BridgePartsOn.SetActive(true);
        BridgeOn.SetActive(false);
        BuildBridgeText.SetActive(false);
        bridgeBorder.SetActive(true);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && HammerOn.activeSelf)
        {
            BuildBridgeText.SetActive(true);

            if (Input.GetKey(KeyCode.D))
            {
                this.gameObject.SetActive(false);
                BridgeOn.SetActive(true);
                BuildBridgeText.SetActive(false);
                HammerOn.SetActive(false);
                bridgeBorder.SetActive(false);
            }
        }
    
    }

    private void OnTriggerExit(Collider other)
    {
        BuildBridgeText.SetActive(false);
    }
}
