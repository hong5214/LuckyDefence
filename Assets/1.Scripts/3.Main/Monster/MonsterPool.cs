using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPool : MonoBehaviour
{    
    public List<Monster> monsters;

    public int nowCount = 0; // 현재 몬스터 수
    public int leftCount = 20; // 남은 몬스터 수
    public int maxCount = 20; // 최대 몬스터 수

    public void SpawnMonster(GameObject monsterObject)
    {
        leftCount--;
        GameObject monster = (GameObject)Instantiate(monsterObject, transform.position, Quaternion.identity);
        monster.transform.parent = this.transform;
        monster.transform.eulerAngles = new Vector3(0, 90, 0);
        monsters.Add(monster.GetComponent<Monster>()); //오브잭트 생성부분
    }
}
