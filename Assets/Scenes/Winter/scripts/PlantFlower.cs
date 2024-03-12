using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantFlower : MonoBehaviour
{
    public GameObject FlowerOnHand;
    public GameObject Flowers;
    public GameObject PlantText;
    public GameObject EndText;


    // Start is called before the first frame update
    void Start()
    {
        Flowers.SetActive(false);
        PlantText.SetActive(false);
        EndText.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && FlowerOnHand.activeSelf)
        {
            PlantText.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                Flowers.SetActive(true);
                PlantText.SetActive(false);
                FlowerOnHand.SetActive(false);
                EndText.SetActive(true);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        PlantText.SetActive(false);
    }
}
