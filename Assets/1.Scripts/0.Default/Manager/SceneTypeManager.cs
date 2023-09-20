using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTypeManager : SingletonBase<SceneTypeManager>
{
    public SceneType currentScene;
    public override void Init()
    {
        base.Init();
        ControlManager.ShowLog("SceneManager 초기화");
        currentScene = SceneType.Login;
    }

    public void ChangeScene(SceneType sceneType)
    {
        if (currentScene == sceneType) return; // 이미 현재 씬이므로 이동 불가

        UIManager.Instance.ChangeUI(sceneType); // 현재 씬만 UI 오픈

        SoundManager.Instance.ChangeSound(sceneType); // 오디오 변경

        ControlManager.ShowLog("CurrentScene : " + sceneType.ToString());

        SceneManager.LoadScene(sceneType.ToString()); // 씬 이동
    }
}
