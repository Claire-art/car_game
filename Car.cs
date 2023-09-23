using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Car : MonoBehaviour
{
    // ������ ���õ� ���� ���� 
    public float speed = 5.0f;
    public float deadHeight = -5.0f;

    // ����ȿ��
    public GameObject Explosion;

    // GUI ����
    public Text guiMeter;
    public static int meter;

    // Player ��ü�� ���� �κ�
    public Player player;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            // �÷��̾�� �浹 �� ����ȿ�� ����
            Instantiate(Explosion, transform.position, transform.rotation);
            Destroy(gameObject);

            Player.health -= 0.1f;

            // ���� ���߰������� Player�� ü���� ���������� Ȯ��
            Debug.Log(Player.health);

            // Player�� ü���� 0 �̸��� �� Restart Scene�� ��ȯ
            if (Player.health < 0)
            {
                SceneManager.LoadScene("Restart");
            }

        }


    }

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < deadHeight)
        {
            Destroy(gameObject);
        }
    }
}
