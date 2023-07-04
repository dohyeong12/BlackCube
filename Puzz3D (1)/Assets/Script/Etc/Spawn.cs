using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawn : MonoBehaviour
{
    Mapmanager mapmanager;
    PuzzAScript pzA;

    [Header("1스테이지")]
    public GameObject key_PuzzA;
    public GameObject Bullet_A;
    float bulletSpawnDeley = 4;
    float bullet1Spawntime = 0;
    float bullet2Spawntime = 0;
    float bullet3Spawntime = 0;
    float bullet4Spawntime = 0;

    void Start()
    {
        mapmanager = FindObjectOfType<Mapmanager>();
        pzA = FindObjectOfType<PuzzAScript>();
        bulletSpawnDeley = 4;
        bullet1Spawntime = 4;
        bullet2Spawntime = 4;
        bullet3Spawntime = 4;
        bullet4Spawntime = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Stage_1") Stage1();

    }

    void Stage1()
    {
        // 퍼즐이 클리어되면 열쇠를 소환
        if (pzA.puzzA[15] == 1)
        {
            Instantiate(key_PuzzA, new Vector3(22, 0, 5), Quaternion.identity);
            pzA.puzzA[15] = 2;
        }

        if (mapmanager.battleStart == true)
        {
            // 위치에 총알이 없으면 소환
            if (mapmanager.map[6, 6, 0, 0] != 5)
            {
                bullet1Spawntime += Time.deltaTime;

                if (bullet1Spawntime >= bulletSpawnDeley)
                {
                    Instantiate(Bullet_A, new Vector3(1, 0, 1), Quaternion.identity);
                    bullet1Spawntime = 0;
                }

            }
            if (mapmanager.map[6, 14, 0, 0] != 5)
            {
                bullet2Spawntime += Time.deltaTime;

                if (bullet2Spawntime >= bulletSpawnDeley)
                {
                    Instantiate(Bullet_A, new Vector3(1, 0, 9), Quaternion.identity);
                    bullet2Spawntime = 0;
                }
            }
            if (mapmanager.map[14, 14, 0, 0] != 5)
            {
                bullet3Spawntime += Time.deltaTime;

                if (bullet3Spawntime >= bulletSpawnDeley)
                {
                    Instantiate(Bullet_A, new Vector3(9, 0, 9), Quaternion.identity);
                    bullet3Spawntime = 0;
                }
            }
            if (mapmanager.map[14, 6, 0, 0] != 5)
            {
                bullet4Spawntime += Time.deltaTime;

                if (bullet4Spawntime >= bulletSpawnDeley)
                {
                    Instantiate(Bullet_A, new Vector3(9, 0, 1), Quaternion.identity);
                    bullet4Spawntime = 0;
                }
            }
        }
    }
}
