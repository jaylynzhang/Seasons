using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ObjectsToCollect : MonoBehaviour
{
    //public GameObject end;
    public GameOver gameOver;
    [SerializeField] private GameObject player;

    // Use this for initialization
    //void Awake()
    //{
    //    end.SetActive(false);
    //}

    private void Update()
    {
        if (CollideResponse.objects == 0)
        {
            player.GetComponent<FirstPersonController>().enabled = false;
            gameOver.Setup();
        }
    }


}