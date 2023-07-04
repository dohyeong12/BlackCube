using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S2TetraMino : ObjectCheck
{
    //private const string V = "I_Mino(Clone)";
    S2BattleScript bt;

    [Header("Real Mino")]
    bool del = false;
    [SerializeField] float currentTime;
    Transform[] myChildren;
    [SerializeField] int locateArea;


    [Header("Blur Mino")]
    Transform player;
    float speed;


    void Start()
    {
        bt = FindObjectOfType<S2BattleScript>();
        mapmanager = FindObjectOfType<Mapmanager>();
        myChildren = this.GetComponentsInChildren<Transform>();
        
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        speed = 1000;

        if (gameObject.CompareTag("RealMino"))
        {
            objPos = this.gameObject.transform.position;
            locateArea = (int)mapmanager.map[Mathf.RoundToInt(objPos.x), Mathf.RoundToInt(objPos.z), 0, 1];
            bt.installMinoCnt[locateArea] += 1;


            // O미노 라면 회전 X
            if (gameObject.name != "O_Mino(Clone)")
            {
                transform.rotation = Quaternion.Euler(0, bt.rotateInfo * 90, 0);
                bt.rotateInfo = 0;
            }
        }
        if (gameObject.CompareTag("TileMino"))
        {
            objPos = this.gameObject.transform.position;
            mapmanager.map[Mathf.RoundToInt(objPos.x), Mathf.RoundToInt(objPos.z), 0, 1] = 98;

            /*            if (bt.locateArea[1] == 1)
                        {
                            currentTime = 3;
                            StartCoroutine(DelMino());
                        }*/
        }

        if ((gameObject.CompareTag("TileMino") || gameObject.CompareTag("RealMino")) && bt.locateArea[1] == 1)
        {



            currentTime = 3;
            del = true;
            StartCoroutine(DelMino());
            
        }
    }


    void Update()
    {
        objPos = this.gameObject.transform.position;
        if (del == true)
            ChangeColor();


        if (bt.battleStart == true)
        {
            Move();

            PosCheck();

            if (gameObject.CompareTag("BlurMino") && bt.clearArea[8] >= bt.goal)
            {
                Destroy(this.gameObject);
            }


            if (gameObject.name != "O_MinoBulr" && gameObject.CompareTag("BlurMino"))
                transform.rotation = Quaternion.Euler(0, bt.rotateInfo * 90, 0);


            // 해당 블록이 존재하는 지역이 공격을 3번 당했다면 해당 블록은 삭제된다.
            if (gameObject.CompareTag("RealMino") && (bt.attackAreaCnt[locateArea] == 3))
            {
                bt.delMinoCnt++;
                Destroy(this.gameObject);
            }

            // 해당 블록이 존재하는 지역이 블록으로 가득차면 해당 블록은 삭제된다.
            if (gameObject.CompareTag("RealMino"))
            {
                if (locateArea >= 2 && locateArea <= 5 && bt.installMinoCnt[locateArea] == 6)
                    Destroy(this.gameObject);
                if (locateArea >= 6 && locateArea <= 7 && bt.installMinoCnt[locateArea] == 8)
                    Destroy(this.gameObject);
                if (locateArea >= 8 && locateArea <= 9 && bt.installMinoCnt[locateArea] == 5)
                    Destroy(this.gameObject);
            }
        }
        
    }

    // 현재 블록이 위치해 있는 지역을 안다.
    void PosCheck()
    {
        if (objPos.x >= 5 && objPos.x <= 23 && objPos.z >= 2 && objPos.z <= 20)
        {
            if (gameObject.CompareTag("BlurTileMino"))
            {

                if (gameObject.name == "Tile (1)")
                {
                    bt.locateArea[0] = mapmanager.map[Mathf.RoundToInt(objPos.x), Mathf.RoundToInt(objPos.z), 0, 1];
                    locateArea = (int)mapmanager.map[Mathf.RoundToInt(objPos.x), Mathf.RoundToInt(objPos.z), 0, 1];
                }
                if (gameObject.name == "Tile (2)")
                {
                    bt.locateArea[1] = mapmanager.map[Mathf.RoundToInt(objPos.x), Mathf.RoundToInt(objPos.z), 0, 1];
                }
                if (gameObject.name == "Tile (3)")
                {
                    bt.locateArea[2] = mapmanager.map[Mathf.RoundToInt(objPos.x), Mathf.RoundToInt(objPos.z), 0, 1];
                }
                if (gameObject.name == "Tile (4)")
                {
                    bt.locateArea[3] = mapmanager.map[Mathf.RoundToInt(objPos.x), Mathf.RoundToInt(objPos.z), 0, 1];
                }
            }
            
        }
    }

    // 3초후 블록을 지운다.
    IEnumerator DelMino()
    {
        objPos = this.gameObject.transform.position;
        mapmanager.map[Mathf.RoundToInt(objPos.x), Mathf.RoundToInt(objPos.z), 0, 1] = 98;
        Debug.Log("블록이 사라집니다.");

        yield return new WaitForSecondsRealtime(2.9f);
        mapmanager.map[Mathf.RoundToInt(objPos.x), Mathf.RoundToInt(objPos.z), 0, 1] = 1;

        yield return new WaitForSecondsRealtime(0.2f);
        Destroy(this.gameObject);
    }

    // 1 지역에 설치된 블록은 점점 투명해진다.
    void ChangeColor()
    {
        currentTime -= Time.deltaTime;

        foreach (Transform child in myChildren)
        {
            // I
            if (child.name == "Side" && gameObject.name == "I_Mino(Clone)")
                child.gameObject.GetComponent<Renderer>().material.color = new Color(0 / 255f, 255 / 255f, 255 / 255f, currentTime * 0.33f);

            if (child.name == "Border" && gameObject.name == "I_Mino(Clone)")
                child.gameObject.GetComponent<Renderer>().material.color = new Color(0 / 255f, 170 / 255f, 170 / 255f, currentTime * 0.33f);

            // O
            if (child.name == "Side" && gameObject.name == "O_Mino(Clone)")
                child.gameObject.GetComponent<Renderer>().material.color = new Color(255 / 255f, 255 / 255f, 0 / 255f, currentTime * 0.33f);

            if (child.name == "Border" && gameObject.name == "O_Mino(Clone)")
                child.gameObject.GetComponent<Renderer>().material.color = new Color(170 / 255f, 170 / 255f, 0 / 255f, currentTime * 0.33f);

            // T
            if (child.name == "Side" && gameObject.name == "T_Mino(Clone)")
                child.gameObject.GetComponent<Renderer>().material.color = new Color(255 / 255f, 0 / 255f, 255 / 255f, currentTime * 0.33f);

            if (child.name == "Border" && gameObject.name == "T_Mino(Clone)")
                child.gameObject.GetComponent<Renderer>().material.color = new Color(170 / 255f, 0 / 255f, 170 / 255f, currentTime * 0.33f);

            // L
            if (child.name == "Side" && gameObject.name == "L_Mino(Clone)")
                child.gameObject.GetComponent<Renderer>().material.color = new Color(255 / 255f, 180 / 255f, 0 / 255f, currentTime * 0.33f);

            if (child.name == "Border" && gameObject.name == "L_Mino(Clone)")
                child.gameObject.GetComponent<Renderer>().material.color = new Color(170 / 255f, 120 / 120, 0 / 255f, currentTime * 0.33f);

            // J
            if (child.name == "Side" && gameObject.name == "J_Mino(Clone)")
                child.gameObject.GetComponent<Renderer>().material.color = new Color(0 / 255f, 0 / 255f, 255 / 255f, currentTime * 0.33f);

            if (child.name == "Border" && gameObject.name == "J_Mino(Clone)")
                child.gameObject.GetComponent<Renderer>().material.color = new Color(0 / 255f, 0 / 255f, 170 / 255f, currentTime * 0.33f);

            // Z
            if (child.name == "Side" && gameObject.name == "Z_Mino(Clone)")
                child.gameObject.GetComponent<Renderer>().material.color = new Color(255 / 255f, 0 / 255f, 0 / 255f, currentTime * 0.33f);

            if (child.name == "Border" && gameObject.name == "Z_Mino(Clone)")
                child.gameObject.GetComponent<Renderer>().material.color = new Color(170 / 255f, 0 / 255f, 0 / 255f, currentTime * 0.33f);

            // S
            if (child.name == "Side" && gameObject.name == "S_Mino(Clone)")
                child.gameObject.GetComponent<Renderer>().material.color = new Color(0 / 255f, 255 / 255f, 0 / 255f, currentTime * 0.33f);

            if (child.name == "Border" && gameObject.name == "S_Mino(Clone)")
                child.gameObject.GetComponent<Renderer>().material.color = new Color(0 / 255f, 170 / 255f, 0 / 255f, currentTime * 0.33f);
        }
    }


    // 설치전 그림자가 플레이어를 따라다닌다.
    void Move()
    {
        if (bt.bag[bt.currntNum] == 1 && gameObject.name == "I_MinoBulr")
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed);
        }
        else if (bt.bag[bt.currntNum] != 1 && gameObject.name == "I_MinoBulr")
        {
            transform.position = new Vector3(0, -2, 0);
        }

        if (bt.bag[bt.currntNum] == 2 && gameObject.name == "O_MinoBulr")
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed);
        }
        else if (bt.bag[bt.currntNum] != 2 && gameObject.name == "O_MinoBulr")
        {
            transform.position = new Vector3(0, -2, 0);
        }


        if (bt.bag[bt.currntNum] == 3 && gameObject.name == "T_MinoBulr")
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed);
        }
        else if (bt.bag[bt.currntNum] != 3 && gameObject.name == "T_MinoBulr")
        {
            transform.position = new Vector3(0, -2, 0);
        }


        if (bt.bag[bt.currntNum] == 4 && gameObject.name == "L_MinoBulr")
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed);
        }
        else if (bt.bag[bt.currntNum] != 4 && gameObject.name == "L_MinoBulr")
        {
            transform.position = new Vector3(0, -2, 0);
        }


        if (bt.bag[bt.currntNum] == 5 && gameObject.name == "J_MinoBulr")
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed);
        }
        else if (bt.bag[bt.currntNum] != 5 && gameObject.name == "J_MinoBulr")
        {
            transform.position = new Vector3(0, -2, 0);
        }


        if (bt.bag[bt.currntNum] == 6 && gameObject.name == "Z_MinoBulr")
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed);
        }
        else if (bt.bag[bt.currntNum] != 6 && gameObject.name == "Z_MinoBulr")
        {
            transform.position = new Vector3(0, -2, 0);
        }


        if (bt.bag[bt.currntNum] == 7 && gameObject.name == "S_MinoBulr")
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed);
        }
        else if (bt.bag[bt.currntNum] != 7 && gameObject.name == "S_MinoBulr")
        {
            transform.position = new Vector3(0, -2, 0);
        }


    }
}
