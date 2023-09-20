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
        ControlManager.ShowLog("UIManager �ʱ�ȭ");

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
        // ��� UI �ݱ�
        foreach (var ui in uiList)
            ui.gameObject.SetActive(false);

        // ���� �� UI�� ����
        uiList[(int)sceneType].gameObject.SetActive(true);

        switch (sceneType)
        {
            case SceneType.Login:
                // �α��� UI �⺻����
                break;
            case SceneType.Lobby:
                // �κ� UI �⺻����
                break;
            case SceneType.Main:
                // ���� UI �⺻����
                break;
            default:
                break;
        }
    }
}