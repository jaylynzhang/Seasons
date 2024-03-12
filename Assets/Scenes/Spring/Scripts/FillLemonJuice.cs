using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillLemonJuice : MonoBehaviour
{
    public GameObject EmptyLemonJuice;
    public GameObject FilledLemonJuice;
    public GameObject LemonJuiceHint;
    public GameObject LemonOnHand;
    public GameObject MapHint;
    public GameObject map;
    public MonoBehaviour Outline;
    private bool firstTime;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<BoxCollider>().enabled = true;
        EmptyLemonJuice.SetActive(true);
        FilledLemonJuice.SetActive(false);
        LemonJuiceHint.SetActive(false);
        LemonOnHand.SetActive(false);
        Outline.enabled = false;
        map.SetActive(false);
        MapHint.SetActive(false);
        firstTime = true;
    }

    private void OnTriggerStay(Collider other)
    {

        // if player approaches and lemon juice is not filled
        if (other.tag == "Player" && !FilledLemonJuice.activeSelf)
        {
            
            Outline.enabled = true;
            if (firstTime)
            {
                LemonJuiceHint.SetActive(true);
            }
            // if has lemon on hand, fill it
            if (LemonOnHand.activeSelf && Input.GetKey(KeyCode.E))
            {
                this.gameObject.SetActive(false);
                EmptyLemonJuice.SetActive(false);
                LemonJuiceHint.SetActive(false);
                FilledLemonJuice.SetActive(true);
                LemonOnHand.SetActive(false);
                MapHint.SetActive(true);
                wait(3);
                map.SetActive(true);
            }

        }
    }

    IEnumerator wait(int time)
    {
        yield return new WaitForSeconds(time); // Wait for 3 seconds
    }

    private void OnTriggerExit(Collider other)
    {
        LemonJuiceHint.SetActive(false);
        Outline.enabled = false;
        firstTime = false;
    }
}
