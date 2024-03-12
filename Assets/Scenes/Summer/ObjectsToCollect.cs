using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ObjectsToCollect : MonoBehaviour
{
    public GameObject end;


    // Use this for initialization
    void Awake()
    {
        end.SetActive(false);
    }
    
    private void Update()
    {
        if (CollideResponse.objects == 0)
        {
            end.SetActive(true);
        }
    }


}