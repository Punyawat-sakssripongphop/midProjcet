using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : BaseInteractObj
{
    public Animator doorAnimator;
    public bool isOpen = false;

    void Start()
    {
        doorAnimator.SetBool("IsOpen", isOpen);
    }

    public override void Interact()
    {
        base.Interact();
        isOpen = !isOpen;
        doorAnimator.SetBool("IsOpen", isOpen);
    }
}
