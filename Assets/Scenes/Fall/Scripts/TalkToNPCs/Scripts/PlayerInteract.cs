using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {
    // For PlayerPickUpDrop
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private Transform objectGrabPointTransform;
    [SerializeField] private LayerMask pickUpLayerMask;

    //private ObjectGrabbable objectGrabbable;

    private void Update() {
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    IInteractable interactable = GetInteractableObject();
        //    if (interactable != null)
        //    {
        //        interactable.Interact(transform);
        //    }
        //}

        //// Pick up or drop objects
        //if (Input.GetKeyDown(KeyCode.G))
        //{
        //    HandlePickUpOrDrop();
        //}

        if (Input.GetKeyDown(KeyCode.E))
        {
            IInteractable interactable = GetInteractableObject();
            if (interactable != null)
            {
                interactable.Interact(objectGrabPointTransform);
            }
        }
    }

    public IInteractable GetInteractableObject() {
        List<IInteractable> interactableList = new List<IInteractable>();
        float interactRange = 3f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray) {
            if (collider.TryGetComponent(out IInteractable interactable)) {
                interactableList.Add(interactable);
            }
        }

        IInteractable closestInteractable = null;
        foreach (IInteractable interactable in interactableList) {
            if (closestInteractable == null) {
                closestInteractable = interactable;
            } else {
                if (Vector3.Distance(transform.position, interactable.GetTransform().position) < 
                    Vector3.Distance(transform.position, closestInteractable.GetTransform().position)) {
                    // Closer
                    closestInteractable = interactable;
                }
            }
        }

        return closestInteractable;
    }

    //private void HandlePickUpOrDrop()
    //{
    //    if (objectGrabbable == null)
    //    {
    //        // Not carrying an object, try to grab
    //        float pickUpDistance = 4f;
    //        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance, pickUpLayerMask))
    //        {
    //            if (raycastHit.transform.TryGetComponent(out objectGrabbable))
    //            {
    //                Debug.Log(objectGrabbable);
    //                objectGrabbable.Grab(objectGrabPointTransform);
    //            }
    //        }
    //    }
    //    else
    //    {
    //        // Currently carrying something, drop
    //        objectGrabbable.Drop();
    //        objectGrabbable = null;
    //    }
    //}
}