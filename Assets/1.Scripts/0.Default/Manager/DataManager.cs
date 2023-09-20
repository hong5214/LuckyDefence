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

    // 유저 정보
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
                // 기기 내 플레이 데이터가 있으면 로비 UI로 이동
                // 기기 내 플레이 데이터가 없으면 닉네임 선택 UI 오픈
                guestData.Load();
                break;
            case LoginType.Google:
                // 구글 계정 선택 UI 오픈
                // 선택 시 있으면 저장되있는 정보 불러오기
                // 선택 시 없으면 닉네임 선택 UI 오픈
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
        // json의 로그인 정보 가져오기
        form.AddField("SecretCode", "hong"); //post방식 전달.

        var www = new WWW(URL + "TowerDefence_Test.json.php", form);
        yield return www; //웹의 다운로드 완료시까지 대기.

        // 에러가 없으면
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