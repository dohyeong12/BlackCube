using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S2PuzzManager : MonoBehaviour
{
    Mapmanager mapmanager;
    S2BattleScript bt;

    [Header("PuzzB")]
    [SerializeField] bool puzzBClear = false;
    bool blockChoice = false;
    public int correctNum;
    internal int patternNum1;
    internal int patternNum2;

    public GameObject tileParent;
    public GameObject tile_Blur;
    public GameObject tile_I;
    public GameObject tile_O;
    public GameObject tile_T;
    public GameObject tile_L;
    public GameObject tile_J;
    public GameObject tile_Z;
    public GameObject tile_S;
    // | I,1 | O,2 | T,3 | L,4 | J,5 | Z,6 | S,7 |

    [Header("PuzzC")]
    public GameObject puzzCkey;
    public GameObject keyHalfBlock;
    public GameObject hintBlock;
    public bool havePuzzCkey;
    [SerializeField] int hideMino;
    public bool puzzCClear;
    /*
    1 TTTT
    2 IOJL
    3 LLZZ
    4 JJSS
    */


    void Start()
    {
        mapmanager = FindObjectOfType<Mapmanager>();
        bt = FindObjectOfType<S2BattleScript>();

        puzzBClear = false; 
        blockChoice = false;

        PuzzPreparing();
        TileSetting();
    }


    void Update()
    {
        PuzzB();
        PuzzC();

        if (correctNum == 12 )
            InsTile_Clear();
    }

    
    // 퍼즐 패턴 정하기
    void PuzzPreparing()
    {
        correctNum = 0; 
        puzzCClear = false;
        patternNum1 = Random.Range(1, 10);
        Instantiate(puzzCkey, new Vector3(28, 0, 1), Quaternion.identity)/*.transform.parent = tileParent.transform*/;

        // TTTT
        if (patternNum1 == 1 || patternNum1 == 2)
        {
            InsTile_Blur();
            hideMino = 3;

            Instantiate(hintBlock, new Vector3(25, 0.6f, 18), Quaternion.identity).transform.parent = tileParent.transform;
            mapmanager.map[1, 3, 0, 1] = 3;
            mapmanager.map[2, 3, 0, 1] = 3;
            mapmanager.map[3, 3, 0, 1] = 3;
            mapmanager.map[2, 4, 0, 1] = 3;

            Instantiate(hintBlock, new Vector3(26, 0.6f, 18), Quaternion.identity).transform.parent = tileParent.transform;
            mapmanager.map[2, 11, 0, 1] = 3;
            mapmanager.map[3, 11, 0, 1] = 3;
            mapmanager.map[4, 11, 0, 1] = 3;
            mapmanager.map[3, 10, 0, 1] = 3;

            Instantiate(hintBlock, new Vector3(27, 0.6f, 18), Quaternion.identity).transform.parent = tileParent.transform; mapmanager.map[3, 16, 0, 1] = 1;
            mapmanager.map[4, 15, 0, 1] = 3;
            mapmanager.map[4, 14, 0, 1] = 3;
            mapmanager.map[4, 13, 0, 1] = 3;
            mapmanager.map[3, 14, 0, 1] = 3;

        }

        // IOLJ
        if (patternNum1 == 3 || patternNum1 == 4 || patternNum1 == 5)
        {
            patternNum2 = Random.Range(1, 3);

            // I
            if (patternNum2 == 1)
            {
                hideMino = 1;

                Instantiate(hintBlock, new Vector3(23, 0.6f, 8), Quaternion.identity).transform.parent = tileParent.transform; // L, 4
                mapmanager.map[4, 4, 0, 1] = 4;
                mapmanager.map[4, 5, 0, 1] = 4;
                mapmanager.map[4, 6, 0, 1] = 4;
                mapmanager.map[3, 6, 0, 1] = 4;

                Instantiate(hintBlock, new Vector3(23, 0.6f, 13), Quaternion.identity).transform.parent = tileParent.transform; // O, 2
                mapmanager.map[2, 9, 0, 1] = 2;
                mapmanager.map[3, 9, 0, 1] = 2;
                mapmanager.map[2, 10, 0, 1] = 2;
                mapmanager.map[3, 10, 0, 1] = 2;

                Instantiate(hintBlock, new Vector3(28, 0.6f, 10), Quaternion.identity).transform.parent = tileParent.transform; // J, 5
                mapmanager.map[2, 16, 0, 1] = 5;
                mapmanager.map[1, 16, 0, 1] = 5;
                mapmanager.map[1, 15, 0, 1] = 5;
                mapmanager.map[1, 14, 0, 1] = 5;
            }
            // O
            if (patternNum2 == 2) //J
            {
                hideMino = 2;

                Instantiate(hintBlock, new Vector3(28, 0.6f, 8), Quaternion.identity).transform.parent = tileParent.transform; // J, 5
                mapmanager.map[1, 4, 0, 1] = 5;
                mapmanager.map[1, 5, 0, 1] = 5;
                mapmanager.map[1, 6, 0, 1] = 5;
                mapmanager.map[2, 6, 0, 1] = 5;

                Instantiate(hintBlock, new Vector3(23, 0.6f, 9), Quaternion.identity).transform.parent = tileParent.transform; // L, 4
                mapmanager.map[4, 9, 0, 1] = 4;
                mapmanager.map[4, 10, 0, 1] = 4;
                mapmanager.map[4, 11, 0, 1] = 4;
                mapmanager.map[3, 11, 0, 1] = 4;

                Instantiate(hintBlock, new Vector3(28, 0.6f, 14), Quaternion.identity).transform.parent = tileParent.transform; // I, 1
                mapmanager.map[1, 13, 0, 1] = 1;
                mapmanager.map[2, 13, 0, 1] = 1;
                mapmanager.map[3, 13, 0, 1] = 1;
                mapmanager.map[4, 13, 0, 1] = 1;

            }

            InsTile_Blur();
        }

        // LLZZ
        if (patternNum1 == 6 || patternNum1 == 7)
        {
            patternNum2 = Random.Range(1, 3);

            // L
            if (patternNum2 == 1)
            {
                hideMino = 4;

                Instantiate(hintBlock, new Vector3(23, 0.6f, 4), Quaternion.identity).transform.parent = tileParent.transform; // Z, 6
                mapmanager.map[2, 4, 0, 1] = 6;
                mapmanager.map[3, 4, 0, 1] = 6;
                mapmanager.map[3, 3, 0, 1] = 6;
                mapmanager.map[4, 3, 0, 1] = 6;

                Instantiate(hintBlock, new Vector3(23, 0.6f, 5), Quaternion.identity).transform.parent = tileParent.transform; // Z, 6
                mapmanager.map[1, 11, 0, 1] = 6;
                mapmanager.map[2, 11, 0, 1] = 6;
                mapmanager.map[2, 10, 0, 1] = 6;
                mapmanager.map[3, 10, 0, 1] = 6;

                Instantiate(hintBlock, new Vector3(23, 0.6f, 10), Quaternion.identity).transform.parent = tileParent.transform; // L, 4
                mapmanager.map[3, 16, 0, 1] = 4;
                mapmanager.map[4, 16, 0, 1] = 4;
                mapmanager.map[4, 15, 0, 1] = 4;
                mapmanager.map[4, 14, 0, 1] = 4;
            }
            // Z
            if (patternNum2 == 2)
            {
                hideMino = 6;

                Instantiate(hintBlock, new Vector3(23, 0.6f, 8), Quaternion.identity).transform.parent = tileParent.transform; // L, 4
                mapmanager.map[1, 3, 0, 1] = 4;
                mapmanager.map[1, 4, 0, 1] = 4;
                mapmanager.map[1, 5, 0, 1] = 4;
                mapmanager.map[2, 3, 0, 1] = 4;

                Instantiate(hintBlock, new Vector3(23, 0.6f, 5), Quaternion.identity).transform.parent = tileParent.transform; // Z, 6
                mapmanager.map[1, 11, 0, 1] = 6;
                mapmanager.map[2, 11, 0, 1] = 6;
                mapmanager.map[2, 10, 0, 1] = 6;
                mapmanager.map[3, 10, 0, 1] = 6;

                Instantiate(hintBlock, new Vector3(23, 0.6f, 10), Quaternion.identity).transform.parent = tileParent.transform; // L, 4
                mapmanager.map[4, 14, 0, 1] = 4;
                mapmanager.map[4, 15, 0, 1] = 4;
                mapmanager.map[4, 16, 0, 1] = 4;
                mapmanager.map[3, 16, 0, 1] = 4;
            }

            InsTile_Blur();
        }

        // JJSS
        if (patternNum1 == 8 || patternNum1 == 9)
        {
            patternNum2 = Random.Range(1, 3);

            // J
            if (patternNum2 == 1)
            {
                hideMino = 5;

                Instantiate(hintBlock, new Vector3(28, 0.6f, 4), Quaternion.identity).transform.parent = tileParent.transform; // S, 7
                mapmanager.map[1, 3, 0, 1] = 7;
                mapmanager.map[2, 3, 0, 1] = 7;
                mapmanager.map[2, 4, 0, 1] = 7;
                mapmanager.map[3, 4, 0, 1] = 7;

                Instantiate(hintBlock, new Vector3(28, 0.6f, 5), Quaternion.identity).transform.parent = tileParent.transform; // S, 7
                mapmanager.map[2, 10, 0, 1] = 7;
                mapmanager.map[3, 10, 0, 1] = 7;
                mapmanager.map[3, 11, 0, 1] = 7;
                mapmanager.map[4, 11, 0, 1] = 7;

                Instantiate(hintBlock, new Vector3(28, 0.6f, 10), Quaternion.identity).transform.parent = tileParent.transform; // J, 5
                mapmanager.map[1, 14, 0, 1] = 5;
                mapmanager.map[1, 15, 0, 1] = 5;
                mapmanager.map[1, 16, 0, 1] = 5;
                mapmanager.map[2, 16, 0, 1] = 5;
            }
            // S
            if (patternNum2 == 2)
            {
                hideMino = 7;

                Instantiate(hintBlock, new Vector3(28, 0.6f, 8), Quaternion.identity).transform.parent = tileParent.transform; // J, 5
                mapmanager.map[4, 3, 0, 1] = 5;
                mapmanager.map[4, 4, 0, 1] = 5;
                mapmanager.map[4, 5, 0, 1] = 5;
                mapmanager.map[3, 3, 0, 1] = 5;

                Instantiate(hintBlock, new Vector3(28, 0.6f, 5), Quaternion.identity).transform.parent = tileParent.transform; // S, 7
                mapmanager.map[1, 8, 0, 1] = 7;
                mapmanager.map[2, 8, 0, 1] = 7;
                mapmanager.map[2, 9, 0, 1] = 7;
                mapmanager.map[3, 9, 0, 1] = 7;

                Instantiate(hintBlock, new Vector3(28, 0.6f, 10), Quaternion.identity).transform.parent = tileParent.transform; // J, 5
                mapmanager.map[1, 14, 0, 1] = 5;
                mapmanager.map[1, 15, 0, 1] = 5;
                mapmanager.map[1, 16, 0, 1] = 5;
                mapmanager.map[2, 16, 0, 1] = 5;
            }


            InsTile_Blur();
        }


        // PuzzC의 발판에 값 넣기
        if (1 == 1)
        {
            // I
            mapmanager.map[27, 12, 0, 1] = 1;
            mapmanager.map[27, 13, 0, 1] = 1;
            mapmanager.map[27, 14, 0, 1] = 1;
            // O
            mapmanager.map[24, 12, 0, 1] = 2;
            mapmanager.map[24, 13, 0, 1] = 2;
            mapmanager.map[24, 14, 0, 1] = 2;
            // T
            mapmanager.map[25, 17, 0, 1] = 3;
            mapmanager.map[26, 17, 0, 1] = 3;
            mapmanager.map[27, 17, 0, 1] = 3;
            // L
            mapmanager.map[24, 8, 0, 1] = 4;
            mapmanager.map[24, 9, 0, 1] = 4;
            mapmanager.map[24, 10, 0, 1] = 4;
            // J
            mapmanager.map[27, 8, 0, 1] = 5;
            mapmanager.map[27, 9, 0, 1] = 5;
            mapmanager.map[27, 10, 0, 1] = 5;
            // Z
            mapmanager.map[24, 4, 0, 1] = 6;
            mapmanager.map[24, 5, 0, 1] = 6;
            mapmanager.map[24, 6, 0, 1] = 6;
            // S
            mapmanager.map[27, 4, 0, 1] = 7;
            mapmanager.map[27, 5, 0, 1] = 7;
            mapmanager.map[27, 6, 0, 1] = 7;
        }
    }
    
    // 타일의 상태 설정하기
    void TileSetting()
    {
        // 중앙 지역, 1
        for(int i = 12; i<= 16; i++)
        {
            for (int j = 9; j <= 13; j++)
                mapmanager.map[i, j, 0, 1] = 1;
        }

        // 중앙 오른 지역, 2
        for (int i = 17; i <= 19; i++)
        {
            for (int j = 9; j <= 16; j++)
                mapmanager.map[i, j, 0, 1] = 2;
        }

        // 중앙 아래 지역, 3
        for (int i = 12; i <= 19; i++)
        {
            for (int j = 6; j <= 8; j++)
                mapmanager.map[i, j, 0, 1] = 3;
        }

        // 중앙 왼 지역, 4
        for (int i = 9; i <= 11; i++)
        {
            for (int j = 6; j <= 13; j++)
                mapmanager.map[i, j, 0, 1] =4;
        }        
        
        // 중앙 위 지역, 5
        for (int i = 9; i <= 16; i++)
        {
            for (int j = 14; j <= 16; j++)
                mapmanager.map[i, j, 0, 1] = 5;
        }

        // 가장 오른 지역, 6
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

        // 가장 왼 지역, 7
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

        // 가장 아래 지역, 8
        for (int i = 12; i <= 21; i++)
        {
            mapmanager.map[i, 4, 0, 1] = 8;
            mapmanager.map[i, 5, 0, 1] = 8;
        }

        // 가장 위  지역, 9
        for (int i = 7; i <= 16; i++)
        {
            mapmanager.map[i, 17, 0, 1] = 9;
            mapmanager.map[i, 18, 0, 1] = 9;
        }
    }


    void PuzzB()
    {
        // if : 퍼즐B에서 특정 위치위에서 스페이스를 누르면 퍼즐 풀이를 할 수 있다.
        if (Input.GetKeyDown(KeyCode.Space) && puzzBClear == false && correctNum < 12 && (
            // 좌표 설정 1.Y 3~6 || 2. Y 8~11 || 3. 13~18
            (mapmanager.Pos.x >= 1 && mapmanager.Pos.x <= 4 && mapmanager.Pos.z >= 3 && mapmanager.Pos.z <= 6) ||
            (mapmanager.Pos.x >= 1 && mapmanager.Pos.x <= 4 && mapmanager.Pos.z >= 8 && mapmanager.Pos.z <= 11) ||
            (mapmanager.Pos.x >= 1 && mapmanager.Pos.x <= 4 && mapmanager.Pos.z >= 13 && mapmanager.Pos.z <= 16)))
        {
            if (mapmanager.map[(int)mapmanager.Pos.x, (int)mapmanager.Pos.z, 0, 1] != 8)
            {
                mapmanager.moveStop = true;
                blockChoice = true;

                Debug.Log("start");
            }
            else
            {
                Debug.Log("해당 위치는 이미 맞추었습니다.");
            }

        }



        if (blockChoice == true)
        {
            //  X
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                mapmanager.moveStop = false;
                blockChoice = false;
                Debug.Log("취소");
            }

            // 0~7을 누른다면
            // I, 1
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                mapmanager.moveStop = false;
                blockChoice = false;

                if (mapmanager.map[(int)mapmanager.Pos.x, (int)mapmanager.Pos.z, 0, 1] == 1)
                {
                    Debug.Log("맞았습니다~ (선택블록 : I, 1)");
                    correctNum++;
                    Instantiate(tile_I, new Vector3(mapmanager.Pos.x, -0.99f, mapmanager.Pos.z), Quaternion.identity).transform.parent = tileParent.transform;
                    mapmanager.map[(int)mapmanager.Pos.x, (int)mapmanager.Pos.z, 0, 1] = 8;
                }
                else
                {
                    Debug.Log("틀렸습니다!~ (선택블록 : I, 1)");
                }
            }
            // O, 2
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                mapmanager.moveStop = false;
                blockChoice = false;

                if (mapmanager.map[(int)mapmanager.Pos.x, (int)mapmanager.Pos.z, 0, 1] == 2)
                {
                    Debug.Log("맞았습니다~ (선택블록 : O, 2)");
                    correctNum++;
                    Instantiate(tile_O, new Vector3(mapmanager.Pos.x, -0.99f, mapmanager.Pos.z), Quaternion.identity).transform.parent = tileParent.transform;
                    mapmanager.map[(int)mapmanager.Pos.x, (int)mapmanager.Pos.z, 0, 1] = 8;
                }
                else
                {
                    Debug.Log("틀렸습니다!~ (선택블록 : O, 2)");
                }
            }
            // T, 3
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                mapmanager.moveStop = false;
                blockChoice = false;

                if (mapmanager.map[(int)mapmanager.Pos.x, (int)mapmanager.Pos.z, 0, 1] == 3)
                {
                    Debug.Log("맞았습니다~ (선택블록 : T, 3)");
                    correctNum++;
                    Instantiate(tile_T, new Vector3(mapmanager.Pos.x, -0.99f, mapmanager.Pos.z), Quaternion.identity).transform.parent = tileParent.transform;
                    mapmanager.map[(int)mapmanager.Pos.x, (int)mapmanager.Pos.z, 0, 1] = 8;
                }
                else
                {
                    Debug.Log("틀렸습니다!~ (선택블록 : T, 3)");
                }
            }
            // L. 4
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                mapmanager.moveStop = false;
                blockChoice = false;

                if (mapmanager.map[(int)mapmanager.Pos.x, (int)mapmanager.Pos.z, 0, 1] == 4)
                {
                    Debug.Log("맞았습니다~ (선택블록 : L, 4)");
                    correctNum++;
                    Instantiate(tile_L, new Vector3(mapmanager.Pos.x, -0.99f, mapmanager.Pos.z), Quaternion.identity).transform.parent = tileParent.transform;
                    mapmanager.map[(int)mapmanager.Pos.x, (int)mapmanager.Pos.z, 0, 1] = 8;
                }
                else
                {
                    Debug.Log("틀렸습니다!~ (선택블록 : L, 4)");
                }
            }
            // J, 5
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                mapmanager.moveStop = false;
                blockChoice = false;

                if (mapmanager.map[(int)mapmanager.Pos.x, (int)mapmanager.Pos.z, 0, 1] == 5)
                {
                    Debug.Log("맞았습니다~ (선택블록 : J, 5)");
                    correctNum++;
                    Instantiate(tile_J, new Vector3(mapmanager.Pos.x, -0.99f, mapmanager.Pos.z), Quaternion.identity).transform.parent = tileParent.transform;
                    mapmanager.map[(int)mapmanager.Pos.x, (int)mapmanager.Pos.z, 0, 1] = 8;
                }
                else
                {
                    Debug.Log("틀렸습니다!~ (선택블록 : J, 5)");
                }
            }
            // Z, 6
            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                mapmanager.moveStop = false;
                blockChoice = false;

                if (mapmanager.map[(int)mapmanager.Pos.x, (int)mapmanager.Pos.z, 0, 1] == 6)
                {
                    Debug.Log("맞았습니다~ (선택블록 : Z, 6)");
                    correctNum++;
                    Instantiate(tile_Z, new Vector3(mapmanager.Pos.x, -0.99f, mapmanager.Pos.z), Quaternion.identity).transform.parent = tileParent.transform;
                    mapmanager.map[(int)mapmanager.Pos.x, (int)mapmanager.Pos.z, 0, 1] = 8;
                }
                else
                {
                    Debug.Log("틀렸습니다!~ (선택블록 : Z, 6)");
                }
            }
            // S, 7
            if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                mapmanager.moveStop = false;
                blockChoice = false;

                if (mapmanager.map[(int)mapmanager.Pos.x, (int)mapmanager.Pos.z, 0, 1] == 7)
                {
                    Debug.Log("맞았습니다~ (선택블록 : S, 7)");
                    correctNum++;
                    Instantiate(tile_S, new Vector3(mapmanager.Pos.x, -0.99f, mapmanager.Pos.z), Quaternion.identity).transform.parent = tileParent.transform;
                    mapmanager.map[(int)mapmanager.Pos.x, (int)mapmanager.Pos.z, 0, 1] = 8;
                }
                else
                {
                    Debug.Log("틀렸습니다!~ (선택블록 : S, 7)");
                }
            }
        }
    }

    void InsTile_Blur()
    {
        // TTTT
        if (patternNum1 == 1 || patternNum1 == 2)
        {
            Instantiate(tile_Blur, new Vector3(1, -0.99f, 4), Quaternion.identity).transform.parent = tileParent.transform;
            Instantiate(tile_Blur, new Vector3(1, -0.99f, 5), Quaternion.identity).transform.parent = tileParent.transform;
            Instantiate(tile_Blur, new Vector3(1, -0.99f, 6), Quaternion.identity).transform.parent = tileParent.transform;
            Instantiate(tile_Blur, new Vector3(2, -0.99f, 5), Quaternion.identity).transform.parent = tileParent.transform;

            // Second Part                                
            Instantiate(tile_Blur, new Vector3(1, -0.99f, 9), Quaternion.identity).transform.parent = tileParent.transform;
            Instantiate(tile_Blur, new Vector3(1, -0.99f, 10), Quaternion.identity).transform.parent = tileParent.transform;
            Instantiate(tile_Blur, new Vector3(1, -0.99f, 11), Quaternion.identity).transform.parent = tileParent.transform;
            Instantiate(tile_Blur, new Vector3(2, -0.99f, 10), Quaternion.identity).transform.parent = tileParent.transform;

            // Third Part
            Instantiate(tile_Blur, new Vector3(1, -0.99f, 14), Quaternion.identity).transform.parent = tileParent.transform;
            Instantiate(tile_Blur, new Vector3(1, -0.99f, 15), Quaternion.identity).transform.parent = tileParent.transform;
            Instantiate(tile_Blur, new Vector3(1, -0.99f, 16), Quaternion.identity).transform.parent = tileParent.transform;
            Instantiate(tile_Blur, new Vector3(2, -0.99f, 15), Quaternion.identity).transform.parent = tileParent.transform;
        }

        // IOLJ
        if (patternNum1 == 3 || patternNum1 == 4 || patternNum1 == 5)
        {
            // I
            if (patternNum2 == 1) 
            {
                Instantiate(tile_Blur, new Vector3(1, -0.99f, 3), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(2, -0.99f, 3), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(3, -0.99f, 3), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(4, -0.99f, 3), Quaternion.identity).transform.parent = tileParent.transform;

                // Second Part                                
                Instantiate(tile_Blur, new Vector3(1, -0.99f, 8), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(2, -0.99f, 8), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(3, -0.99f, 8), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(4, -0.99f, 8), Quaternion.identity).transform.parent = tileParent.transform;

                // Third Part
                Instantiate(tile_Blur, new Vector3(1, -0.99f, 13), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(2, -0.99f, 13), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(3, -0.99f, 13), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(4, -0.99f, 13), Quaternion.identity).transform.parent = tileParent.transform;
            }
            // O
            if (patternNum2 == 2) 
            {
                // First Part
                Instantiate(tile_Blur, new Vector3(2, -0.99f, 4), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(2, -0.99f, 5), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(3, -0.99f, 5), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(3, -0.99f, 4), Quaternion.identity).transform.parent = tileParent.transform;

                // Second Part                                
                Instantiate(tile_Blur, new Vector3(2, -0.99f, 9), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(2, -0.99f, 10), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(3, -0.99f, 9), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(3, -0.99f, 10), Quaternion.identity).transform.parent = tileParent.transform;

                // Third Part
                Instantiate(tile_Blur, new Vector3(2, -0.99f, 14), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(2, -0.99f, 15), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(3, -0.99f, 14), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(3, -0.99f, 15), Quaternion.identity).transform.parent = tileParent.transform;
            }
        }

        // LLZZ
        if (patternNum1 == 6 || patternNum1 == 7)
        {
            // L
            if (patternNum2 == 1)
            {
                // First Part
                Instantiate(tile_Blur, new Vector3(1, -0.99f, 5), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(1, -0.99f, 4), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(1, -0.99f, 3), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(2, -0.99f, 3), Quaternion.identity).transform.parent = tileParent.transform;

                // Second Part                                
                Instantiate(tile_Blur, new Vector3(1, -0.99f, 10), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(1, -0.99f, 9), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(1, -0.99f, 8), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(2, -0.99f, 8), Quaternion.identity).transform.parent = tileParent.transform;

                // Third Part
                Instantiate(tile_Blur, new Vector3(1, -0.99f, 15), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(1, -0.99f, 14), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(1, -0.99f, 13), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(2, -0.99f, 13), Quaternion.identity).transform.parent = tileParent.transform;
            }
            // Z
            if (patternNum2 == 2)
            {
                // First Part
                Instantiate(tile_Blur, new Vector3(2, -0.99f, 4), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(3, -0.99f, 4), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(3, -0.99f, 3), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(4, -0.99f, 3), Quaternion.identity).transform.parent = tileParent.transform;

                // Second Part                                
                Instantiate(tile_Blur, new Vector3(2, -0.99f, 9), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(3, -0.99f, 9), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(3, -0.99f, 8), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(4, -0.99f, 8), Quaternion.identity).transform.parent = tileParent.transform;

                // Third Part
                Instantiate(tile_Blur, new Vector3(2, -0.99f, 14), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(3, -0.99f, 14), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(3, -0.99f, 13), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(4, -0.99f, 13), Quaternion.identity).transform.parent = tileParent.transform;
            }
        }

        // JJSS
        if (patternNum1 == 8 || patternNum1 == 9)
        {
            //J
            if (patternNum2 == 1)
            {
                // First Part
                Instantiate(tile_Blur, new Vector3(4, -0.99f, 3), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(4, -0.99f, 4), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(4, -0.99f, 5), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(3, -0.99f, 3), Quaternion.identity).transform.parent = tileParent.transform;

                // Second Part                                
                Instantiate(tile_Blur, new Vector3(4, -0.99f, 8), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(4, -0.99f, 9), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(4, -0.99f, 10), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(3, -0.99f, 8), Quaternion.identity).transform.parent = tileParent.transform;

                // Third Part
                Instantiate(tile_Blur, new Vector3(4, -0.99f, 13), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(4, -0.99f, 14), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(4, -0.99f, 15), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(3, -0.99f, 13), Quaternion.identity).transform.parent = tileParent.transform;
            }
            // S
            if (patternNum2 == 2)
            {
                // First Part
                Instantiate(tile_Blur, new Vector3(2, -0.99f, 5), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(3, -0.99f, 5), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(3, -0.99f, 6), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(4, -0.99f, 6), Quaternion.identity).transform.parent = tileParent.transform;

                // Second Part                                
                Instantiate(tile_Blur, new Vector3(2, -0.99f, 10), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(3, -0.99f, 10), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(3, -0.99f, 11), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(4, -0.99f, 11), Quaternion.identity).transform.parent = tileParent.transform;

                // Third Part
                Instantiate(tile_Blur, new Vector3(2, -0.99f, 15), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(3, -0.99f, 15), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(3, -0.99f, 16), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Blur, new Vector3(4, -0.99f, 16), Quaternion.identity).transform.parent = tileParent.transform;
            }
        }
    }

    void InsTile_Clear()
    {
        bt.clearPuzzNum++;
        correctNum++;
        Debug.Log("B");

        // TTTT
        if (patternNum1 == 1 || patternNum1 == 2)
        {
            // First Part   
            Instantiate(tile_T, new Vector3(1, -0.99f, 4), Quaternion.identity).transform.parent = tileParent.transform;
            Instantiate(tile_T, new Vector3(1, -0.99f, 5), Quaternion.identity).transform.parent = tileParent.transform;
            Instantiate(tile_T, new Vector3(1, -0.99f, 6), Quaternion.identity).transform.parent = tileParent.transform;
            Instantiate(tile_T, new Vector3(2, -0.99f, 5), Quaternion.identity).transform.parent = tileParent.transform;

            // Second Part   
            Instantiate(tile_T, new Vector3(1, -0.99f, 9), Quaternion.identity).transform.parent = tileParent.transform;
            Instantiate(tile_T, new Vector3(1, -0.99f, 10), Quaternion.identity).transform.parent = tileParent.transform;
            Instantiate(tile_T, new Vector3(1, -0.99f, 11), Quaternion.identity).transform.parent = tileParent.transform;
            Instantiate(tile_T, new Vector3(2, -0.99f, 10), Quaternion.identity).transform.parent = tileParent.transform;

            // Third Part    
            Instantiate(tile_T, new Vector3(1, -0.99f, 14), Quaternion.identity).transform.parent = tileParent.transform;
            Instantiate(tile_T, new Vector3(1, -0.99f, 15), Quaternion.identity).transform.parent = tileParent.transform;
            Instantiate(tile_T, new Vector3(1, -0.99f, 16), Quaternion.identity).transform.parent = tileParent.transform;
            Instantiate(tile_T, new Vector3(2, -0.99f, 15), Quaternion.identity).transform.parent = tileParent.transform;

            correctNum++;
        }

        // IOLJ
        if (patternNum1 == 3 || patternNum1 == 4 || patternNum1 == 5)
        {
            // I
            if (patternNum2 == 1)
            {
                Instantiate(tile_I, new Vector3(1, -0.99f, 3), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_I, new Vector3(2, -0.99f, 3), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_I, new Vector3(3, -0.99f, 3), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_I, new Vector3(4, -0.99f, 3), Quaternion.identity).transform.parent = tileParent.transform;

                // Second Part
                Instantiate(tile_I, new Vector3(1, -0.99f, 8), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_I, new Vector3(2, -0.99f, 8), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_I, new Vector3(3, -0.99f, 8), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_I, new Vector3(4, -0.99f, 8), Quaternion.identity).transform.parent = tileParent.transform;

                // Third Part
                Instantiate(tile_I, new Vector3(1, -0.99f, 13), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_I, new Vector3(2, -0.99f, 13), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_I, new Vector3(3, -0.99f, 13), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_I, new Vector3(4, -0.99f, 13), Quaternion.identity).transform.parent = tileParent.transform;
            }
            // O
            if (patternNum2 == 2)
            {
                // First Part
                Instantiate(tile_O, new Vector3(2, -0.99f, 4), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_O, new Vector3(2, -0.99f, 5), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_O, new Vector3(3, -0.99f, 4), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_O, new Vector3(3, -0.99f, 5), Quaternion.identity).transform.parent = tileParent.transform;

                // Second Part
                Instantiate(tile_O, new Vector3(2, -0.99f, 9), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_O, new Vector3(2, -0.99f, 10), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_O, new Vector3(3, -0.99f, 9), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_O, new Vector3(3, -0.99f, 10), Quaternion.identity).transform.parent = tileParent.transform;

                // Third Part
                Instantiate(tile_O, new Vector3(2, -0.99f, 14), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_O, new Vector3(2, -0.99f, 15), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_O, new Vector3(3, -0.99f, 14), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_O, new Vector3(3, -0.99f, 15), Quaternion.identity).transform.parent = tileParent.transform;
            }

            correctNum++;
        }

        // LLZZ
        if (patternNum1 == 6 || patternNum1 == 7)
        {
            // L
            if (patternNum2 == 1)
            {
                Instantiate(tile_L, new Vector3(1, -0.99f, 3), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_L, new Vector3(1, -0.99f, 4), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_L, new Vector3(1, -0.99f, 5), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_L, new Vector3(2, -0.99f, 3), Quaternion.identity).transform.parent = tileParent.transform;

                // Second Part                            
                Instantiate(tile_L, new Vector3(1, -0.99f, 8), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_L, new Vector3(1, -0.99f, 9), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_L, new Vector3(1, -0.99f, 10), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_L, new Vector3(2, -0.99f, 8), Quaternion.identity).transform.parent = tileParent.transform;

                // Third Part    
                Instantiate(tile_L, new Vector3(1, -0.99f, 13), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_L, new Vector3(1, -0.99f, 14), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_L, new Vector3(1, -0.99f, 15), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_L, new Vector3(2, -0.99f, 13), Quaternion.identity).transform.parent = tileParent.transform;
            }
            // Z
            if (patternNum2 == 2)
            {
                Instantiate(tile_Z, new Vector3(2, -0.99f, 4), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Z, new Vector3(3, -0.99f, 4), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Z, new Vector3(3, -0.99f, 3), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Z, new Vector3(4, -0.99f, 3), Quaternion.identity).transform.parent = tileParent.transform;
                                 
                // Second Part                         
                Instantiate(tile_Z, new Vector3(2, -0.99f, 9), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Z, new Vector3(3, -0.99f, 9), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Z, new Vector3(3, -0.99f, 8), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Z, new Vector3(4, -0.99f, 8), Quaternion.identity).transform.parent = tileParent.transform;
                                 
                // Third Part    
                Instantiate(tile_Z, new Vector3(2, -0.99f, 14), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Z, new Vector3(3, -0.99f, 14), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Z, new Vector3(3, -0.99f, 13), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_Z, new Vector3(4, -0.99f, 13), Quaternion.identity).transform.parent = tileParent.transform;
            }

            correctNum++;
        }

        // JJSS
        if (patternNum1 == 8 || patternNum1 == 9)
        {
            if (patternNum2 == 1)
            {
                // First Part
                Instantiate(tile_J, new Vector3(4, -0.99f, 3), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_J, new Vector3(4, -0.99f, 4), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_J, new Vector3(4, -0.99f, 5), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_J, new Vector3(3, -0.99f, 3), Quaternion.identity).transform.parent = tileParent.transform;
                                 
                // Second Part                      
                Instantiate(tile_J, new Vector3(4, -0.99f, 8), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_J, new Vector3(4, -0.99f, 9), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_J, new Vector3(4, -0.99f, 10), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_J, new Vector3(3, -0.99f, 8), Quaternion.identity).transform.parent = tileParent.transform;
                                 
                // Third Part    
                Instantiate(tile_J, new Vector3(4, -0.99f, 13), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_J, new Vector3(4, -0.99f, 14), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_J, new Vector3(4, -0.99f, 15), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_J, new Vector3(3, -0.99f, 13), Quaternion.identity).transform.parent = tileParent.transform;
            }
            if (patternNum2 == 2)
            {
                // First Part
                Instantiate(tile_S, new Vector3(2, -0.99f, 5), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_S, new Vector3(3, -0.99f, 5), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_S, new Vector3(3, -0.99f, 6), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_S, new Vector3(4, -0.99f, 6), Quaternion.identity).transform.parent = tileParent.transform;
                                 
                // Second Part
                Instantiate(tile_S, new Vector3(2, -0.99f, 10), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_S, new Vector3(3, -0.99f, 10), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_S, new Vector3(3, -0.99f, 11), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_S, new Vector3(4, -0.99f, 11), Quaternion.identity).transform.parent = tileParent.transform;

                // Third Part
                Instantiate(tile_S, new Vector3(2, -0.99f, 15), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_S, new Vector3(3, -0.99f, 15), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_S, new Vector3(3, -0.99f, 16), Quaternion.identity).transform.parent = tileParent.transform;
                Instantiate(tile_S, new Vector3(4, -0.99f, 16), Quaternion.identity).transform.parent = tileParent.transform;
            }

            correctNum++;
        }
    }

    void PuzzC()
    {
        if (Input.GetKeyDown(KeyCode.Space) && puzzCClear == false && havePuzzCkey == true && (
            (mapmanager.Pos.x == 24 && mapmanager.Pos.z >=4 && mapmanager.Pos.z <= 6) || (mapmanager.Pos.x == 27 && mapmanager.Pos.z >= 4 && mapmanager.Pos.z <= 6)||
            (mapmanager.Pos.x == 24 && mapmanager.Pos.z >= 8 && mapmanager.Pos.z <= 10) || (mapmanager.Pos.x == 27 && mapmanager.Pos.z >= 8 && mapmanager.Pos.z <= 10) ||
            (mapmanager.Pos.x == 24 && mapmanager.Pos.z >= 12 && mapmanager.Pos.z <= 14) || (mapmanager.Pos.x == 27 && mapmanager.Pos.z >= 12 && mapmanager.Pos.z <= 14) ||
            (mapmanager.Pos.x >= 25 && mapmanager.Pos.x <= 27 && mapmanager.Pos.z == 17)))
        {
            havePuzzCkey = false;

            // 플레이어가 PuzzC를 풀었을 떄
            if (mapmanager.map[(int)mapmanager.Pos.x, (int)mapmanager.Pos.z, 0, 1] == hideMino)
            {
                puzzCClear = true;
                bt.clearPuzzNum++;
                Debug.Log("C");

                if (patternNum1 == 1 || patternNum1 == 2)
                {
                    Instantiate(keyHalfBlock, new Vector3(25, 0.6f, 18), Quaternion.identity).transform.parent = tileParent.transform;
                    Instantiate(keyHalfBlock, new Vector3(26, 0.6f, 18), Quaternion.identity).transform.parent = tileParent.transform;
                    Instantiate(keyHalfBlock, new Vector3(27, 0.6f, 18), Quaternion.identity).transform.parent = tileParent.transform;
                }

                if (patternNum1 == 3 || patternNum1 == 4 || patternNum1 == 5)
                {
                    if (patternNum2 == 1)
                    {
                        Instantiate(keyHalfBlock, new Vector3(28, 0.6f, 12), Quaternion.identity).transform.parent = tileParent.transform;
                        Instantiate(keyHalfBlock, new Vector3(28, 0.6f, 13), Quaternion.identity).transform.parent = tileParent.transform;
                        Instantiate(keyHalfBlock, new Vector3(28, 0.6f, 14), Quaternion.identity).transform.parent = tileParent.transform;
                    }
                    if (patternNum2 == 2)
                    {
                        Instantiate(keyHalfBlock, new Vector3(23, 0.6f, 12), Quaternion.identity).transform.parent = tileParent.transform;
                        Instantiate(keyHalfBlock, new Vector3(23, 0.6f, 13), Quaternion.identity).transform.parent = tileParent.transform;
                        Instantiate(keyHalfBlock, new Vector3(23, 0.6f, 14), Quaternion.identity).transform.parent = tileParent.transform;
                    }
                }
                
                if (patternNum1 == 6 || patternNum1 == 7)
                {
                    if (patternNum2 == 1)
                    {
                        Instantiate(keyHalfBlock, new Vector3(23, 0.6f, 8), Quaternion.identity).transform.parent = tileParent.transform;
                        Instantiate(keyHalfBlock, new Vector3(23, 0.6f, 9), Quaternion.identity).transform.parent = tileParent.transform;
                        Instantiate(keyHalfBlock, new Vector3(23, 0.6f, 10), Quaternion.identity).transform.parent = tileParent.transform;
                    }
                    if (patternNum2 == 2)
                    {
                        Instantiate(keyHalfBlock, new Vector3(23, 0.6f, 4), Quaternion.identity).transform.parent = tileParent.transform;
                        Instantiate(keyHalfBlock, new Vector3(23, 0.6f, 5), Quaternion.identity).transform.parent = tileParent.transform;
                        Instantiate(keyHalfBlock, new Vector3(23, 0.6f, 6), Quaternion.identity).transform.parent = tileParent.transform;
                    }
                }

                if (patternNum1 == 8 || patternNum1 == 9)
                {
                    if (patternNum2 == 1)
                    {
                        Instantiate(keyHalfBlock, new Vector3(28, 0.6f, 8), Quaternion.identity).transform.parent = tileParent.transform;
                        Instantiate(keyHalfBlock, new Vector3(28, 0.6f, 9), Quaternion.identity).transform.parent = tileParent.transform;
                        Instantiate(keyHalfBlock, new Vector3(28, 0.6f, 10), Quaternion.identity).transform.parent = tileParent.transform;
                    }
                    if (patternNum2 == 2)
                    {
                        Instantiate(keyHalfBlock, new Vector3(28, 0.6f, 4), Quaternion.identity).transform.parent = tileParent.transform;
                        Instantiate(keyHalfBlock, new Vector3(28, 0.6f, 5), Quaternion.identity).transform.parent = tileParent.transform;
                        Instantiate(keyHalfBlock, new Vector3(28, 0.6f, 6), Quaternion.identity).transform.parent = tileParent.transform;
                    }
                }
            }
        }
    }
}