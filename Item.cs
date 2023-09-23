using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // 아이템 관련 설정
    public float speed = 5.0f;
    private float deadHeight = -3.0f;

    public Road road;

    void Start()
    {

        // Road 가져오기
        road = GameObject.Find("Road").GetComponent<Road>();
        
        // Random한 offset 값 설정
        float offset = Random.Range(0, 3.0f);

        // 이동 속도에 랜덤한 offset을 적용하여 다양한 속도로 움직이게 적용
        speed = Random.Range(speed - offset, speed + offset);
    }

    void Update()
    {

        // 매 프레임마다 아래방향으로 움직이게 적용
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < deadHeight)
        {
            Destroy(gameObject);
        }
        
    }
}
