using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.FilePathAttribute;

public class PlayerControl : MonoBehaviour
{
    public GameObject world;  // game world
    private Rigidbody rb; // player rigid body
    public float sensitivity = 9.8F;
    Vector2 movementVector;

    public GameObject cam; // main camera

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //Reset();
        cam.transform.SetPositionAndRotation(
                new Vector3(0, 50, 0), Quaternion.Euler(90, 0, 0));
    }

    void OnMove(InputValue movementValue)
    {
        movementVector = movementValue.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(
            Input.GetAxis("Vertical"), 0f, -Input.GetAxis("Horizontal"));
        if (rb.position.y <= -20)
        {
            Reset();
        }
    }

    public void Reset()
    {
        rb.transform.position = new Vector3(15f, 0.5f, -12f);
    }
}
