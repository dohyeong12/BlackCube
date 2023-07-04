using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Bullet : ObjectCheck
{

    void Start()
    {
        mapmanager = FindObjectOfType<Mapmanager>();
        objPos = this.gameObject.transform.position;

        if (objPos.y >= 0)
        {
            current_x = (int)objPos.x + 5;
            current_z = (int)objPos.z + 5;
            current_y = (int)objPos.y;
        }

        if (objPos.y >= 0)
        {
            InputMap();
        }

    }


    void Update()
    {
        objPos = this.gameObject.transform.position;
        PositionSet();
        BulletDes();
    }

    void BulletDes()
    {
        // 플레이어가 총을 가지고 있지 않고 플레이어와 위치가 같을 때 : 총알을 가진 상태로 바꾸고 지운다.
        if (mapmanager.haveBullet == false && mapmanager.player_x == current_x && mapmanager.player_z == current_z && mapmanager.player_y == current_y)
        {
            mapmanager.map[current_x, current_z, current_y, 0] = 0;
            mapmanager.haveBullet = true;
            Destroy(gameObject);
        }
    }
}
