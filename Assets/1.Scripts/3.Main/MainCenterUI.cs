using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCenterUI : MonoBehaviour
{
    public RoundUI roundUI;

    public void Init()
    {
        roundUI = ControlManager.NullCheck(roundUI, transform, nameof(roundUI));
        roundUI.Init();
    }
}