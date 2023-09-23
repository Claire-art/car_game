using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerItem : MonoBehaviour
{

    // ������ ������ 
    public GameObject ItemReverse;
    public GameObject ItemOil;
    public GameObject ItemBullet;
    public GameObject ItemHealth;
    public GameObject ItemFrozen;
    public GameObject ItemGod;


    // ������ ���� ����
    private float nextTime = 0.0f;
    public float spawnRate = 1.0f;
    public Road road;

    void Start()
    {
        // Road ��������
        road = GameObject.Find("Road").GetComponent<Road>();
    }

    void Update()
    {
        if (nextTime < Time.time)
        {
            // �����ϰ� ���ڸ� ���� �� �����ϰ� �������� ����
            int i = Random.Range(1, 7);

            if (i == 1) {
                SpawnOil();
            }

            if (i == 2) {
                SpawnReverse();
            }

            if (i == 3) {
                SpawnBullet();
            }

            if (i == 4) {
                SpawnHealth();
            }

            if (i == 5) {
                SpawnFrozen();
            }

            if (i == 6) {
                SpawnGod();
            }

            nextTime = Time.time + spawnRate;
        }



    }


    // ������ �Լ���� �ش� �̸��� ������Ʈ�� ���� �ʺ� ���� ������ �����ϰ� ����
    void SpawnReverse() {
        float addXPos = Random.Range(-road.roadWidth, road.roadWidth);
        Vector3 spawnPos = transform.position + new Vector3(addXPos, 0, 0);
        Instantiate(ItemReverse, spawnPos, Quaternion.Euler(0, 180, 0));
    }

    void SpawnOil()
    {
        float addXPos = Random.Range(-road.roadWidth, road.roadWidth);
        Vector3 spawnPos = transform.position + new Vector3(addXPos, 0, 0);
        Instantiate(ItemOil, spawnPos, Quaternion.Euler(0, 180, 0));
    }

    void SpawnBullet()
    {
        float addXPos = Random.Range(-road.roadWidth, road.roadWidth);
        Vector3 spawnPos = transform.position + new Vector3(addXPos, 0, 0);
        Instantiate(ItemBullet, spawnPos, Quaternion.Euler(0, 180, 0));
    }

    void SpawnHealth()
    {
        float addXPos = Random.Range(-road.roadWidth, road.roadWidth);
        Vector3 spawnPos = transform.position + new Vector3(addXPos, 0, 0);
        Instantiate(ItemHealth, spawnPos, Quaternion.Euler(0, 180, 0));
    }

    // ������ �Լ���� �ش� �̸��� ������Ʈ�� ���� �ʺ� ���� ������ �����ϰ� ����
    //Custom �����۵� �߰� �κ�
    void SpawnFrozen() {
        float addXPos = Random.Range(-road.roadWidth, road.roadWidth);
        Vector3 spawnPos = transform.position + new Vector3(addXPos, 0, 0);
        Instantiate(ItemFrozen, spawnPos, Quaternion.Euler(0, 180, 0));
    }

    void SpawnGod()
    {
        float addXPos = Random.Range(-road.roadWidth, road.roadWidth);
        Vector3 spawnPos = transform.position + new Vector3(addXPos, 0, 0);
        Instantiate(ItemGod, spawnPos, Quaternion.Euler(0, 180, 0));
    }

}
