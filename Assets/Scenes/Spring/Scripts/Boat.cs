using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    public GameObject BoatHint;
    public GameObject PaddleOnPlayer;
    public GameObject mapOnPlayer;
    public GameObject EndingText;
    public MonoBehaviour Outline;

    private bool firstTime;


    // Start is called before the first frame update
    void Start()
    {
        BoatHint.SetActive(false);
        Outline.enabled = false;
        firstTime = true;
        PaddleOnPlayer.SetActive(false);
        mapOnPlayer.SetActive(false);
        EndingText.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Outline.enabled = true;
            if (firstTime)
            {
                BoatHint.SetActive(true);
                
            }
            if (PaddleOnPlayer.activeSelf && Input.GetKey(KeyCode.E))
            {
                if (BoatHint.activeSelf)
                {
                    StartCoroutine(wait(4.1f));
                } else
                {
                    BoatHint.SetActive(false);
                    PaddleOnPlayer.SetActive(false);
                    mapOnPlayer.SetActive(false);
                    EndingText.SetActive(true);
                    firstTime = false;
                }
                
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        BoatHint.SetActive(false);
        firstTime = false;
        Outline.enabled = false;
    }

    IEnumerator wait(float time)
    {
        yield return new WaitForSeconds(time);
        BoatHint.SetActive(false);
        PaddleOnPlayer.SetActive(false);
        mapOnPlayer.SetActive(false);
        EndingText.SetActive(true);
        firstTime = false;

    }
}
