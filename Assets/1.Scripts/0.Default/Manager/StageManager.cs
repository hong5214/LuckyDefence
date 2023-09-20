using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    private static StageManager instance;

    public GameState gameState;

    public int roundNowNum;
    public int roundMaxNum;
    public float time;
    public float gameSpeed;
    public GameObject[] monsterObjects;

    public RoundUI roundUI;
    public MonsterPool monsterPool;

    public static StageManager Instance()
    {
        if (instance == null)
        {
            instance = new StageManager();
        }
        return instance;
    }

    public void Start()
    {
        Init();
        StartCoroutine("StartGame");
    }

    public void Init()
    {
        if (roundUI == null) roundUI = UIManager.Instance.mainUI.mainCenterUI.roundUI;
        if (monsterPool == null) monsterPool = ControlManager.NullCheck(monsterPool, transform, "MonsterPool");
        gameState = GameState.Plaing;
        roundNowNum = 1;
        roundMaxNum = 5; 
        time = 60.0f;
        gameSpeed = 0.01f;
        roundUI.SetStage(GameManager.Instance.selectStageNum, roundNowNum, roundMaxNum);
    }

    public void NextRound()
    {
        roundNowNum++;
        time = 60.0f;
        monsterPool.leftCount = monsterPool.maxCount;
        roundUI.SetRound(roundNowNum, roundMaxNum);
    }

    public IEnumerator StartGame()
    {
        while (roundNowNum <= roundMaxNum)
        {
            if(time > 0.0f)
            {
                switch (gameState)
                {
                    case GameState.Plaing:
                        if ((6000 - time * 100) / 100 > (monsterPool.maxCount - monsterPool.leftCount))
                        {
                            if (monsterPool.leftCount != 0)
                            {
                                monsterPool.SpawnMonster(monsterObjects[roundNowNum - 1]);
                            }
                        }
                        yield return new WaitForSeconds(gameSpeed);
                        time -= gameSpeed;
                        roundUI.SetTime(time);
                        break;
                    case GameState.Paused:
                        Debug.Log("일시 정지");
                        yield break;
                    case GameState.Next:
                        NextRound();
                        gameState = GameState.Plaing;
                        break;
                    case GameState.Win:
                        Debug.Log("라운드 클리어");
                        yield break;
                    case GameState.Lose:
                        Debug.Log("라운드 실패(몬스터초과)");
                        yield break;
                }                
            }
            else
            {
                if (roundNowNum != roundMaxNum)
                    NextRound();
                else
                {
                    Debug.Log("라운드 실패(시간초과)");
                    gameState = GameState.Lose;
                    yield break;
                }
            }
        }        
    }
}
