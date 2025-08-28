using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using System.Collections;

namespace MyVRGame
{
    public class FireOnActivity : MonoBehaviour
    {
        #region Variables
        public GameObject bulletPrefab;
        public Transform firePoint;
        public float speed = 20f;

        //Effect
        public GameObject muzzleEffect;
        public AudioSource pistolShot;

        //연사방지
        private bool isFire = false;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //Active 이벤트 등록
            XRGrabInteractable grabInteractable = this.GetComponent<XRGrabInteractable>();
            grabInteractable.activated.AddListener(Fire);
        }
        #endregion

        #region Custom Method
        //총알 발사
        public void Fire(ActivateEventArgs args)
        {
            if (isFire)
                return;

            Debug.Log("Fire");

            StartCoroutine(Shoot());
        }

        IEnumerator Shoot()
        {
            isFire = true;

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Rigidbody>().linearVelocity = firePoint.forward * speed;
            Destroy(bullet, 3f);

            //vfx, sfx
            pistolShot.Play();
            muzzleEffect.SetActive(true);

            yield return new WaitForSeconds(0.5f);
            muzzleEffect.SetActive(false);

            isFire = false;
        }
        #endregion
    }
}