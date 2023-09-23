using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{

    // ���ο� ���õ� ������
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
        // �� �����Ӹ��� y�� ��ġ���� speed ��ŭ ����
        y += Time.deltaTime * speed;

        // �ؽ��İ� �Ʒ��������� �����̰� �����
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, -y);

    }
}
