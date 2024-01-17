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

    #region//�A�j���[�V�����Đ������Q
    //Phase02�̃A�j���[�V�����Đ�
    public void PlayBossPhase02Anime()
    {
        BossAnimator.SetBool("IsBossPhase02", true);
    }

    //Phase02�̃A�j���[�V�����Đ��I��
    public void EndPhase02Anime()
    {
        BossAnimator.SetBool("IsBossPhase02", false);
    }
    #endregion

    #region//�X�|�[�������Q
    //Phase02�̎�̃X�|�[��
    public void SpawnPhase02Hand()
    {
        //�肪�o��(��̓p�[)
        Instantiate(Phase02Hand, HandStartPos, Quaternion.identity);
    }
    #endregion
}
