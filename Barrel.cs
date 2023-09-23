using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public float speed = 5.0f;
    private float deadHeight = 11.0f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        // 일정 높이 이상일 시 자기자신 없애기
        if (transform.position.y > deadHeight) {
            Destroy(gameObject);
        }
    }
}
