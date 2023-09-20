using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBase<GameManager>
{
    public int selectStageNum = 1;

    public void Awake()
    {
        Instance.Init();
        DataManager.Instance.Init();
        SceneTypeManager.Instance.Init();
        SoundManager.Instance.Init();
        UIManager.Instance.Init();
    }

    void Update()
    {
        // 시간 체크
        // 데이터 체크
    }
}
