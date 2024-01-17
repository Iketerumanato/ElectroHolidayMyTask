using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhase01 : MonoBehaviour,IBossPhase
{
    public void EnterPhase()
    {
        return;
    }

    public void ExitPhase()
    {
        Debug.Log("Exit Phase01");
        return;
    }
}