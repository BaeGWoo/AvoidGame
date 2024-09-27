using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] float levelSpeed;
    [SerializeField] int count = 5;
    public float radius = 15.0f; // ���� ������
    public int segments = 36; // ���� �����ϴ� ���׸�Ʈ ��
    private LineRenderer lineRenderer;

    void Start()
    {
        levelSpeed = 1.5f;
        lineRenderer = gameObject.GetComponent<LineRenderer>();

        if (segments < 1)
            segments = 1;

        lineRenderer.positionCount = segments + 1; // ���׸�Ʈ �� +1�� ���� �� ����
        lineRenderer.loop = true; // �� ���·� ����

        StartCoroutine(CreateBullet());
    }

    private void Update()
    {
        CreateCircle();

        
    }

    void CreateCircle()
    {
        float angleStep = 360f / segments;

        for (int i = 0; i <= segments; i++)
        {
            float angle = i * angleStep * Mathf.Deg2Rad;
            Vector3 point = new Vector3(Mathf.Cos(angle) * radius, 0, Mathf.Sin(angle) * radius) + Character.position;
            lineRenderer.SetPosition(i, point);
        }

        lineRenderer.startWidth = 0.05f; // �β� ����
        lineRenderer.endWidth = 0.05f; // �β� ����
        
    }


    Vector3 RandomPointOnCircle()
    {
        // ���� �ε��� ����
        int randomIndex = Random.Range(0, segments + 1);
        float angle = randomIndex * (360f / segments) * Mathf.Deg2Rad; // ���� ���
        Vector3 randomPoint = new Vector3(Mathf.Cos(angle) * radius, 0, Mathf.Sin(angle) * radius) + Character.position;
        return randomPoint;
    }

    IEnumerator CreateBullet()
    {
        while (Character.LifeCount > 0)
        {
            yield return new WaitForSecondsRealtime(levelSpeed);
            Instantiate(prefab, RandomPointOnCircle(), Quaternion.identity);
            count--;
        }
    }
    // ĳ������ ��ġ�� ���� Spawn��ġ ����
    // Spawn��ġ�� ������ ��ġ�� Prefab ����
}
