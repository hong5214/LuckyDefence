using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : SingletonBase<SoundManager>
{
    public override void Init()
    {
        base.Init();
    }

    public void ChangeSound(SceneType sceneType)
    {
        switch (sceneType)
        {
            case SceneType.Login:
                // �α��� ���/ȿ���� ����
                break;
            case SceneType.Lobby:
                // �κ� ���/ȿ���� ����
                break;
            case SceneType.Main:
                // ���� ���/ȿ���� ����
                break;
            default:
                break;
        }
    }
}
