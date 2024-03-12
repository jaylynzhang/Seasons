using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private Transform objectGrabPointTransform;
    [SerializeField] private LayerMask pickUpLayerMask;
    [SerializeField] private float interactRange = 3f;
    public static bool IsHoldingObject { get; set; } = false;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            IInteractable interactable = GetInteractableObject();
            if (interactable != null)
            {
                interactable.Interact(objectGrabPointTransform);
            }
        }
    }

    public IInteractable GetInteractableObject()
    {
        List<IInteractable> interactableList = new List<IInteractable>();
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange, pickUpLayerMask);
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out IInteractable interactable))
            {
                interactableList.Add(interactable);
            }
        }

        IInteractable closestInteractable = null;
        foreach (IInteractable interactable in interactableList)
        {
            if (closestInteractable == null ||
                Vector3.Distance(transform.position, interactable.GetTransform().position) <
                Vector3.Distance(transform.position, closestInteractable.GetTransform().position))
            {
                closestInteractable = interactable;
            }
        }

        return closestInteractable;
    }

    //// Method to be called by the ObjectInteractable when dropped
    //public static void ObjectDropped()
    //{
    //    IsHoldingObject = false;
    //}
}