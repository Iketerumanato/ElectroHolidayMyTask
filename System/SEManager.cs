using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEManager : MonoBehaviour
{
    //SEÇÃëfçﬁåQ
    [SerializeField] AudioClip[] MetalSE;
    [SerializeField] AudioClip[] AndroidSE;
    AudioSource SESource;

    public static SEManager seInstance;

    private void Awake()
    {

        if(seInstance == null)
        {
            seInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        SESource = gameObject.GetComponent<AudioSource>();
    }

    #region//PlayAndroidSE
    public void PlayAndroidJumpSE()
    {
        SESource.PlayOneShot(AndroidSE[0]);
    }

    public void PlayEnterAndroidSE()
    {
        SESource.PlayOneShot(AndroidSE[1]);
    }

    public void PlayLeaveAndroidSE()
    {
        //SESource.PlayOneShot(AndroidSE[2]);
    }
    #endregion

    #region//PlayMetalSE
    public void PlayEnterMetalSE()
    {
        SESource.PlayOneShot(MetalSE[0]);
    }

    public void PlayLeaveMetalSE()
    {
        SESource.PlayOneShot(MetalSE[1]);
    }
    #endregion
}
