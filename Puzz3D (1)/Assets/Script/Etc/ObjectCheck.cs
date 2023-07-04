using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectCheck : MonoBehaviour
{
    public Mapmanager mapmanager;

    public Vector3 objPos;

    public int current_x;
    public int current_z;
    public int current_y;
    public float objType;

    [Header("Stage1")]
    public bool keymove = false;

    void Start()
    {
        mapmanager = FindObjectOfType<Mapmanager>();

        objPos = this.gameObject.transform.position;

        if (objPos.y >= 0)
        {
            current_x = (int)objPos.x + 5;
            current_z = (int)objPos.z + 5;
            current_y = 0;
        }


        InputMap();

    }

    void Update()
    {
        objPos = this.gameObject.transform.position;

        PositionSet();
        if (SceneManager.GetActiveScene().name == "Stage_1") Stage1();

        
    }

    void Stage1()
    {
        if (mapmanager.puzzClear == true)
        {
            if (gameObject.CompareTag("Wall"))
            {
                transform.position += new Vector3(0, -10 * Time.deltaTime, 0);
                mapmanager.map[current_x, current_z, current_y, 0] = 0;
                if (objPos.y < -2)
                    Destroy(gameObject);
            }
        }

        // key, Destory
        /*if (mapmanager.player_x == current_x && mapmanager.player_z == current_z && mapmanager.player_y == current_y)
        {
            if (objType == 5 && mapmanager.haveBullet == false)
            {
                mapmanager.map[current_x, current_z, current_y, 0] = 0;
                mapmanager.haveBullet = true;
                Destroy(gameObject);
            }
        } */


    }

    public void InputMap()
    {
        if ((gameObject.CompareTag("Rock") || gameObject.CompareTag("Wall")))
        {
            mapmanager.map[current_x, current_z, current_y, 0] = 1;
            objType = mapmanager.map[current_x, current_z, current_y, 0];
            //Debug.Log(current_x + ", " + current_z + ", " + 0 + ": '" + objType + "' ");
        }
        if (gameObject.CompareTag("Key"))
        {
            mapmanager.map[current_x, current_z, current_y, 0] = 2;
            objType = mapmanager.map[current_x, current_z, current_y, 0];
            //Debug.Log(current_x + ", " + current_z + ", " + 0 + ": '" + objType + "' ");
        }
        if (gameObject.CompareTag("Monster"))
        {
            mapmanager.map[current_x, current_z, current_y, 0] = 3;
            objType = mapmanager.map[current_x, current_z, current_y, 0];
            //Debug.Log(current_x + ", " + current_z + ", " + 0 + ": '" + objType + "' ");
        }
        if (gameObject.CompareTag("AttackRange"))
        {
            mapmanager.map[current_x, current_z, 0, 0] = 4;
            objType = mapmanager.map[current_x, current_z, 0, 0];
            //Debug.Log(current_x + ", " + current_z + ", " + 0 + ": '" + objType + "' ");
        }
        if (gameObject.CompareTag("Bullet"))
        {
            if (mapmanager.player_x == current_x && mapmanager.player_z == current_z)
            {
                mapmanager.map[current_x, current_z, 0, 0] = 6;
                objType = mapmanager.map[current_x, current_z, 0, 0];
                //Debug.Log(current_x + ", " + current_z + ", " + 0 + ": '" + objType + "' ");
            }
            else
            {
                mapmanager.map[current_x, current_z, 0, 0] = 5;
                objType = mapmanager.map[current_x, current_z, 0, 0];
                //Debug.Log(current_x + ", " + current_z + ", " + 0 + ": '" + objType + "' ");
            }

        }

    }

    public void PositionSet()
    {
        // ������ǥ(current_x / y / z)�� ���� ��ǥ�� �ٸ� ��  ����ȴ�. : 
        if ((int)objPos.x + 5 != current_x || (int)objPos.z + 5 != current_z || (int)objPos.y != current_y)
        {
            if (mapmanager.map[current_x, current_z, 0, 0] == objType)
                mapmanager.map[current_x, current_z, 0, 0] = 0; // �ش� ������Ʈ�� �̵� ���� �ִ� ��ǥ�� ���� 0���� �ʱ�ȭ

            // current ��ǥ�� ���ο� ������ �ʱ�ȭ�Ѵ�.
            current_x = (int)objPos.x + 5;
            current_z = (int)objPos.z + 5;
            current_y = (int)objPos.y;

            if (mapmanager.map[current_x, current_z, 0, 0] == 0) // current ��ǥ�� �ƹ��͵� ���ٸ� �� ��ǥ�� �ڽ��� �����Ѵ�.
            {
                InputMap();
            }

        }
    }
}
