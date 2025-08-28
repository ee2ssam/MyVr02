using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

namespace MyVRGame
{
    //텔레포트 인터렉터를 액티브 버튼을 누르면 보여지게 만든다
    public class ActivateTeleportationRay : MonoBehaviour
    {
        #region Variables
        public GameObject leftTeleportation;
        public GameObject rightTeleportation;

        //액티브 인풋값
        public InputActionProperty leftActivate;
        public InputActionProperty rightActivate;

        //
        public XRRayInteractor leftGrabRay;
        public XRRayInteractor rightGrabRay;
        #endregion

        #region Unity Event Method
        private void Update()
        {
            //인풋값 읽어오기
            float leftValue = leftActivate.action.ReadValue<float>();
            float rigthValue = rightActivate.action.ReadValue<float>();

            //GrabRay가 오브젝트를 가리킬때
            bool isLeftRayHovering = leftGrabRay.TryGetHitInfo(out Vector3 leftPos, out Vector3 leftNormal,
                out int leftNumber, out bool leftValid);
            bool isRightRayHovering = rightGrabRay.TryGetHitInfo(out Vector3 rightPos, out Vector3 rigthNormal,
                out int rightNumber, out bool leftVaid);

            //인풋값이 들어오면 활성화 시킨다
            leftTeleportation.SetActive(!isLeftRayHovering && leftValue > 0.1f);
            rightTeleportation.SetActive(!isRightRayHovering && rigthValue > 0.1f);
        }
        #endregion
    }
}