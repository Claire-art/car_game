using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCar : MonoBehaviour
{

    // ������ ��(����)�� ���� �κ�
    public GameObject PrefabCar1;
    public GameObject spaceShip;
    public GameObject FBX;

    // ���� ���� �κ�
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

            // �����ϰ� ���ڸ� ���� �� �����ϰ� ���� ����
            // ���ÿ� ���� �� ���� ȥ�⵵ �� �����ϰ� �������ǵ����Ͽ� �ذ�  
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

    // �ش� �̸��� ������Ʈ�� ������ �ʺ� �������� ���� �ǵ��� ����
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
