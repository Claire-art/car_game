using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCar : MonoBehaviour
{

    // 각각의 적(차량)에 대한 부분
    public GameObject PrefabCar1;
    public GameObject spaceShip;
    public GameObject FBX;

    // 스폰 관련 부분
    private float nextTime = 0.0f;
    public float spawnRate = 1.0f;



    public Road road;

    void Start()
    {
        road = GameObject.Find("Road").GetComponent<Road>();
    }

    void Update()
    {
        if (nextTime < Time.time)
        {

            // 랜덤하게 숫자를 생성 → 랜덤하게 차량 생성
            // 동시에 생성 시 높은 혼잡도 → 랜덤하게 리스폰되도록하여 해결  
            int i = Random.Range(1, 4);

            if (i == 1)
            {
                SpawnCar1();
            }

            if (i == 2)
            {
                SpawnspaceShip();
            }

            if (i == 3)
            {
                SpawnFBX();
            }


            nextTime = Time.time + spawnRate;
        }




    }

    // 해당 이름의 오브젝트가 도로의 너비 범위에서 스폰 되도록 조정
    void SpawnCar1()
    {
        float addPos = Random.Range(-road.roadWidth, road.roadWidth);
        Vector3 spwanPos = transform.position + new Vector3(addPos, 0, 0);
        Instantiate(PrefabCar1, spwanPos, Quaternion.identity);
    }

    void SpawnspaceShip() {
        float addPos = Random.Range(-road.roadWidth, road.roadWidth);
        Vector3 spwanPos = transform.position + new Vector3(addPos, 0, 0);
        Instantiate(spaceShip, spwanPos, Quaternion.identity);
    }

    void SpawnFBX()
    {
        float addPos = Random.Range(-road.roadWidth, road.roadWidth);
        Vector3 spwanPos = transform.position + new Vector3(addPos, 0, 0);
        Instantiate(FBX, spwanPos, Quaternion.identity);
    }
}
