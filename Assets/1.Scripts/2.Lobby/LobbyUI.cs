using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyUI : UIBase
{
    public LobbyTopUI lobbyTopUI;
    public LobbyCenterUI lobbyCenterUI;
    public LobbyBottomUI lobbyBottomUI;

    public override void Init()
    {
        lobbyTopUI = ControlManager.NullCheck(lobbyTopUI, transform, nameof(lobbyTopUI));
        lobbyCenterUI = ControlManager.NullCheck(lobbyCenterUI, transform, nameof(lobbyCenterUI));
        lobbyBottomUI = ControlManager.NullCheck(lobbyBottomUI, transform, nameof(lobbyBottomUI));

        lobbyTopUI.Init();
        lobbyCenterUI.Init();
        lobbyBottomUI.Init();
    }
}