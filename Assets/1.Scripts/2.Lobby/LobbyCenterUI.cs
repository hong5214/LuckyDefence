using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyCenterUI : MonoBehaviour
{
    public TMPro.TMP_Text stageNum;
    
    public Button playBattleButton;

    public int stageIndex;

    public void Init()
    {
        stageNum = ControlManager.NullCheck(stageNum, transform, nameof(stageNum));
        playBattleButton = ControlManager.NullCheck(playBattleButton, transform, nameof(playBattleButton));

        ControlManager.SetButton(playBattleButton, StartBattle);
    }

    public void StartBattle()
    {
        // �������� ����
        SceneTypeManager.Instance.ChangeScene(SceneType.Main); // ���� ������ �̵�
    }
}
