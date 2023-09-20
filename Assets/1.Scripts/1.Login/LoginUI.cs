using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginUI : UIBase
{
    public SignUI signUI;

    public override void Init()
    {
        signUI = ControlManager.NullCheck(signUI, transform, nameof(signUI));
        signUI.Init();
    }
}
