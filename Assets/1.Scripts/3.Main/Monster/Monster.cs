using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float rotationSpeed = 50f;   // ȸ�� �ӵ� (���� ����)
    public float radius = 2.2f;           // ���� ������ (���� ����)
    public float height = 0f;           // ������Ʈ�� ���� (���� ����)
    private float angle = 0f;           // �ʱ� ����

    private void Update()
    {
        // ������ �������� ��ȯ
        float angleInRadians = (angle + 90) % 360 * Mathf.Deg2Rad;

        // �� � ������ ����Ͽ� ���ο� ��ġ ���
        float x = Mathf.Cos(angleInRadians) * radius;
        float z = Mathf.Sin(angleInRadians) * radius;

        // ���ο� ��ġ ����
        Vector3 newPosition = new Vector3(-x, height, z);
        transform.position = newPosition;

        // ������Ʈ ȸ��
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        // ���� ������Ʈ
        angle += rotationSpeed * Time.deltaTime;
        if (angle >= 360f)
        {
            angle -= 360f; // ������ 360���� �Ѿ�� 0���� �ʱ�ȭ
        }
    }
}
