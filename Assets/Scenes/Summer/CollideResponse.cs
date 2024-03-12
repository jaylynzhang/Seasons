using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CollideResponse : MonoBehaviour
{
    public static int objects = 3;
    public GameObject oldObj; // the object user first sees when playing
    public GameObject newObj; // the new object that shows up (i.e. girl) after collision
    public GameObject correspodingObject;

    //public GameObject collideArea;

    //attch script
    // oldObj    collideArea   newObj
    // --------------------------------
    // tube       old girl     new girl
    // umbrella    area        new umbrella
    // rock        area        none


    // Use this for initialization
    void Awake()
    {
        oldObj.SetActive(true);
        if (newObj != null)
        {
            newObj.SetActive(false);
        }    
    }

  
    void OnTriggerEnter(Collider plyr)
    {
        //if (plyr.gameObject.tag == "Player")
        //{
        //    Transform temp = plyr.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform;
        //    if (temp.childCount > 0)
        //    {

        //        GameObject child = temp.GetChild(0).gameObject;
        //        if (gameObject.tag == "rockArea" && child.tag == "rock")
        //        {
        //            objects--;
        //            rock.SetActive(true);
        //        }
        //        if (gameObject.tag == "tubeArea" && child.tag == "tube")
        //        {
        //            objects--;
        //            girl.SetActive(true);
        //            oldGirl.SetActive(false);
        //        }
        //        if (gameObject.tag == "umbrellaArea" && child.tag == "umbrella")
        //        {
        //            objects--;
        //            umbrella.SetActive(true);
        //        }

        //    }
        //}


        //ObjectIwantToPickUp.transform.parent = null; // make the object no be a child of the hands
      
        if (gameObject.tag == "rockArea" && plyr.gameObject.tag == "rock")
        {
            objects--;
            plyr.gameObject.SetActive(false);
            newObj.SetActive(true);
            oldObj.transform.parent = null;
        }
        if (gameObject.tag == "tubeArea" && plyr.gameObject.tag == "tube")
        {
            objects--;
            oldObj.SetActive(false);
            gameObject.SetActive(false);
            newObj.SetActive(true);
            oldObj.transform.parent = null;
        }
        if (gameObject.tag == "umbrellaArea" && plyr.gameObject.tag == "umbrella")
        {
            objects--;
            plyr.gameObject.SetActive(false);
            newObj.SetActive(true);
            oldObj.transform.parent = null;
        }       
    }

    //void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Player"){
    //        isInBox = false;
    //    }
    //}
}