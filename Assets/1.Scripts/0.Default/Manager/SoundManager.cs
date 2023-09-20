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
                // 로그인 배경/효과음 적용
                break;
            case SceneType.Lobby:
                // 로비 배경/효과음 적용
                break;
            case SceneType.Main:
                // 메인 배경/효과음 적용
                break;
            default:
                break;
        }
    }
}
