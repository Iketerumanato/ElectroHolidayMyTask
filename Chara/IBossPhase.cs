using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBossPhase
{
    //�t�F�[�Y�̍ŏ��ɂ����鏈��
    void EnterPhase();

    //���̃t�F�[�Y�ł����鏈��
    //void UpdatePhase();

    //���݂̃t�F�[�Y����o��
    void ExitPhase();
}