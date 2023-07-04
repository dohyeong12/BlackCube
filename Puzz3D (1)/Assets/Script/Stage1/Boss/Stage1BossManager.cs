using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage1BossManager : ObjectCheck
{
    [SerializeField] bool attackCheck = false; // false : 공격 안하는 상태 
    [SerializeField] int attackDeley;
    bool targetting = false;

    public int HP = 4;

    void Start()
    {
        mapmanager = FindObjectOfType<Mapmanager>();
        objPos = this.gameObject.transform.position;

        current_x = 0;
        current_z = 0;
        current_y = 0;

        HP = 4;
    }

    void Update()
    {
        objPos = this.gameObject.transform.position;

        PositionSetting();

        if (mapmanager.battleStart == true && attackCheck == false && HP > 0)
        {
            attackDeley = Random.Range(0, 4);
            StartCoroutine(Jump());
        }

        else if(HP <= 0)
        {
            StartCoroutine(DestroyMonster());
        }
    }

    void PositionSetting()
    {
        if (objPos.y >= 0)
        {
            current_x = (int)objPos.x + 5;
            current_z = (int)objPos.z + 5;
            current_y = (int)objPos.y;
        }

        // 
        if (((int)objPos.x + 5 != current_x || (int)objPos.z + 5 != current_z || (int)objPos.y != current_y) && objPos.y >= 0)
        {
            for (int i = -1; i < 2; i++) 
            {
                for (int j = -1; j < 2; j++) 
                {
                    mapmanager.map[current_x + j, current_z + i, current_y, 0] = 0;
                    Debug.Log(mapmanager.map[current_x + j, current_z + i, current_y, 0] + ": (" + current_x+j +", " + current_z+i +") ");
                }
            }



            current_x = (int)objPos.x + 5;
            current_z = (int)objPos.z + 5;
            current_y = (int)objPos.y;

            if (mapmanager.map[current_x, current_z, current_y, 0] == 0)
            { 
                InputMap();
            }

        }

    }
    IEnumerator Jump()
    {
        targetting = false; // 공격할 상대(플레이어)를 정하지 못함
        attackCheck = true; // 현재 공격 중인 상태이다.

        transform.position += new Vector3(0, 4, 0); // 대충 점프
        yield return new WaitForSeconds(0.15f);
        if (targetting == false)
            transform.position = new Vector3(mapmanager.Pos.x, 4, mapmanager.Pos.z); // 플레이어의 머리위로 이동
        targetting = true;
        yield return new WaitForSeconds(0.75f);
        transform.position = new Vector3(objPos.x, 0, objPos.z); // 박치기

        if (attackDeley == 0)
        {
            yield return new WaitForSeconds(0.5f);
            attackCheck = false;
        }
        else if (attackDeley > 0)
        {
            yield return new WaitForSeconds(attackDeley);
            attackCheck = false;
        }
    }

    IEnumerator DestroyMonster()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        mapmanager.stageClear = true;
    }
}
