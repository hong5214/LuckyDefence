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
        ControlManager.ShowLog("SceneManager �ʱ�ȭ");
        currentScene = SceneType.Login;
    }

    public void ChangeScene(SceneType sceneType)
    {
        if (currentScene == sceneType) return; // �̹� ���� ���̹Ƿ� �̵� �Ұ�

        UIManager.Instance.ChangeUI(sceneType); // ���� ���� UI ����

        SoundManager.Instance.ChangeSound(sceneType); // ����� ����

        ControlManager.ShowLog("CurrentScene : " + sceneType.ToString());

        SceneManager.LoadScene(sceneType.ToString()); // �� �̵�
    }
}
