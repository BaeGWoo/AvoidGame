using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class Character : MonoBehaviour
{
    [SerializeField] float speed = 2.0f;
    [SerializeField] Text lifeText;
    [SerializeField] Text Timer;
    [SerializeField] GameObject GameOver;
    [SerializeField] GameObject Victory;
    public static Vector3 position= Vector3.zero;
    private Rigidbody rigidbody;
    public static int LifeCount = 3;
    private float timer = 60;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        
    }

    private void Start()
    {
        lifeText.text =""+LifeCount;
        Timer.text = "60";
    }


    private void Update()
    {
        if (LifeCount<=0)
        {
            GameOver.SetActive(true);
            transform.position = Vector3.zero;
            return;
        }

        if (timer <= 1)
        {
            timer = 0;
            Victory.SetActive(true);
            transform.position = Vector3.zero;
            return;
        }

        float moveX = UnityEngine.Input.GetAxis("Horizontal");
        float moveZ = UnityEngine.Input.GetAxis("Vertical");

        // 캐릭터 이동 방향 계산
        Vector3 velocity = new Vector3(moveX, 0, moveZ);
        velocity *= speed;
        rigidbody.velocity = velocity;
        position=transform.position;

        timer-= Time.deltaTime;
        Timer.text = "" + (int)timer;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            LifeCount--;
            Destroy(other.gameObject);
            lifeText.text = "" + LifeCount;
        }
    }


}
