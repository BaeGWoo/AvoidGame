using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{
    [SerializeField] Vector3 targetPosition;
    [SerializeField] Vector3 direction;
    [SerializeField] float speed;
    private void Awake()
    {
        targetPosition = Character.position;
        speed = 5.0f;
        direction = (targetPosition - transform.position).normalized;
        // curPosition -> targetPostiion으로 이동
    }

    private void Update()
    {   // 현재 위치에서 목표 방향으로 이동
        transform.position += direction * speed * Time.deltaTime;
        float distance = Vector3.Distance(transform.position, Character.position);
        if (distance >= 30.0f)
        {
            Destroy(gameObject);
        }
    }
}


    

    // 캐릭터와의 거리가 일정이상 벌어지면 Destroy

