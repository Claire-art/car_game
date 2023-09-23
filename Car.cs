using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Car : MonoBehaviour
{
    // 차량과 관련된 변수 선언 
    public float speed = 5.0f;
    public float deadHeight = -5.0f;

    // 폭발효과
    public GameObject Explosion;

    // GUI 관련
    public Text guiMeter;
    public static int meter;

    // Player 객체에 대한 부분
    public Player player;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            // 플레이어와 충돌 시 폭발효과 생성
            Instantiate(Explosion, transform.position, transform.rotation);
            Destroy(gameObject);

            Player.health -= 0.1f;

            // 게임 개발과정에서 Player의 체력을 가시적으로 확인
            Debug.Log(Player.health);

            // Player의 체력이 0 미만일 시 Restart Scene로 전환
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
