using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhaseSystem : MonoBehaviour
{
    IBossPhase bossPhase;

    BossPhase01 phase01;
    BossPhase02 phase02;
    BossPhase03 phase03;

    private void Start()
    {
        // �e�t�F�[�Y�̃C���X�^���X��ێ�
        phase01 = GetComponent<BossPhase01>();
        phase02 = GetComponent<BossPhase02>();
        phase03 = GetComponent<BossPhase03>();
        SwitchPhase(phase01);
        Debug.Log("Enter Boss Buttle!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            bossPhase?.ExitPhase(); // ���݂̃t�F�[�Y����o��
            bossPhase = GetNextPhase(bossPhase);//���̃t�F�[�Y���擾
            SwitchPhase(bossPhase);//�擾�����t�F�[�Y�ɐ؂�ւ�
        }
    }

    //�{�X�̍ŏ��̃t�F�[�Y�ɓ��邽�߂�Start()�ł��Ăяo�����
    public void SwitchPhase(IBossPhase nextPhase)
    {
        nextPhase.EnterPhase(); // ���̃t�F�[�Y����
        bossPhase = nextPhase; // ���݂̃t�F�[�Y���X�V
    }

    //�ˊэH���������J��Ɏ擾�����Ă���
    IBossPhase GetNextPhase(IBossPhase currentPhase)
    {
        
        if (currentPhase == null) return phase01;
        else if (currentPhase == phase01) return phase02;
        else if (currentPhase == phase02) return phase03;
        else return currentPhase;
    }
}