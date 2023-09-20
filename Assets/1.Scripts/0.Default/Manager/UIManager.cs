using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : SingletonBase<UIManager>
{
    public List<UIBase> uiList;

    public LoginUI loginUI;
    public LobbyUI lobbyUI;
    public MainUI mainUI;    

    public override void Init()
    {
        base.Init();
        ControlManager.ShowLog("UIManager 초기화");

        loginUI = InitUI(loginUI, nameof(loginUI)) as LoginUI;
        lobbyUI = InitUI(lobbyUI, nameof(lobbyUI)) as LobbyUI;
        mainUI = InitUI(mainUI, nameof(mainUI)) as MainUI;

        ChangeUI(SceneType.Login);
    }

    public UIBase InitUI(UIBase ui, string uiName)
    {
        ui = ControlManager.NullCheck(ui, transform, uiName);
        uiList.Add(ui);
        ui?.Init();
        return ui;
    }

    public void ChangeUI(SceneType sceneType)
    {
        // 모든 UI 닫기
        foreach (var ui in uiList)
            ui.gameObject.SetActive(false);

        // 현재 씬 UI만 열기
        uiList[(int)sceneType].gameObject.SetActive(true);

        switch (sceneType)
        {
            case SceneType.Login:
                // 로그인 UI 기본세팅
                break;
            case SceneType.Lobby:
                // 로비 UI 기본세팅
                break;
            case SceneType.Main:
                // 메인 UI 기본세팅
                break;
            default:
                break;
        }
    }
}