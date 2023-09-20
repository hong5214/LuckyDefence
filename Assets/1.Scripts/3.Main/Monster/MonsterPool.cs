using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPool : MonoBehaviour
{    
    public List<Monster> monsters;

    public int nowCount = 0; // ���� ���� ��
    public int leftCount = 20; // ���� ���� ��
    public int maxCount = 20; // �ִ� ���� ��

    public void SpawnMonster(GameObject monsterObject)
    {
        leftCount--;
        GameObject monster = (GameObject)Instantiate(monsterObject, transform.position, Quaternion.identity);
        monster.transform.parent = this.transform;
        monster.transform.eulerAngles = new Vector3(0, 90, 0);
        monsters.Add(monster.GetComponent<Monster>()); //������Ʈ �����κ�
    }
}
