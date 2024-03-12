using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    //public GameObject myHands; //reference to your hands/the position where you want your object to go
    bool canpickup; //a bool to see if you can or cant pick up the item
    GameObject ObjectIwantToPickUp; // the gameobject onwhich you collided with
    public GameObject Container;
    public GameObject text;
    public GameObject hint;


    void Start()
    {
        canpickup = false;   
        text.SetActive(false);
        hint.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (canpickup == true) // if you enter thecollider of the objecct
        {
            if (Input.GetKeyDown("e"))  // can be e or any key
            {
                hint.SetActive(false);
                if (Container.transform.childCount > 0)
                {
                    // we have children!
                    text.SetActive(true);
                }
                else
                {
                    //Debug.Log("E key was pressed.");
                    //ObjectIwantToPickUp.GetComponent<Rigidbody>().isKinematic = true;   //makes the rigidbody not be acted upon by forces

                    ObjectIwantToPickUp.transform.SetParent(Container.transform); //makes the object become a child of the parent so that it moves with the hands
                    ObjectIwantToPickUp.transform.localPosition = Vector3.zero;
                    ObjectIwantToPickUp.transform.localRotation = Quaternion.Euler(Vector3.zero);
                    ObjectIwantToPickUp.transform.localScale = Vector3.one;
                }
            }
        }
        
    }
    private void OnTriggerEnter(Collider other) // to see when the player enters the collider
    {
        //Debug.Log("trigger detected");
        //Debug.Log("tag:" + other.gameObject.tag);
        
        if (other.gameObject.tag == "Player") //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            Debug.Log("set can pick up");
            hint.SetActive(true);
            canpickup = true;  //set the pick up bool to true
            ObjectIwantToPickUp = gameObject; //set the gameobject you collided with to one you can reference
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("set cannot be pick up");
        canpickup = false; //when you leave the collider set the canpickup bool to false
        text.SetActive(false);
        hint.SetActive(false);
    }
}
