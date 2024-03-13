using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour, IInteractable {

    [SerializeField] private string interactText;

    private Animator animator;
    private NPCHeadLookAt npcHeadLookAt;
    public bool bleedingHead;

    private void Awake() {
        animator = GetComponent<Animator>();
        npcHeadLookAt = GetComponent<NPCHeadLookAt>();
    }

    public void Interact(Transform interactorTransform) {
        Vector3 chatBubbleOffset = new Vector3(-.3f, 1.2f, 0f);
        if (bleedingHead)
        {
            ChatBubble3D.Create(transform, chatBubbleOffset,
                            ChatBubble3D.IconType.Happy,
                            "Happy Halloween!!");
        }
        else
        {
            ChatBubble3D.Create(transform, chatBubbleOffset,
                                ChatBubble3D.IconType.Happy,
                                "Could you place all the Pumpkins in the baskets?");
        }

        //animator.SetTrigger("Talk");

        float offset = .4f;
        npcHeadLookAt.LookAtPosition(interactorTransform.position - Vector3.up * offset);
    }

    public string GetInteractText() {
        return interactText;
    }

    public Transform GetTransform() {
        return transform;
    }

}