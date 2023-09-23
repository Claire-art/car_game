using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    float speed = 10.0f;

    // static으로 health를 선언하여 Scene간의 활용도 높이기
    public static float health;

    // Reverse 아이템 관련 변수: 상하좌우 변경
    public bool bItemReverse = false ;
    public float timeItemReverse;
    private float timeItemReverseStart;

    // Bullet 아이템 관련 변수: Bullet 발사
    public bool bItemBullet = false;
    private float timeItemBullet;
    private float timeItemBulletStart;

    // Oil 아이템 관련 변수: 이동속도 증가
    public bool bItemOil = false;
    private float timeItemOil;
    private float timeItemOilStart;

    // Health 아이템 관련 변수: 체력증가
    public bool bItemHealth = false;
    private float timeItemHealth;
    private float timeItemHealthStart;

    // Frozen 아이템 관련 변수: 움직임이 얼도록 제어
    public bool bItemFrozen = false;
    private float timeItemFrozen;
    private float timeItemFrozenStart;

    // God 아이템 관련 변수: 무적상태(공중으로 띄우기)
    public bool bItemGod = false;
    private float timeItemGod;
    private float timeItemGodStart;


    public GameObject PrefabBarrel;



    public Road road;


    // Start is called before the first frame update
    void Start()
    {
        road = GameObject.Find("Road").GetComponent<Road>();

        health = 1.0f;

        bItemReverse = false;
        timeItemReverse = 5.0f;

        bItemBullet = false;
        timeItemBullet = 5.0f;

        bItemOil = false;
        timeItemOil = 5.0f;

        bItemHealth = false;
        timeItemHealth = 5.0f;

        // 2.0f 동안 효과 지속
        bItemFrozen = false;
        timeItemFrozen = 2.0f;

        // 3.0f 동안 효과 지속
        bItemGod = false;
        timeItemGod = 3.0f;

    }

    // Update is called once per frame
    void Update()
    {
        float dir1 = Input.GetAxis("Horizontal");

        if (bItemReverse)
            dir1 *= -1;
        if (bItemOil)
            dir1 *= 3;

        // dir1에 0을 곱함으로써 움직임 제어
        if (bItemFrozen)
            dir1 *= 0;

        transform.Translate(Vector3.right * dir1 * speed * Time.deltaTime);

        float dir2 = Input.GetAxis("Vertical");

        if (bItemReverse)
            dir2 *= -1;
        if (bItemOil)
            dir2 *= 3;

        // dir2에 0을 곱함으로써 움직임 제어
        if (bItemFrozen)
            dir2 *= 0;

        transform.Translate(Vector3.up * dir2 * speed * Time.deltaTime);

        if (bItemReverse) {
            if (Time.time - timeItemReverseStart > timeItemReverse) {
                bItemReverse = false;
            }
        }

        if (bItemOil) {
            if (Time.time - timeItemOilStart > timeItemOil) {
                bItemOil = false;
            }
        }

        if (bItemBullet) {

            if (Time.time - timeItemBulletStart > timeItemBullet) {
                bItemBullet = false;
            }

            if (Input.GetKeyDown("space")) {
                Vector3 newPos = new Vector3(transform.position.x, transform.position.y + 1.8f, transform.position.z);
                Instantiate(PrefabBarrel, newPos, Quaternion.identity);
            }
        }

        if (bItemHealth) {
            if (Time.time - timeItemHealthStart > timeItemHealth) {
                bItemHealth = false;
            }
        }

        // ↓↓↓↓↓↓↓ Custom 효과 세부 사항 부분 ↓↓↓↓↓↓↓

        if (bItemFrozen) {
            if (Time.time - timeItemFrozenStart > timeItemFrozen) {
                bItemFrozen = false;
            }
        }

        if (bItemGod) {

            if (Time.time - timeItemGodStart > timeItemGod) {
                bItemGod = false;

                // new Position을 설정하여 God 아이템을 먹은 후 효과 지속이 끝나면 다시 z축으로 +3만큼 이동하여 돌아오기
                Vector3 newPosition1 = transform.position;
                newPosition1.z += 3;

                transform.position = newPosition1;
            }
        }

        // ↑↑↑↑↑↑↑ Custom 효과 세부 사항 부분 ↑↑↑↑↑↑↑




        if (transform.position.x < -road.roadWidth)
        {
            transform.position = new Vector3(-road.roadWidth, transform.position.y, transform.position.z);
        }

        if (transform.position.x > road.roadWidth)
        {
            transform.position = new Vector3(road.roadWidth, transform.position.y, transform.position.z);
        }

        if (transform.position.y > road.roadHeight)
        {
            transform.position = new Vector3(transform.position.x, road.roadHeight, transform.position.z);
        }

        if (transform.position.y < 0)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Enemy") {
            GetComponent<AudioSource>().Play();
        }

        if (other.tag == "Item_Reverse") {
            Destroy(other.gameObject);
            bItemReverse = true;
            timeItemReverseStart = Time.time;
        }

        if (other.tag == "Item_Oil")
        {
            Destroy(other.gameObject);
            bItemOil = true;
            timeItemOilStart = Time.time;
        }

        if (other.tag == "Item_Bullet")
        {
            Destroy(other.gameObject);
            bItemBullet = true;
            timeItemBulletStart = Time.time;
        }

        if (other.tag == "Item_Health")
        {
            Destroy(other.gameObject);
            bItemHealth = true;
            timeItemHealthStart = Time.time;

            health += 0.1f;
            health = Mathf.Clamp(health, 0.1f, 1.0f);
        }

        // ↓↓↓↓↓↓↓ Custom 효과 세부 사항 부분 ↓↓↓↓↓↓↓

        if (other.tag == "Item_Frozen") {
            Destroy(other.gameObject);
            bItemFrozen = true;
            timeItemFrozenStart = Time.time;
        }

        if (other.tag == "Item_God") {
            Destroy(other.gameObject);
            bItemGod = true;

            // God 아이템 상태가 true가 되면 z축으로 -3만큼 이동하여 어떠한 충돌도 일어나지 않는 무적 상황 만들기
            Vector3 newPosition = transform.position;
            newPosition.z -= 3;

            transform.position = newPosition;
            timeItemGodStart = Time.time;
        }

        // ↑↑↑↑↑↑↑ Custom 효과 세부 사항 부분 ↑↑↑↑↑↑↑

    }
}
