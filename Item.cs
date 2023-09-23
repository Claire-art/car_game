using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // ������ ���� ����
    public float speed = 5.0f;
    private float deadHeight = -3.0f;

    public Road road;

    void Start()
    {

        // Road ��������
        road = GameObject.Find("Road").GetComponent<Road>();
        
        // Random�� offset �� ����
        float offset = Random.Range(0, 3.0f);

        // �̵� �ӵ��� ������ offset�� �����Ͽ� �پ��� �ӵ��� �����̰� ����
        speed = Random.Range(speed - offset, speed + offset);
    }

    void Update()
    {

        // �� �����Ӹ��� �Ʒ��������� �����̰� ����
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < deadHeight)
        {
            Destroy(gameObject);
        }
        
    }
}
