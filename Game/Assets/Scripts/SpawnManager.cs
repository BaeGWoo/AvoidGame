using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] float levelSpeed;
    [SerializeField] int count = 5;
    public float radius = 15.0f; // 원의 반지름
    public int segments = 36; // 원을 구성하는 세그먼트 수
    private LineRenderer lineRenderer;

    void Start()
    {
        levelSpeed = 1.5f;
        lineRenderer = gameObject.GetComponent<LineRenderer>();

        if (segments < 1)
            segments = 1;

        lineRenderer.positionCount = segments + 1; // 세그먼트 수 +1로 닫힌 원 만듦
        lineRenderer.loop = true; // 원 형태로 연결

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

        lineRenderer.startWidth = 0.05f; // 두께 조절
        lineRenderer.endWidth = 0.05f; // 두께 조절
        
    }


    Vector3 RandomPointOnCircle()
    {
        // 랜덤 인덱스 생성
        int randomIndex = Random.Range(0, segments + 1);
        float angle = randomIndex * (360f / segments) * Mathf.Deg2Rad; // 각도 계산
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
    // 캐릭터의 위치에 따라 Spawn위치 지정
    // Spawn위치중 랜덤한 위치에 Prefab 생성
}
