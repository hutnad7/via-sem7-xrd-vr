using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FixedGrabScript : XRGrabInteractable

{
 [SerializeField] private Transform rightHandAttachTransfrom;
 [SerializeField] private Transform leftHandAttachTransfrom;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if(args.interactableObject.transform.CompareTag("RightHand"))
        {
            
            attachTransform = rightHandAttachTransfrom;
            Debug.Log("righthand");
        }

         if(args.interactableObject.transform.CompareTag("LeftHand"))
        {
            attachTransform = leftHandAttachTransfrom;
        }


        base.OnSelectEntered(args);
    }

}
