using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S2BattleScript : MonoBehaviour
{
    Mapmanager mapmanager;
    S2TetraMino mino;

    Transform[] myChildren;

    public bool battleStart;
    public int clearPuzzNum;

    public float[] locateArea;
    [SerializeField] int referenceValue;
    [SerializeField] int changeCnt;
    public GameObject Rock;

    [Header("Playerinfo")]
    [SerializeField] int playerHP = 5;
    bool attack = false;


    [Header("Attack")]
    public float attackDeley;
    public int attackArea;
    [SerializeField] int targetQuantity;
    public int delMinoCnt;
    public int goal;

    public int[] attackAreaCnt;
    public int[] installMinoCnt;
    public int[] clearArea;




    [Header("MinoPrefab")]
    public GameObject IMIno;
    public GameObject OMIno;
    public GameObject TMIno;
    public GameObject LMIno;
    public GameObject JMIno;
    public GameObject ZMIno;
    public GameObject SMIno;
    public GameObject MInoBlur;

    [Header("BagSystem")]
    public int[] bag;
    [SerializeField] int inputNum;
    [SerializeField] int overCnt;
    public int rotateInfo;
    public int currntNum;

    [Header("Timer")]
    bool timerStart;
    float currentTime;

    void Start()
    {
        mapmanager = FindObjectOfType<Mapmanager>();
        mino = FindObjectOfType<S2TetraMino>();

        myChildren = this.GetComponentsInChildren<Transform>();


        battleStart = false;
        clearPuzzNum = 0;

        locateArea = new float[4];
        clearArea = new int[9];

        bag = new int[14];
        FirstBagSetting();
        SecondBagSetting();
    }


    void Update()
    {
        if (mapmanager.Pos.x == 14 && mapmanager.Pos.z == 11 && battleStart == false && timerStart == false)
        {
            BattlePreparation();
        }

        if (battleStart == true && clearArea[8] <= goal)
        {
            foreach (Transform child in myChildren)
            {
                if (child.name == "Side1")
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(255 / 255f, 255 / 255f, 0 / 255f);
                }
            }
            MinoInstall();
            AreaAttack();
            ChangeAttackAreaColor();
            FixedInstall();
        }
        
        if (battleStart == true && clearArea[8] >= goal)
        {
            ClearBattle();
        }

        if (timerStart == true) currentTime += Time.deltaTime;      if (currentTime >= 3.5f) { battleStart = true; timerStart = false; }
    }

    void BattlePreparation()
    {
        timerStart = false;
        foreach (Transform child in myChildren)
        {
            if (child.name == "Side1")
            {
                child.gameObject.GetComponent<Renderer>().material.color = new Color(255 / 255f, 255 / 255f, 255 / 255f);
            }
        }

        // 입구 봉쇄죠?
        Instantiate(Rock, new Vector3(13, -0.5f, 19), Quaternion.identity);
        Instantiate(Rock, new Vector3(14, -0.5f, 19), Quaternion.identity);
        Instantiate(Rock, new Vector3(15, -0.5f, 19), Quaternion.identity);
        mapmanager.map[18, 24, 0, 0] = 1;
        mapmanager.map[19, 24, 0, 0] = 1;
        mapmanager.map[20, 24, 0, 0] = 1;


        // 퍼즐 못깨서 봉쇄죠?
        if (clearPuzzNum == 0)
        {
            goal = 8;
            attackDeley = 6;
            targetQuantity = 10;
            attackAreaCnt = new int[10];
            installMinoCnt = new int[10];
        }
        else if (clearPuzzNum == 1)
        {
            goal = 6;
            attackDeley = 8;
            targetQuantity = 8;
            attackAreaCnt = new int[8];
            installMinoCnt = new int[8];

            foreach (Transform child in myChildren)
            {
                if (child.name == "Side8_1" || child.name == "Side9_1")
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(0 / 255f, 0 / 255f, 0 / 255f);
                }
            }



            // 위, 이동 금지
            for (int i = 12; i <= 21; i++)
                mapmanager.map[i, 22, 0, 0] = 1;
            mapmanager.map[21, 23, 0, 0] = 1;

            // 위, 설치 금지
            for (int i = 7; i <= 16; i++)
            {
                mapmanager.map[i, 17, 0, 1] = 99;
                mapmanager.map[i, 18, 0, 1] = 99;
                Debug.Log(1);
            }


            //아래, 이동 금지
            for (int i = 17; i <= 26; i++)
                mapmanager.map[i, 10, 0, 0] = 1;
            mapmanager.map[17, 9, 0, 0] = 1;

            // 아래, 설치 금지
            for (int i = 12; i <= 21; i++)
            {
                mapmanager.map[i, 4, 0, 1] = 99;
                mapmanager.map[i, 5, 0, 1] = 99;
                Debug.Log(2);
            }
        }
        else if (clearPuzzNum == 2)
        {
            goal = 4;
            attackDeley = 12;
            targetQuantity = 6;
            attackAreaCnt = new int[6];
            installMinoCnt = new int[6];

            foreach (Transform child in myChildren)
            {
                if (child.name == "Side6_1" || child.name == "Side6_2" || child.name == "Side7_1" || child.name == "Side7_2" || child.name == "Side8_1" || child.name == "Side9_1")
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(0 / 255f, 0 / 255f, 0 / 255f);
                }
            }


            // 설치 금지 구역 / 이동 금지 구역
            
            //(가로방향) 
            for (int i = 7; i <= 21; i++) 
            {
                mapmanager.map[i, 18, 0, 1] = 99;
                mapmanager.map[i, 17, 0, 1] = 99;
                mapmanager.map[i, 5, 0, 1] = 99;
                mapmanager.map[i, 4, 0, 1] = 99;
            }
            for (int i = 14; i <= 24; i++)
            {
                mapmanager.map[i, 22, 0, 0] = 1;
                mapmanager.map[i, 10, 0, 0] = 1;
            }
            //(세로방향)
            for (int i = 4; i <= 18; i++) // 세로
            {
                mapmanager.map[7, i, 0, 1] = 99;
                mapmanager.map[8, i, 0, 1] = 99;
                mapmanager.map[20, i, 0, 1] = 99;
                mapmanager.map[21, i, 0, 1] = 99;
            }
            for (int i = 11; i <= 21; i++)
            {
                mapmanager.map[13, i, 0, 0] = 1;
                mapmanager.map[25, i, 0, 0] = 1;
            }

        }


        timerStart = true;
    }


    void AreaAttack()
    {
        currentTime += Time.deltaTime;

        // 공격 대상 지정
        if (currentTime >= attackDeley)
        {

            for (int i = 0; i < 5; i++)
            {
                attackArea = Random.RandomRange(2, targetQuantity);
                
                if (clearArea[8] >= goal)
                {
                    attackArea = 0;
                }
                else if (attackArea <= 5)
                {
                    if (clearArea[8] >= goal)
                        attackArea = 0;
                    else if (installMinoCnt[attackArea] >= 6)
                        i = 1;
                    else if (installMinoCnt[attackArea] != 6)
                        i = 10;
                }
                else if (attackArea <= 7)
                {
                    if (clearArea[8] >= goal)
                        attackArea = 0;
                    else if(installMinoCnt[attackArea] >= 8)
                        i = 1;
                    else if (installMinoCnt[attackArea] != 8)
                        i = 10;
                }
                else if (attackArea <= 9)
                {
                    if (clearArea[8] >= goal)
                        attackArea = 0;
                    else if (installMinoCnt[attackArea] >= 5)
                        i = 1;
                    else if (installMinoCnt[attackArea] != 5)
                        i = 10;
                }
            }

            

            currentTime = 0;
            attack = false;

            for (int i = 12; i <= 16; i++)
            {
                for (int j = 9; j <= 13; j++)
                    mapmanager.map[i, j, 0, 1] = 1;
            }
        }

        // 공격
        if (currentTime >= (attackDeley - 0.5f) && attack == false)
        {
            // 지역 공격
            if (installMinoCnt[attackArea] != 6)
                attackAreaCnt[attackArea] += 1;

            // 플레이어 공격
            if (attackArea == mapmanager.map[(int)mapmanager.Pos.x, (int)mapmanager.Pos.z, 0, 1])
                playerHP--;

            attack = true;
        }

        // 설치된 블록이 전부 지워졌다면
        if (delMinoCnt >= installMinoCnt[attackArea])
        {
            if (attackAreaCnt[2] == 3)
            {
                for (int i = 17; i <= 19; i++)
                {
                    for (int j = 9; j <= 16; j++)
                        mapmanager.map[i, j, 0, 1] = 2;
                }
                attackAreaCnt[2] = 0;
                installMinoCnt[2] = 0;
            }
            if (attackAreaCnt[3] == 3)
            {
                for (int i = 12; i <= 19; i++)
                {
                    for (int j = 6; j <= 8; j++)
                        mapmanager.map[i, j, 0, 1] = 3;
                }
                attackAreaCnt[3] = 0;
                installMinoCnt[3] = 0;
            }
            if (attackAreaCnt[4] == 3)
            {
                for (int i = 9; i <= 11; i++)
                {
                    for (int j = 6; j <= 13; j++)
                        mapmanager.map[i, j, 0, 1] = 4;
                }
                attackAreaCnt[4] = 0;
                installMinoCnt[4] = 0;
            }
            if (attackAreaCnt[5] == 3)
            {
                for (int i = 9; i <= 16; i++)
                {
                    for (int j = 14; j <= 16; j++)
                        mapmanager.map[i, j, 0, 1] = 5;
                }
                attackAreaCnt[5] = 0;
                installMinoCnt[5] = 0;
            }

            if (clearPuzzNum <= 1)
            {
                if (attackAreaCnt[6] == 3)
                {
                    for (int i = 17; i <= 21; i++)
                    {
                        mapmanager.map[i, 17, 0, 1] = 6;
                        mapmanager.map[i, 18, 0, 1] = 6;
                    }
                    for (int j = 6; j <= 16; j++)
                    {
                        mapmanager.map[20, j, 0, 1] = 6;
                        mapmanager.map[21, j, 0, 1] = 6;
                    }
                    attackAreaCnt[6] = 0;
                    installMinoCnt[6] = 0;
                }
                if (attackAreaCnt[7] == 3)
                {
                    for (int i = 7; i <= 11; i++)
                    {
                        mapmanager.map[i, 4, 0, 1] = 7;
                        mapmanager.map[i, 5, 0, 1] = 7;
                    }
                    for (int j = 6; j <= 16; j++)
                    {
                        mapmanager.map[7, j, 0, 1] = 7;
                        mapmanager.map[8, j, 0, 1] = 7;
                    }
                    attackAreaCnt[7] = 0;
                    installMinoCnt[7] = 0;
                }
            }

            if (clearPuzzNum == 0)
            {
                if (attackAreaCnt[8] == 3)
                {
                    for (int i = 12; i <= 21; i++)
                    {
                        mapmanager.map[i, 4, 0, 1] = 8;
                        mapmanager.map[i, 5, 0, 1] = 8;
                    }
                    attackAreaCnt[8] = 0;
                    installMinoCnt[8] = 0;
                }
                if (attackAreaCnt[9] == 3)
                {
                    for (int i = 7; i <= 16; i++)
                    {
                        mapmanager.map[i, 17, 0, 1] = 9;
                        mapmanager.map[i, 18, 0, 1] = 9;

                    }
                    attackAreaCnt[9] = 0;
                    installMinoCnt[9] = 0;
                }
            }

            delMinoCnt = 0;
        }

        // 각 영역별 클리어 확인
        if (1 == 1)
        {
            if (clearPuzzNum <= 2)
            {
                if (installMinoCnt[2] == 6 && clearArea[0] == 0)
                {
                    clearArea[0] = 1;
                    clearArea[8] += 1;

                    foreach (Transform child in myChildren)
                    {
                        if (child.name == ("Side2"))
                        {

                            child.gameObject.GetComponent<Renderer>().material.color = new Color(255 / 255f, 255 / 255f, 255 / 255f);
                        }
                    }
                }
                if (installMinoCnt[3] == 6 && clearArea[1] == 0)
                {
                    clearArea[1] = 1;
                    clearArea[8] += 1;

                    foreach (Transform child in myChildren)
                    {
                        if (child.name == ("Side3"))
                        {

                            child.gameObject.GetComponent<Renderer>().material.color = new Color(255 / 255f, 255 / 255f, 255 / 255f);
                        }
                    }
                }
                if (installMinoCnt[4] == 6 && clearArea[2] == 0)
                {
                    clearArea[2] = 1;
                    clearArea[8] += 1;

                    foreach (Transform child in myChildren)
                    {
                        if (child.name == ("Side4"))
                        {

                            child.gameObject.GetComponent<Renderer>().material.color = new Color(255 / 255f, 255 / 255f, 255 / 255f);
                        }
                    }
                }
                if (installMinoCnt[5] == 6 && clearArea[3] == 0)
                {
                    clearArea[3] = 1;
                    clearArea[8] += 1;

                    foreach (Transform child in myChildren)
                    {
                        if (child.name == ("Side5"))
                        {

                            child.gameObject.GetComponent<Renderer>().material.color = new Color(255 / 255f, 255 / 255f, 255 / 255f);
                        }
                    }
                }
            }

            if (clearPuzzNum <= 1)
            {
                if (installMinoCnt[6] == 8 && clearArea[4] == 0)
                {
                    clearArea[4] = 1;
                    clearArea[8] += 1;

                    foreach (Transform child in myChildren)
                    {
                        if (child.name == "Side6_1" || child.name == "Side6_2")
                        {

                            child.gameObject.GetComponent<Renderer>().material.color = new Color(255 / 255f, 255 / 255f, 255 / 255f);
                        }
                    }
                }
                if (installMinoCnt[7] == 8 && clearArea[5] == 0)
                {
                    Debug.Log(7);

                    foreach (Transform child in myChildren)
                    {
                        if (child.name == "Side7_1" || child.name == "Side7_2")
                        {
                            child.gameObject.GetComponent<Renderer>().material.color = new Color(255 / 255f, 255 / 255f, 255 / 255f);
                        }
                    }

                    clearArea[5] = 1;
                    clearArea[8] += 1;
                }
            }

            if (clearPuzzNum == 0)
            {
                if (installMinoCnt[8] == 5 && clearArea[6] == 0)
                {
                    Debug.Log(8);

                    foreach (Transform child in myChildren)
                    {
                        if (child.name == ("Side8_1"))
                        {
                            child.gameObject.GetComponent<Renderer>().material.color = new Color(255 / 255f, 255 / 255f, 255 / 255f);
                        }
                    }

                    clearArea[6] = 1;
                    clearArea[8] += 1;
                }
                if (installMinoCnt[9] == 5 && clearArea[7] == 0)
                {
                    clearArea[7] = 1;
                    clearArea[8] += 1;

                    foreach (Transform child in myChildren)
                    {
                        if (child.name == ("Side9_1"))
                        {

                            child.gameObject.GetComponent<Renderer>().material.color = new Color(255 / 255f, 255 / 255f, 255 / 255f);
                        }
                    }
                }
            }

        }
    }

    // 지역의 남은 체력에 따른 체력 변경
    void ChangeAttackAreaColor()
    {
        if (clearPuzzNum <= 2)
        {
            if (installMinoCnt[2] != 6)
            {
                if (attackAreaCnt[2] == 0)
                {
                    foreach (Transform child in myChildren)
                    {
                        if (child.name == ("Side2"))
                        {
                            child.gameObject.GetComponent<Renderer>().material.color = new Color(170 / 255f, 255 / 255f, 170 / 255f);
                        }
                    }
                }
                if (attackAreaCnt[2] == 1)
                {
                    foreach (Transform child in myChildren)
                    {
                        if (child.name == ("Side2"))
                        {
                            child.gameObject.GetComponent<Renderer>().material.color = new Color(85 / 255f, 255 / 255f, 85 / 255f);
                        }
                    }
                }
                if (attackAreaCnt[2] == 2)
                {
                    foreach (Transform child in myChildren)
                    {
                        if (child.name == ("Side2"))
                        {
                            child.gameObject.GetComponent<Renderer>().material.color = new Color(0 / 255f, 255 / 255f, 0 / 255f);
                        }
                    }
                }
            }
            if (installMinoCnt[3] != 6)
            {
                if (attackAreaCnt[3] == 0)
                {
                    foreach (Transform child in myChildren)
                    {
                        if (child.name == ("Side3"))
                        {
                            child.gameObject.GetComponent<Renderer>().material.color = new Color(170 / 255f, 170 / 255f, 255 / 255f);
                        }
                    }
                }
                if (attackAreaCnt[3] == 1)
                {
                    foreach (Transform child in myChildren)
                    {
                        if (child.name == ("Side3"))
                        {
                            child.gameObject.GetComponent<Renderer>().material.color = new Color(85 / 255f, 85 / 255f, 255 / 255f);
                        }
                    }
                }
                if (attackAreaCnt[3] == 2)
                {
                    foreach (Transform child in myChildren)
                    {
                        if (child.name == ("Side3"))
                        {
                            child.gameObject.GetComponent<Renderer>().material.color = new Color(0 / 255f, 0 / 255f, 255 / 255f);
                        }
                    }
                }
            }
            if (installMinoCnt[4] != 6)
            {
                if (attackAreaCnt[4] == 0)
                {
                    foreach (Transform child in myChildren)
                    {
                        if (child.name == ("Side4"))
                        {
                            child.gameObject.GetComponent<Renderer>().material.color = new Color(255 / 255f, 170 / 255f, 170 / 255f);
                        }
                    }
                }
                if (attackAreaCnt[4] == 1)
                {
                    foreach (Transform child in myChildren)
                    {
                        if (child.name == ("Side4"))
                        {
                            child.gameObject.GetComponent<Renderer>().material.color = new Color(255 / 255f, 85 / 255f, 85 / 255f);
                        }
                    }
                }
                if (attackAreaCnt[4] == 2)
                {
                    foreach (Transform child in myChildren)
                    {
                        if (child.name == ("Side4"))
                        {
                            child.gameObject.GetComponent<Renderer>().material.color = new Color(255 / 255f, 0 / 255f, 0 / 255f);
                        }
                    }
                }
            }
            if (installMinoCnt[5] != 6)
            {
                if (attackAreaCnt[5] == 0)
                {
                    foreach (Transform child in myChildren)
                    {
                        if (child.name == ("Side5"))
                        {
                            child.gameObject.GetComponent<Renderer>().material.color = new Color(255 / 255f, 230 / 255f, 170 / 255f);
                        }
                    }
                }
                if (attackAreaCnt[5] == 1)
                {
                    foreach (Transform child in myChildren)
                    {
                        if (child.name == ("Side5"))
                        {
                            child.gameObject.GetComponent<Renderer>().material.color = new Color(255 / 255f, 205 / 255f, 85 / 255f);
                        }
                    }
                }
                if (attackAreaCnt[5] == 2)
                {
                    foreach (Transform child in myChildren)
                    {
                        if (child.name == ("Side5"))
                        {
                            child.gameObject.GetComponent<Renderer>().material.color = new Color(255 / 255f, 180 / 255f, 0 / 255f);
                        }
                    }
                }
            }
        }


        if (clearPuzzNum <= 1)
        {
            if (installMinoCnt[6] != 6)
            {
                if (attackAreaCnt[6] == 0)
                {
                    foreach (Transform child in myChildren)
                    {
                        if (child.name == "Side6_1" || child.name == "Side6_2")
                        {
                            child.gameObject.GetComponent<Renderer>().material.color = new Color(255 / 255f, 170 / 255f, 255 / 255f);
                        }
                    }
                }
                if (attackAreaCnt[6] == 1)
                {
                    foreach (Transform child in myChildren)
                    {
                        if (child.name == "Side6_1" || child.name == "Side6_2")
                        {
                            child.gameObject.GetComponent<Renderer>().material.color = new Color(255 / 255f, 85 / 255f, 255 / 255f);
                        }
                    }
                }
                if (attackAreaCnt[6] == 2)
                {
                    foreach (Transform child in myChildren)
                    {
                        if (child.name == "Side6_1" || child.name == "Side6_2")
                        {
                            child.gameObject.GetComponent<Renderer>().material.color = new Color(255 / 255f, 0 / 255f, 255 / 255f);
                        }
                    }
                }
            }
            if (installMinoCnt[7] != 6)
            {
                if (attackAreaCnt[7] == 0)
                {
                    foreach (Transform child in myChildren)
                    {
                        if (child.name == "Side7_1" || child.name == "Side7_2")
                        {
                            child.gameObject.GetComponent<Renderer>().material.color = new Color(255 / 255f, 170 / 255f, 255 / 255f);
                        }
                    }
                }
                if (attackAreaCnt[7] == 1)
                {
                    foreach (Transform child in myChildren)
                    {
                        if (child.name == "Side7_1" || child.name == "Side7_2")
                        {
                            child.gameObject.GetComponent<Renderer>().material.color = new Color(255 / 255f, 85 / 255f, 255 / 255f);
                        }
                    }
                }
                if (attackAreaCnt[7] == 2)
                {
                    foreach (Transform child in myChildren)
                    {
                        if (child.name == "Side7_1" || child.name == "Side7_2")
                        {
                            child.gameObject.GetComponent<Renderer>().material.color = new Color(255 / 255f, 0 / 255f, 255 / 255f);
                        }
                    }
                }
            }
        }


        if (clearPuzzNum == 0)
        {
            if (installMinoCnt[8] != 6)
            {
                if (attackAreaCnt[8] == 0)
                {
                    foreach (Transform child in myChildren)
                    {
                        if (child.name == ("Side8_1"))
                        {
                            child.gameObject.GetComponent<Renderer>().material.color = new Color(170 / 255f, 255 / 255f, 255 / 255f);
                        }
                    }
                }
                if (attackAreaCnt[8] == 1)
                {
                    foreach (Transform child in myChildren)
                    {
                        if (child.name == ("Side8_1"))
                        {
                            child.gameObject.GetComponent<Renderer>().material.color = new Color(85 / 255f, 255 / 255f, 255 / 255f);
                        }
                    }
                }
                if (attackAreaCnt[8] == 2)
                {
                    foreach (Transform child in myChildren)
                    {
                        if (child.name == ("Side8_1"))
                        {
                            child.gameObject.GetComponent<Renderer>().material.color = new Color(0 / 255f, 255 / 255f, 255 / 255f);
                        }
                    }
                }
            }
            if (installMinoCnt[9] != 6)
            {
                if (attackAreaCnt[9] == 0)
                {
                    foreach (Transform child in myChildren)
                    {
                        if (child.name == ("Side9_1"))
                        {
                            child.gameObject.GetComponent<Renderer>().material.color = new Color(170 / 255f, 255 / 255f, 255 / 255f);
                        }
                    }
                }
                if (attackAreaCnt[9] == 1)
                {
                    foreach (Transform child in myChildren)
                    {
                        if (child.name == ("Side9_1"))
                        {
                            child.gameObject.GetComponent<Renderer>().material.color = new Color(85 / 255f, 255 / 255f, 255 / 255f);
                        }
                    }
                }
                if (attackAreaCnt[9] == 2)
                {
                    foreach (Transform child in myChildren)
                    {
                        if (child.name == ("Side9_1"))
                        {
                            child.gameObject.GetComponent<Renderer>().material.color = new Color(0 / 255f, 255 / 255f, 255 / 255f);
                        }
                    }
                }
            }
        }

    }
    
    void ClearBattle()
    {


        if (clearPuzzNum >= 2)
        {
            for (int i = 14; i <= 24; i++)
            {
                mapmanager.map[i, 22, 0, 0] = 1;
                mapmanager.map[i, 10, 0, 0] = 1;
            }

            for (int i = 11; i <= 21; i++)
            {
                mapmanager.map[13, i, 0, 0] = 1;
                mapmanager.map[25, i, 0, 0] = 1;
            }
            foreach (Transform child in myChildren)
            {
                if (child.name == "Side6_1" || child.name == "Side6_2" || child.name == "Side7_1" || child.name == "Side7_2")
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(255 / 255f, 255 / 255f, 255 / 255f);
                }
            }
        }
        if (clearPuzzNum >= 1)
        {            
            //아래, 이동 허용
            for (int i = 17; i <= 26; i++)
                mapmanager.map[i, 10, 0, 0] = 0;
            mapmanager.map[17, 9, 0, 0] = 0;

            // 위, 이동 금지
            for (int i = 12; i <= 21; i++)
                mapmanager.map[i, 22, 0, 0] = 0;
            mapmanager.map[21, 23, 0, 0] = 0;

            foreach (Transform child in myChildren)
            {
                if (child.name == "Side8_1" || child.name == "Side9_1")
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(255 / 255f, 255 / 255f, 255 / 255f);
                }
            }
        }
        battleStart = true;
    }




    void FixedInstall()
    {
        if (clearPuzzNum <= 2)
        {
            if (installMinoCnt[2] == 6 && clearArea[0] != 1)
                clearArea[0] = 1;
            if (installMinoCnt[3] == 6 && clearArea[1] != 1)
                clearArea[1] = 1;
            if (installMinoCnt[4] == 6 && clearArea[2] != 1)
                clearArea[2] = 1;
            if (installMinoCnt[5] == 6 && clearArea[3] != 1)
                clearArea[3] = 1;
        }


        if (clearPuzzNum <= 1)
        {
            if (installMinoCnt[6] == 8 && clearArea[4] != 1)
                clearArea[4] = 1;
            if (installMinoCnt[7] == 8 && clearArea[5] != 1)
                clearArea[5] = 1;
        }


        if (clearPuzzNum <= 0)
        {
            if (installMinoCnt[8] == 5 && clearArea[6] != 1)
                clearArea[6] = 1;
            if (installMinoCnt[9] == 5 && clearArea[7] != 1)
                clearArea[7] = 1;
        }
    }


    void MinoInstall()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {

            if (changeCnt == 0)
                Debug.Log("설치 가능합니다.");
            if (changeCnt != 0)
                Debug.Log("넌! 나가라~!");
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {

            referenceValue = (int)locateArea[0];
            changeCnt = 0;

            for (int i = 0; i <= 3; i++)
            {
                if (referenceValue != (int)locateArea[i] || locateArea[i] >= 90)
                    changeCnt++;
            }
            if (changeCnt != 0)
            {
                Debug.Log("넌! 나가라~!");
            }
            else
            {
                if (bag[currntNum] == 1)
                {
                    Instantiate(IMIno, new Vector3(mapmanager.Pos.x, 0, mapmanager.Pos.z), Quaternion.identity);
                    Debug.Log("현재 I 미노가 있습니다.");
                }
                else if (bag[currntNum] == 2)
                {
                    Instantiate(OMIno, new Vector3(mapmanager.Pos.x, 0, mapmanager.Pos.z), Quaternion.identity);
                    Debug.Log("현재 O 미노가 있습니다.");
                }
                else if (bag[currntNum] == 3)
                {
                    Instantiate(TMIno, new Vector3(mapmanager.Pos.x, 0, mapmanager.Pos.z), Quaternion.identity);
                    Debug.Log("현재 T 미노가 있습니다.");
                }
                else if (bag[currntNum] == 4)
                {
                    Instantiate(LMIno, new Vector3(mapmanager.Pos.x, 0, mapmanager.Pos.z), Quaternion.identity);
                    Debug.Log("현재 L 미노가 있습니다.");
                }
                else if (bag[currntNum] == 5)
                {
                    Instantiate(JMIno, new Vector3(mapmanager.Pos.x, 0, mapmanager.Pos.z), Quaternion.identity);
                    Debug.Log("현재 J 미노가 있습니다.");
                }
                else if (bag[currntNum] == 6)
                {
                    Instantiate(ZMIno, new Vector3(mapmanager.Pos.x, 0, mapmanager.Pos.z), Quaternion.identity);
                    Debug.Log("현재 Z 미노가 있습니다.");
                }
                else if (bag[currntNum] == 7)
                {
                    Instantiate(SMIno, new Vector3(mapmanager.Pos.x, 0, mapmanager.Pos.z), Quaternion.identity);
                    Debug.Log("현재 S 미노가 있습니다.");
                }

                bag[currntNum] = 0;
                currntNum++;
            }



            if (currntNum == 7)
                FirstBagSetting();

            if (currntNum == 14)
                SecondBagSetting();
        }

        // 회전
        if (Input.GetKeyDown(KeyCode.Z))
            rotateInfo--;
        else if (Input.GetKeyDown(KeyCode.X))
            rotateInfo++;


        if (currntNum == 14)
            currntNum = 0;
    }

    void FirstBagSetting()
    {
        for (int i = 0; i < 7; i++)
        {
            inputNum = Random.Range(1, 8);
            overCnt = 0;

            for (int j = 0; j < 7; j++)
            {
                if (bag[j] == inputNum)
                {
                    overCnt++;
                }
            }

            if (overCnt != 0)
                i--;
            else
                bag[i] = inputNum;
        }
    }
    void SecondBagSetting()
    {
        for (int i = 7; i < 14; i++)
        {
            inputNum = Random.Range(1, 8);
            overCnt = 0;

            for (int j = 7; j < 14; j++)
            {
                if (bag[j] == inputNum)
                {
                    overCnt++;
                }
            }

            if (overCnt != 0)
                i--;
            else
                bag[i] = inputNum;
        }
    }
}

