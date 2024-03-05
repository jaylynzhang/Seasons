using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWood : MonoBehaviour
{
    public GameObject SpecialTree;
    public GameObject WoodOn;
    public GameObject HitTreeText;
    public GameObject HammerOn;

    // Start is called before the first frame update
    void Start()
    {
        SpecialTree.SetActive(true);
        WoodOn.SetActive(false);
        HitTreeText.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && HammerOn.activeSelf)
        {
            HitTreeText.SetActive(true);
            if(Input.GetKey(KeyCode.Q))
            {
                this.gameObject.SetActive(true);
                WoodOn.SetActive(true);
                HitTreeText.SetActive(false);
                HammerOn.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        HitTreeText.SetActive(false);
    }
}
