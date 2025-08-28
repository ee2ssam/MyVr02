using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using System.Collections;

public class ThrowOnActivity : MonoBehaviour
{
    #region Variables
    public GameObject vfxEffect;
    public Transform firePoint;

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
        
        //vfx, sfx
        vfxEffect.SetActive(true);

        yield return new WaitForSeconds(3f);

        vfxEffect.SetActive(false);

        isFire = false;
    }
    #endregion
}
