using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteractable : MonoBehaviour, IInteractable
{
    private Rigidbody objectRigidbody;
    [SerializeField] private string interactText = "Grab/Drop";
    private bool isGrabbed = false; // To track the grab state
    private Transform objectGrabPointTransform;

    private void Awake()
    {
        objectRigidbody = GetComponent<Rigidbody>();
    }

    public void Interact(Transform playerTransform)
    {
        // Toggle grab state
        if (!PlayerInteract.IsHoldingObject)
        {
            Grab(playerTransform);
        }
        else
        {
            Drop();
        }
    }

    public string GetInteractText()
    {
        return interactText;
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void Grab(Transform objectGrabPointTransform)
    {
        this.objectGrabPointTransform = objectGrabPointTransform;
        objectRigidbody.useGravity = false;
        objectRigidbody.isKinematic = true;

        // Grab the object as if it lays on a flat surface
        transform.position = objectGrabPointTransform.position;
        Vector3 fixedAngle = new Vector3(0, objectGrabPointTransform.eulerAngles.y, 0);
        transform.eulerAngles = fixedAngle;
        PlayerInteract.IsHoldingObject = true;
    }

    public void Drop()
    {
        this.objectGrabPointTransform = null;
        objectRigidbody.useGravity = true;
        objectRigidbody.isKinematic = false;
        PlayerInteract.IsHoldingObject = false;
        //PlayerInteract.ObjectDropped(); // Reset the holding flag
    }

    private void FixedUpdate()
    {
        //if (isGrabbed && objectGrabPointTransform != null)
        if (PlayerInteract.IsHoldingObject && objectGrabPointTransform != null)
        {
            // Ensures the object follows the grab point smoothly
            float lerpSpeed = 10f;
            Vector3 newPosition = Vector3.Lerp(transform.position, objectGrabPointTransform.position, Time.deltaTime * lerpSpeed);
            objectRigidbody.MovePosition(newPosition);
        }
    }
}
