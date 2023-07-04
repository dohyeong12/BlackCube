using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S1PuzzManager : MonoBehaviour
{
    Mapmanager mapmanager;


    [Header("���� ����")]
    bool puzzA = true;

    [Header("����A ����")]
    public int inputCnt_A = 0; // �÷��̾ ���� ������ ����
    public int targetCnt_A = 16; // ��ǥ��
    [SerializeField] bool clear_PuzzA = false;



    void Start()
    {
        mapmanager = FindObjectOfType<Mapmanager>();
    }


    void Update()
    {
        if (puzzA == true) PuzzA_Script();
    }

    void PuzzA_Script()
    {
        if (clear_PuzzA == false)
        {
            /*if (inputCnt_A == targetCnt_A && mapmanager.player_x == target_x && mapmanager.player_y == target_y)
            {
                Debug.Log("����A�� �����մϴ�. " + inputCnt_A + 1 + "��° ������ ��ҽ��ϴ�.");
                inputCnt_A++;
            }

            if (inputCnt_A != 16)
                targetCnt_A = inputCnt_A + 1;*/



            if (inputCnt_A == 0 && mapmanager.player_x == 26 && mapmanager.player_z == 6 && mapmanager.player_y == 0)
            {
                Debug.Log("����A�� �����մϴ�. " + inputCnt_A + 1 + "��° ������ ��ҽ��ϴ�.");
                inputCnt_A++;
            }
            if (inputCnt_A == 1 && mapmanager.player_x == 25 && mapmanager.player_z == 6 && mapmanager.player_y == 0)
            {
                Debug.Log(inputCnt_A + 1 + "��° ������ ��ҽ��ϴ�.");
                inputCnt_A++;
            }
            if (inputCnt_A == 2 && mapmanager.player_x == 23 && mapmanager.player_z == 8 && mapmanager.player_y == 0)
            {
                Debug.Log(inputCnt_A + 1 + "��° ������ ��ҽ��ϴ�.");
                inputCnt_A++;
            } // 3
            if (inputCnt_A == 3 && mapmanager.player_x == 23 && mapmanager.player_z == 9 && mapmanager.player_y == 0)
            {
                Debug.Log(inputCnt_A + 1 + "��° ������ ��ҽ��ϴ�.");
                inputCnt_A++;
            } // 4
            if (inputCnt_A == 4 && mapmanager.player_x == 23 && mapmanager.player_z == 11 && mapmanager.player_y == 0)
            {
                Debug.Log(inputCnt_A + 1 + "��° ������ ��ҽ��ϴ�.");
                inputCnt_A++;
            } // 5
            if (inputCnt_A == 5 && mapmanager.player_x == 23 && mapmanager.player_z == 12 && mapmanager.player_y == 0)
            {
                Debug.Log(inputCnt_A + 1 + "��° ������ ��ҽ��ϴ�.");
                inputCnt_A++;
            } // 6
            if (inputCnt_A == 6 && mapmanager.player_x == 25 && mapmanager.player_z == 14 && mapmanager.player_y == 0)
            {
                Debug.Log(inputCnt_A + 1 + "��° ������ ��ҽ��ϴ�.");
                inputCnt_A++;
            } // 7
            if (inputCnt_A == 7 && mapmanager.player_x == 26 && mapmanager.player_z == 14 && mapmanager.player_y == 0)
            {
                Debug.Log(inputCnt_A + 1 + "��° ������ ��ҽ��ϴ�.");
                inputCnt_A++;
            } // 8
            if (inputCnt_A == 8 && mapmanager.player_x == 28 && mapmanager.player_z == 14 && mapmanager.player_y == 0)
            {
                Debug.Log(inputCnt_A + 1 + "��° ������ ��ҽ��ϴ�.");
                inputCnt_A++;
            } // 9
            if (inputCnt_A == 9 && mapmanager.player_x == 29 && mapmanager.player_z == 14 && mapmanager.player_y == 0)
            {
                Debug.Log(inputCnt_A + 1 + "��° ������ ��ҽ��ϴ�.");
                inputCnt_A++;
            } // 10
            if (inputCnt_A == 10 && mapmanager.player_x == 31 && mapmanager.player_z == 12 && mapmanager.player_y == 0)
            {
                Debug.Log(inputCnt_A + 1 + "��° ������ ��ҽ��ϴ�.");
                inputCnt_A++;
            }// 11
            if (inputCnt_A == 11 && mapmanager.player_x == 31 && mapmanager.player_z == 11 && mapmanager.player_y == 0)
            {
                Debug.Log(inputCnt_A + 1 + "��° ������ ��ҽ��ϴ�.");
                inputCnt_A++;
            }// 12
            if (inputCnt_A == 12 && mapmanager.player_x == 31 && mapmanager.player_z == 9 && mapmanager.player_y == 0)
            {
                Debug.Log(inputCnt_A + 1 + "��° ������ ��ҽ��ϴ�.");
                inputCnt_A++;
            }// 13 
            if (inputCnt_A == 13 && mapmanager.player_x == 31 && mapmanager.player_z == 8 && mapmanager.player_y == 0)
            {
                Debug.Log(inputCnt_A + 1 + "��° ������ ��ҽ��ϴ�.");
                inputCnt_A++;
            }// 14
            if (inputCnt_A == 14 && mapmanager.player_x == 29 && mapmanager.player_z == 6 && mapmanager.player_y == 0)
            {
                Debug.Log(inputCnt_A + 1 + "��° ������ ��ҽ��ϴ�.");
                inputCnt_A++;
            }// 15
            if (inputCnt_A == 15 && mapmanager.player_x == 28 && mapmanager.player_z == 6 && mapmanager.player_y == 0)
            {
                Debug.Log(inputCnt_A + 1 + "��° ������ ��ҽ��ϴ�.\n��� ������ ����");
                inputCnt_A = 16;

            }// 16
            
        }
    }
}
