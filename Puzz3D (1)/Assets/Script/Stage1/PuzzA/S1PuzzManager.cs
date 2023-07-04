using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S1PuzzManager : MonoBehaviour
{
    Mapmanager mapmanager;


    [Header("퍼즐 종류")]
    bool puzzA = true;

    [Header("퍼즐A 변수")]
    public int inputCnt_A = 0; // 플레이어가 누른 발판의 갯수
    public int targetCnt_A = 16; // 목표량
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
                Debug.Log("퍼즐A를 시작합니다. " + inputCnt_A + 1 + "번째 발판을 밟았습니다.");
                inputCnt_A++;
            }

            if (inputCnt_A != 16)
                targetCnt_A = inputCnt_A + 1;*/



            if (inputCnt_A == 0 && mapmanager.player_x == 26 && mapmanager.player_z == 6 && mapmanager.player_y == 0)
            {
                Debug.Log("퍼즐A를 시작합니다. " + inputCnt_A + 1 + "번째 발판을 밟았습니다.");
                inputCnt_A++;
            }
            if (inputCnt_A == 1 && mapmanager.player_x == 25 && mapmanager.player_z == 6 && mapmanager.player_y == 0)
            {
                Debug.Log(inputCnt_A + 1 + "번째 발판을 밟았습니다.");
                inputCnt_A++;
            }
            if (inputCnt_A == 2 && mapmanager.player_x == 23 && mapmanager.player_z == 8 && mapmanager.player_y == 0)
            {
                Debug.Log(inputCnt_A + 1 + "번째 발판을 밟았습니다.");
                inputCnt_A++;
            } // 3
            if (inputCnt_A == 3 && mapmanager.player_x == 23 && mapmanager.player_z == 9 && mapmanager.player_y == 0)
            {
                Debug.Log(inputCnt_A + 1 + "번째 발판을 밟았습니다.");
                inputCnt_A++;
            } // 4
            if (inputCnt_A == 4 && mapmanager.player_x == 23 && mapmanager.player_z == 11 && mapmanager.player_y == 0)
            {
                Debug.Log(inputCnt_A + 1 + "번째 발판을 밟았습니다.");
                inputCnt_A++;
            } // 5
            if (inputCnt_A == 5 && mapmanager.player_x == 23 && mapmanager.player_z == 12 && mapmanager.player_y == 0)
            {
                Debug.Log(inputCnt_A + 1 + "번째 발판을 밟았습니다.");
                inputCnt_A++;
            } // 6
            if (inputCnt_A == 6 && mapmanager.player_x == 25 && mapmanager.player_z == 14 && mapmanager.player_y == 0)
            {
                Debug.Log(inputCnt_A + 1 + "번째 발판을 밟았습니다.");
                inputCnt_A++;
            } // 7
            if (inputCnt_A == 7 && mapmanager.player_x == 26 && mapmanager.player_z == 14 && mapmanager.player_y == 0)
            {
                Debug.Log(inputCnt_A + 1 + "번째 발판을 밟았습니다.");
                inputCnt_A++;
            } // 8
            if (inputCnt_A == 8 && mapmanager.player_x == 28 && mapmanager.player_z == 14 && mapmanager.player_y == 0)
            {
                Debug.Log(inputCnt_A + 1 + "번째 발판을 밟았습니다.");
                inputCnt_A++;
            } // 9
            if (inputCnt_A == 9 && mapmanager.player_x == 29 && mapmanager.player_z == 14 && mapmanager.player_y == 0)
            {
                Debug.Log(inputCnt_A + 1 + "번째 발판을 밟았습니다.");
                inputCnt_A++;
            } // 10
            if (inputCnt_A == 10 && mapmanager.player_x == 31 && mapmanager.player_z == 12 && mapmanager.player_y == 0)
            {
                Debug.Log(inputCnt_A + 1 + "번째 발판을 밟았습니다.");
                inputCnt_A++;
            }// 11
            if (inputCnt_A == 11 && mapmanager.player_x == 31 && mapmanager.player_z == 11 && mapmanager.player_y == 0)
            {
                Debug.Log(inputCnt_A + 1 + "번째 발판을 밟았습니다.");
                inputCnt_A++;
            }// 12
            if (inputCnt_A == 12 && mapmanager.player_x == 31 && mapmanager.player_z == 9 && mapmanager.player_y == 0)
            {
                Debug.Log(inputCnt_A + 1 + "번째 발판을 밟았습니다.");
                inputCnt_A++;
            }// 13 
            if (inputCnt_A == 13 && mapmanager.player_x == 31 && mapmanager.player_z == 8 && mapmanager.player_y == 0)
            {
                Debug.Log(inputCnt_A + 1 + "번째 발판을 밟았습니다.");
                inputCnt_A++;
            }// 14
            if (inputCnt_A == 14 && mapmanager.player_x == 29 && mapmanager.player_z == 6 && mapmanager.player_y == 0)
            {
                Debug.Log(inputCnt_A + 1 + "번째 발판을 밟았습니다.");
                inputCnt_A++;
            }// 15
            if (inputCnt_A == 15 && mapmanager.player_x == 28 && mapmanager.player_z == 6 && mapmanager.player_y == 0)
            {
                Debug.Log(inputCnt_A + 1 + "번째 발판을 밟았습니다.\n모든 발판을 밟음");
                inputCnt_A = 16;

            }// 16
            
        }
    }
}
