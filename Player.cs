using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    float speed = 10.0f;

    // static���� health�� �����Ͽ� Scene���� Ȱ�뵵 ���̱�
    public static float health;

    // Reverse ������ ���� ����: �����¿� ����
    public bool bItemReverse = false ;
    public float timeItemReverse;
    private float timeItemReverseStart;

    // Bullet ������ ���� ����: Bullet �߻�
    public bool bItemBullet = false;
    private float timeItemBullet;
    private float timeItemBulletStart;

    // Oil ������ ���� ����: �̵��ӵ� ����
    public bool bItemOil = false;
    private float timeItemOil;
    private float timeItemOilStart;

    // Health ������ ���� ����: ü������
    public bool bItemHealth = false;
    private float timeItemHealth;
    private float timeItemHealthStart;

    // Frozen ������ ���� ����: �������� �󵵷� ����
    public bool bItemFrozen = false;
    private float timeItemFrozen;
    private float timeItemFrozenStart;

    // God ������ ���� ����: ��������(�������� ����)
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

        // 2.0f ���� ȿ�� ����
        bItemFrozen = false;
        timeItemFrozen = 2.0f;

        // 3.0f ���� ȿ�� ����
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

        // dir1�� 0�� �������ν� ������ ����
        if (bItemFrozen)
            dir1 *= 0;

        transform.Translate(Vector3.right * dir1 * speed * Time.deltaTime);

        float dir2 = Input.GetAxis("Vertical");

        if (bItemReverse)
            dir2 *= -1;
        if (bItemOil)
            dir2 *= 3;

        // dir2�� 0�� �������ν� ������ ����
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

        // �������� Custom ȿ�� ���� ���� �κ� ��������

        if (bItemFrozen) {
            if (Time.time - timeItemFrozenStart > timeItemFrozen) {
                bItemFrozen = false;
            }
        }

        if (bItemGod) {

            if (Time.time - timeItemGodStart > timeItemGod) {
                bItemGod = false;

                // new Position�� �����Ͽ� God �������� ���� �� ȿ�� ������ ������ �ٽ� z������ +3��ŭ �̵��Ͽ� ���ƿ���
                Vector3 newPosition1 = transform.position;
                newPosition1.z += 3;

                transform.position = newPosition1;
            }
        }

        // �������� Custom ȿ�� ���� ���� �κ� ��������




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

        // �������� Custom ȿ�� ���� ���� �κ� ��������

        if (other.tag == "Item_Frozen") {
            Destroy(other.gameObject);
            bItemFrozen = true;
            timeItemFrozenStart = Time.time;
        }

        if (other.tag == "Item_God") {
            Destroy(other.gameObject);
            bItemGod = true;

            // God ������ ���°� true�� �Ǹ� z������ -3��ŭ �̵��Ͽ� ��� �浹�� �Ͼ�� �ʴ� ���� ��Ȳ �����
            Vector3 newPosition = transform.position;
            newPosition.z -= 3;

            transform.position = newPosition;
            timeItemGodStart = Time.time;
        }

        // �������� Custom ȿ�� ���� ���� �κ� ��������

    }
}
