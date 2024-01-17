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
        // 各フェーズのインスタンスを保持
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
            bossPhase?.ExitPhase(); // 現在のフェーズから出る
            bossPhase = GetNextPhase(bossPhase);//次のフェーズを取得
            SwitchPhase(bossPhase);//取得したフェーズに切り替え
        }
    }

    //ボスの最初のフェーズに入るためにStart()でも呼び出される
    public void SwitchPhase(IBossPhase nextPhase)
    {
        nextPhase.EnterPhase(); // 次のフェーズ入場
        bossPhase = nextPhase; // 現在のフェーズを更新
    }

    //突貫工事だが順繰りに取得させていく
    IBossPhase GetNextPhase(IBossPhase currentPhase)
    {
        
        if (currentPhase == null) return phase01;
        else if (currentPhase == phase01) return phase02;
        else if (currentPhase == phase02) return phase03;
        else return currentPhase;
    }
}