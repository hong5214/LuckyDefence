using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundUI : MonoBehaviour
{
    public TMPro.TMP_Text stageNum;
    public TMPro.TMP_Text roundNum;
    public TMPro.TMP_Text limitTime;
    public void Init()
    {
        stageNum = ControlManager.NullCheck(stageNum, transform, nameof(stageNum));
        roundNum = ControlManager.NullCheck(roundNum, transform, nameof(roundNum));
        limitTime = ControlManager.NullCheck(limitTime, transform, nameof(limitTime));
    }
    public void SetStage(int stage, int nowRound, int maxRound)
    {
        stageNum.text = "Stage" + stage;
        SetRound(nowRound, maxRound);
    }

    public void SetRound(int nowRound, int maxRound)
    {
        roundNum.text = "Round(" + nowRound + "/" + maxRound + ")";
        SetTime(60.0f);
    }

    public void SetTime(float time)
    {
        int sec = (int)(time * 100) / 100;
        int milisec = (int)(time * 100) % 100;
        limitTime.text = "[Time] "+ string.Format("{0:00}", sec) + ":" + string.Format("{0:00}", milisec);
    }
}
