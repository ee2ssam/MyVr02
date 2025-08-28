using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit;

namespace MyVRGame
{
    public class XRGrabInteractableTwoAttach : XRGrabInteractable
    {
        #region Variables
        public Transform leftAttackTransform;
        public Transform rightAttackTransform;
        #endregion

        #region Unity Event Method
        protected override void OnSelectEntering(SelectEnterEventArgs args)
        {
            //Attack Point 셋팅+
            if (args.interactorObject.transform.CompareTag("LeftHand"))
            {
                attachTransform = leftAttackTransform;
            }
            else if (args.interactorObject.transform.CompareTag("RightHand"))
            {
                attachTransform = rightAttackTransform;
            }

            base.OnSelectEntering(args);
        }

        /*protected override void OnSelectEntered(SelectEnterEventArgs args)
        {
            //Attack Point 셋팅
            if(args.interactorObject.transform.CompareTag("LeftHand"))
            {
                attachTransform = leftAttackTransform;
            }
            else if (args.interactorObject.transform.CompareTag("RightHand"))
            {
                attachTransform = rightAttackTransform;
            }

            base.OnSelectEntered(args);
        }*/
        #endregion
    }
}
