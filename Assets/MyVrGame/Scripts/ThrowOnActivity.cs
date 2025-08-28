using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using System.Collections;

public class ThrowOnActivity : MonoBehaviour
{
    #region Variables
    public GameObject vfxEffect;
    public Transform firePoint;

    //�������
    private bool isFire = false;
    #endregion

    #region Unity Event Method
    private void Start()
    {
        //Active �̺�Ʈ ���
        XRGrabInteractable grabInteractable = this.GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener(Fire);
    }
    #endregion

    #region Custom Method
    //�Ѿ� �߻�
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
