using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float rotationSpeed = 50f;   // 회전 속도 (조절 가능)
    public float radius = 2.2f;           // 원의 반지름 (조절 가능)
    public float height = 0f;           // 오브젝트의 높이 (조절 가능)
    private float angle = 0f;           // 초기 각도

    private void Update()
    {
        // 각도를 라디안으로 변환
        float angleInRadians = (angle + 90) % 360 * Mathf.Deg2Rad;

        // 원 운동 공식을 사용하여 새로운 위치 계산
        float x = Mathf.Cos(angleInRadians) * radius;
        float z = Mathf.Sin(angleInRadians) * radius;

        // 새로운 위치 설정
        Vector3 newPosition = new Vector3(-x, height, z);
        transform.position = newPosition;

        // 오브젝트 회전
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        // 각도 업데이트
        angle += rotationSpeed * Time.deltaTime;
        if (angle >= 360f)
        {
            angle -= 360f; // 각도가 360도를 넘어가면 0으로 초기화
        }
    }
}
