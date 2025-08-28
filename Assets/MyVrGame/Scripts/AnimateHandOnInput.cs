using UnityEngine;
using UnityEngine.InputSystem;

namespace MyVRGame
{
    public class AnimateHandOnInput : MonoBehaviour
    {
        #region Variables
        //참조
        private Animator animator;

        //인풋
        public InputActionProperty pinchAnimationAction;
        public InputActionProperty gripAnimationAction;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //참조
            animator = this.GetComponent<Animator>();
        }

        private void Update()
        {
            //인풋값 처리
            float triggerValue = pinchAnimationAction.action.ReadValue<float>();
            float gripValue = gripAnimationAction.action.ReadValue<float>();

            //애니메이션
            //Debug.Log($"========= {gripValue}");
            animator.SetFloat("Trigger", triggerValue);
            animator.SetFloat("Grip", gripValue);
        }
        #endregion
    }
}
