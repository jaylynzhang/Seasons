using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillLemonJuice : MonoBehaviour
{
    public GameObject EmptyLemonJuice;
    public GameObject FilledLemonJuice;
    public GameObject LemonJuiceHint;
    public GameObject LemonOnHand;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<BoxCollider>().enabled = true;
        EmptyLemonJuice.SetActive(true);
        FilledLemonJuice.SetActive(false);
        LemonJuiceHint.SetActive(false);
        LemonOnHand.SetActive(false);
        print(this.enabled);
    }

    private void OnTriggerStay(Collider other)
    {
        print(other.tag);

        // if player approaches and lemon juice is not filled
        if (other.tag == "Player" && !FilledLemonJuice.activeSelf)
        {
            LemonJuiceHint.SetActive(true);
            // if has lemon on hand, fill it
            if (LemonOnHand.activeSelf && Input.GetKey(KeyCode.E))
            {
                this.gameObject.SetActive(false);
                EmptyLemonJuice.SetActive(false);
                LemonJuiceHint.SetActive(false);
                FilledLemonJuice.SetActive(true);
                LemonOnHand.SetActive(false);
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        LemonJuiceHint.SetActive(false);
    }
}
