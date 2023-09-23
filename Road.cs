using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{

    // 도로와 관련된 변수들
    public float speed = 0.1f;

    public float roadWidth = 6.0f;
    public float roadHeight = 8.0f;

    public float x = 0.0f;
    public float y = 0.0f;

    void Start()
    {
        
    }

    void Update()
    {
        // 매 프레임마다 y의 위치값을 speed 만큼 증가
        y += Time.deltaTime * speed;

        // 텍스쳐가 아래방향으로 움직이게 만들기
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, -y);

    }
}
