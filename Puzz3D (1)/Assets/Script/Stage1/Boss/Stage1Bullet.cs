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
        // �÷��̾ ���� ������ ���� �ʰ� �÷��̾�� ��ġ�� ���� �� : �Ѿ��� ���� ���·� �ٲٰ� �����.
        if (mapmanager.haveBullet == false && mapmanager.player_x == current_x && mapmanager.player_z == current_z && mapmanager.player_y == current_y)
        {
            mapmanager.map[current_x, current_z, current_y, 0] = 0;
            mapmanager.haveBullet = true;
            Destroy(gameObject);
        }
    }
}
