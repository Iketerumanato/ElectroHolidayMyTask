using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhase02 : MonoBehaviour,IBossPhase
{
    [SerializeField] GameObject Phase02Hand;

    Vector3 HandStartPos;
    [SerializeField] float StartHandPosX = -6.4f;
    [SerializeField] float StartHandPosY = 2f;

    [SerializeField] Animator BossAnimator;

    private void Start()
    {
        BossAnimator.GetComponent<Animator>();
        //HandStartPos = new Vector3(StartHandPosX, StartHandPosY, 0f);
    }

    public void EnterPhase()
    {
        Debug.Log("This Phase in SecondPhase");
        //PlayBossPhase02Anime();
        //SpawnPhase02Hand();
    }

    public void ExitPhase()
    {
        Debug.Log("Exit Phase02");

        //Destroy(Phase02Hand);
    }

    #region//アニメーション再生処理群
    //Phase02のアニメーション再生
    public void PlayBossPhase02Anime()
    {
        BossAnimator.SetBool("IsBossPhase02", true);
    }

    //Phase02のアニメーション再生終了
    public void EndPhase02Anime()
    {
        BossAnimator.SetBool("IsBossPhase02", false);
    }
    #endregion

    #region//スポーン処理群
    //Phase02の手のスポーン
    public void SpawnPhase02Hand()
    {
        //手が出現(手はパー)
        Instantiate(Phase02Hand, HandStartPos, Quaternion.identity);
    }
    #endregion
}
