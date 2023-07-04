using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// 만약 블록이 1번 지역에 소환되었지만 사라지지 않을 때 실행됨



public class Delete : MonoBehaviour
{
    Mapmanager b;
    S2BattleScript c;
    Vector3 Pos;

    float a;
    void Start()
    {
        b = FindObjectOfType<Mapmanager>();
        c = FindObjectOfType<S2BattleScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Pos = this.gameObject.transform.position;

        if (gameObject.CompareTag("Wall"))
        {
            if (c.clearPuzzNum == 2 && c.clearArea[8] == 4)
            {
                Destroy(this.gameObject);
                b.map[19, 8, 0, 0] = 0;
                b.map[20, 8, 0, 0] = 0;
                b.map[21, 8, 0, 0] = 0;
            }
            if (c.clearPuzzNum == 1 && c.clearArea[8] == 6)
            {
                Destroy(this.gameObject);
                b.map[19, 8, 0, 0] = 0;
                b.map[20, 8, 0, 0] = 0;
                b.map[21, 8, 0, 0] = 0;
            }
            if (c.clearPuzzNum == 0 && c.clearArea[8] == 8)
            {
                Destroy(this.gameObject);
                b.map[19, 8, 0, 0] = 0;
                b.map[20, 8, 0, 0] = 0;
                b.map[21, 8, 0, 0] = 0;
            }
        }

        else
        {
            if (Pos.x >= 12 && Pos.x <= 16 && Pos.z >= 9 && Pos.z <= 13)
            {
                a += Time.deltaTime;
            }

            if (a >= 3.1f)
            {
                b.map[(int)Pos.x, (int)Pos.z, 0, 1] = 1;
                Destroy(gameObject);
            }
        }
    }
}
