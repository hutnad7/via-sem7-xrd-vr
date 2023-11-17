using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FixedGrabScript : XRGrabInteractable

{
 [SerializeField] private Transform rightHandAttachTransrom;
 [SerializeField] private Transform leftHandAttachTransrom;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if(args.interactableObject.transform.CompareTag("RightHand"))
        {
            attachTransform = rightHandAttachTransrom;
        }

         if(args.interactableObject.transform.CompareTag("LeftHand"))
        {
            attachTransform = leftHandAttachTransrom;
        }


        base.OnSelectEntered(args);
    }

}
