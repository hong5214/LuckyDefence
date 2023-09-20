using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : UIBase
{
    public MainTopUI mainTopUI;
    public MainCenterUI mainCenterUI;
    public MainBottomUI mainBottomUI;

    public override void Init()
    {
        mainTopUI = ControlManager.NullCheck(mainTopUI, transform, nameof(mainTopUI));
        mainCenterUI = ControlManager.NullCheck(mainCenterUI, transform, nameof(mainCenterUI));
        mainBottomUI = ControlManager.NullCheck(mainBottomUI, transform, nameof(mainBottomUI));

        mainTopUI.Init();
        mainCenterUI.Init();
        mainBottomUI.Init();
    }
}