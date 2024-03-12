using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public GameObject PaddleNearTree;
    public GameObject PaddleText;
    public GameObject PaddleOnPlayer;
    public GameObject mapOnPlayer;
    public MonoBehaviour Outline;


    // Start is called before the first frame update
    void Start()
    {
        PaddleNearTree.SetActive(true);
        PaddleOnPlayer.SetActive(false);
        PaddleText.SetActive(false);
        Outline.enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Outline.enabled = true;
            if (Input.GetKey(KeyCode.E))
            {
                if (!mapOnPlayer.activeSelf)
                {
                    PaddleText.SetActive(true);
                } else
                {
                    PaddleNearTree.SetActive(false);
                    PaddleOnPlayer.SetActive(true);

                }
                
            }

        }

    }

    private void OnTriggerExit(Collider other)
    {
        PaddleText.SetActive(false);
        Outline.enabled = false;
    }
}
