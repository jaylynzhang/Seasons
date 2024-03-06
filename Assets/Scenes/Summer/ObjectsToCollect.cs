using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ObjectsToCollect : MonoBehaviour
{
    public static int objects = 0;
    public GameObject girl;
    public GameObject oldGirl;
    public GameObject oldTube;
    public GameObject rock;
    public GameObject oldRock;
    public GameObject umbrella;
    public GameObject oldUmbrella;
    public GameObject text;
    public GameObject end;

    // Use this for initialization
    void Awake()
    {
        objects++;
        rock.SetActive(false);
        girl.SetActive(false);
        umbrella.SetActive(false);
        end.SetActive(false);
        oldGirl.SetActive(true);
        oldTube.SetActive(true);
        oldRock.SetActive(true);
        oldUmbrella.SetActive(true);
        //text.SetActive(true);
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider plyr)
    {
        if (plyr.gameObject.tag == "Player")
        {
            objects--;
            gameObject.SetActive(false);
            if (gameObject.tag == "rock")
            {
                rock.SetActive(true);
            }
            if (gameObject.tag == "tube")
            {
                girl.SetActive(true);
                oldGirl.SetActive(false);
            }
            if (gameObject.tag == "umbrella")
            {
                umbrella.SetActive(true);
            }
            if (objects == 0)
            {
                text.SetActive(false);
                end.SetActive(true);
            }

        }
    }
}