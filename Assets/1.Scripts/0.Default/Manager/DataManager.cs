using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : SingletonBase<DataManager>
{
    public string URL = "http://localhost:8080/TowerDefence/";

    public LoginType loginType;
    public GuestData guestData;
    public GoogleData googleData;

    // ���� ����
    public int userID;
    public string userName;

    public override void Init()
    {
        base.Init();
        guestData = new GuestData();
        googleData = new GoogleData();
    }


    public void SignData(LoginType type)
    {
        loginType = type;
        switch (loginType)
        {
            case LoginType.Guest:
                guestData.Save();
                break;
            case LoginType.Google:
                googleData.Save();
                break;
            default:
                break;
        }
    }

    public void LoginData(LoginType type)
    {
        loginType = type;
        switch (loginType)
        {
            case LoginType.Guest:
                // ��� �� �÷��� �����Ͱ� ������ �κ� UI�� �̵�
                // ��� �� �÷��� �����Ͱ� ������ �г��� ���� UI ����
                guestData.Load();
                break;
            case LoginType.Google:
                // ���� ���� ���� UI ����
                // ���� �� ������ ������ִ� ���� �ҷ�����
                // ���� �� ������ �г��� ���� UI ����
                googleData.Load();
                break;
            default:
                break;
        }
        StartCoroutine(TestDB(TestAction));
    }

    public void TestAction()
    {
        SceneTypeManager.Instance.ChangeScene(SceneType.Lobby);
    }

    public IEnumerator TestDB(Action action)
    {
        WWWForm form = new WWWForm();
        // json�� �α��� ���� ��������
        form.AddField("SecretCode", "hong"); //post��� ����.

        var www = new WWW(URL + "TowerDefence_Test.json.php", form);
        yield return www; //���� �ٿ�ε� �Ϸ�ñ��� ���.

        // ������ ������
        if (string.IsNullOrEmpty(www.error))
        {
            ControlManager.ShowLog(www.text);
            action.Invoke();
        }
        else
        {
            Debug.Log("Error : " + www.error);
        }
        www.Dispose();
    }
}