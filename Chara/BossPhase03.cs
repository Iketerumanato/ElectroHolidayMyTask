using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhase03 : MonoBehaviour,IBossPhase
{
    [SerializeField] GameObject Phase03Hand;

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
        Debug.Log("This Phase in ThirdPhase");
        //PlayBossPhase03Anime();
        //SpawnPhase03Hand();
    }

    public void ExitPhase()
    {
        Debug.Log("Boss BreakThrough!");
        //Destroy(Phase03Hand);
    }

    #region//アニメーション再生処理群
    //Phase03のアニメーション再生
    public void PlayBossPhase03Anime()
    {
        BossAnimator.SetBool("IsBossPhase03", true);
    }

    //Phase03のアニメーション再生終了
    public void EndPhase03Anime()
    {
        BossAnimator.SetBool("IsBossPhase03", false);
    }
    #endregion

    #region//スポーン処理群 
    //Phase03の手のスポーン
    public void SpawnPhase03Hand()
    {
        //手が出現(手はグー)
        Instantiate(Phase03Hand, HandStartPos, Quaternion.identity);
    }
    #endregion
}