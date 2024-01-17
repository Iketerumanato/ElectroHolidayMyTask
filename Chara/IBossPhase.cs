using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBossPhase
{
    //フェーズの最初にさせる処理
    void EnterPhase();

    //そのフェーズでさせる処理
    //void UpdatePhase();

    //現在のフェーズから出る
    void ExitPhase();
}