using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerItem : MonoBehaviour
{

    // 각각의 아이템 
    public GameObject ItemReverse;
    public GameObject ItemOil;
    public GameObject ItemBullet;
    public GameObject ItemHealth;
    public GameObject ItemFrozen;
    public GameObject ItemGod;


    // 아이템 스폰 관련
    private float nextTime = 0.0f;
    public float spawnRate = 1.0f;
    public Road road;

    void Start()
    {
        // Road 가져오기
        road = GameObject.Find("Road").GetComponent<Road>();
    }

    void Update()
    {
        if (nextTime < Time.time)
        {
            // 랜덤하게 숫자를 생성 → 랜덤하게 아이템을 생성
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


    // 각각의 함수들로 해당 이름의 오브젝트를 도로 너비 범위 내에서 랜덤하게 생성
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

    // 각각의 함수들로 해당 이름의 오브젝트를 도로 너비 범위 내에서 랜덤하게 생성
    //Custom 아이템들 추가 부분
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
