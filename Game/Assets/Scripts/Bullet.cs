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
        // curPosition -> targetPostiion���� �̵�
    }

    private void Update()
    {   // ���� ��ġ���� ��ǥ �������� �̵�
        transform.position += direction * speed * Time.deltaTime;
        float distance = Vector3.Distance(transform.position, Character.position);
        if (distance >= 30.0f)
        {
            Destroy(gameObject);
        }
    }
}


    

    // ĳ���Ϳ��� �Ÿ��� �����̻� �������� Destroy

