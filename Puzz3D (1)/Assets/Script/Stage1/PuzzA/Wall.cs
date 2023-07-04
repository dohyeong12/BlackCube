using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wall : MonoBehaviour
{
    Mapmanager mapmanager;
    PuzzAScript pzA;


    Vector3 Pos;

    void Start()
    {
        mapmanager = FindObjectOfType<Mapmanager>();
        pzA = FindObjectOfType<PuzzAScript>();

    }

    // Update is called once per frame
    void Update()
    {
        Pos = this.gameObject.transform.position;

        if (SceneManager.GetActiveScene().name == "Stage_1") Stage1();


        if (pzA.puzzA[15] == 2 && mapmanager.player_x == 27 && mapmanager.player_z == 10)
        {
            for (int i = 5; i <= 15; i++)
            {
                mapmanager.map[21, i, 0, 0] = 0;
            }
            Destroy(gameObject);
        }

    }

    void Stage1()
    {
        //퍼즐이 시작된후 퍼즐이 클리어 되기전 : 벽을 소환함(움직임)
        if (mapmanager.puzzStart == true && mapmanager.puzzClear == false)
        {
            if (gameObject.name == "Wall_1")
                transform.position = new Vector3(16, 0, 0);

            if (gameObject.name == "Wall_2")
                transform.position = new Vector3(16, 1, 0);

            if (gameObject.name == "Wall_3")
                transform.position = new Vector3(16, 2, 0);

            if (gameObject.name == "Wall_4")
                transform.position = new Vector3(16, 3, 0);

            for (int i = 5; i <= 15; i++)
            {
                mapmanager.map[21, i, 0, 0] = 1;
            }
        }
    }
}
