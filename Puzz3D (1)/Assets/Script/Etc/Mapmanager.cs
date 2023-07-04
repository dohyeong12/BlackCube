using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mapmanager : MonoBehaviour
{
    public Vector3 Pos;
    public Animator anim;

    [Header ("��")]
    public float[,,,] map;
    public int map_x;
    public int map_z;
    public int map_y;
    public int map_kind; //0 : �̵�, 1: ����

    [Header("�÷��̾� ��ǥ")]
    public int player_x = 0;
    public int player_z = 0;
    public int player_y = 0;

    [Header("�÷��̾� �̵�")]
    float moveCurrentTime;
    float autoMoveDeley = 0.3f;
    [SerializeField] int input_cnt = 0;
    public bool moveStop = false;
    public int moveType = 0; // 1:�� | 2:�Ʒ� | 3:�� | 4:��

    [Header("�÷��̾� ����")]
    [SerializeField] float HP = 100;
    float damageDeley = 0.15f;
    public float damageTime = 0;
    public bool haveBullet;
    public GameObject Bulletobj;

    [Header("�������� ����")]
    public bool puzzStart = false;
    public bool puzzClear = false;
    public bool battleStart = false;
    public bool stageClear = false;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (SceneManager.GetActiveScene().name == "Stage_1")
        {
            map_x = 37;
            map_z = 21;
            map_y = 5;
        }
        if (SceneManager.GetActiveScene().name == "Stage_2")
        {
            map_x = 38;
            map_z = 33;
            map_y = 5;
        }

        map = new float[map_x, map_z, map_y, 2];
    }
    void Start()
    {
        damageDeley = 0.15f;

        puzzStart = false;
        puzzClear = false;
        battleStart = false;
        stageClear = false;

        moveStop = false; 
        
        if (SceneManager.GetActiveScene().name == "Stage_1")
        {
            transform.position = new Vector3(0, 0, 0);
            player_x = 5;
            player_z = 5;
            player_y = 0;
        }
        if (SceneManager.GetActiveScene().name == "Stage_2")
        {
            transform.position = new Vector3(14, 0, 1);
            player_x = 19;
            player_z = 6;
            player_y = 0;
        }
    }

    // Update is called once per frame  
    void Update()
    {
        if (input_cnt == 0)
        {
            anim.SetBool("Run", false);
            anim.SetBool("Walk", false);
            anim.SetBool("Idle", true);
        }
        else if (input_cnt == 1)
        {
            anim.SetBool("Idle", false);
            anim.SetBool("Walk", true);
            anim.SetBool("Run", false);
        }
        else if (input_cnt >= 2)
        {
            anim.SetBool("Idle", false);
            anim.SetBool("Walk", false);
            anim.SetBool("Run", true);
        }

        Pos = this.gameObject.transform.position;
        if (moveStop == false)
            PlayerControl();

        if (stageClear == true && Input.GetKeyDown(KeyCode.Space) && SceneManager.GetActiveScene().name != "Stage_2") // "Stage_2"�� ���� ������ ��ü�� ����
        {
            stageClear = false;
            ChangeScene();
        }

        MapEvent();
        StartCoroutine(PlayerManagement());
        BulletShootScript();


    }

    void ChangeScene()
    {
        if (SceneManager.GetActiveScene().name == "Stage_1")
        {
            map_x = 38;
            map_z = 33;
            map_y = 5;

            map = new float[map_x, map_z, map_y, 0];

            player_x = 19;
            player_z = 5;
            player_y = 0;
            transform.position = new Vector3(14, 0, 1);
            SceneManager.LoadScene("Stage_2");
        }
    }

    void MapEvent()
    {
        if (SceneManager.GetActiveScene().name == "Stage_1")
        { 
            // x == 12 : �÷��̾ ���� ������ ���� 
            if (puzzStart == false && player_x == 22)
                puzzStart = true;

            // x,z==2 : �÷��̾ Ű�� �ִ� Ÿ�Ͽ� ���� ��
            if (map[player_x, player_z, player_y, 0] == 2)
                puzzClear = true;

            // x,z==3 : �÷��̾ ���Ͱ� �ִ� Ÿ�Ͽ� ���� �� : �з�������.
            if (map[player_x, player_z,player_y, 0] == 3)
            {
                moveStop = true;
                damageTime += Time.deltaTime;
                if (damageTime >= damageDeley)
                {
                    damageTime = 0;
                    HP--;
                    moveStop = false;
                    if (moveType == 1)
                    {
                        transform.position += new Vector3(0, 0, -1);
                        player_z--;
                    }
                    if (moveType == 2)
                    {
                        transform.position += new Vector3(0, 0, 1);
                        player_z++;
                    }
                    if (moveType == 3)
                    {
                        transform.position += new Vector3(1, 0, 0);
                        player_x++;
                    }
                    if (moveType == 4)
                    {
                        transform.position += new Vector3(-1, 0, 0);
                        player_x--;
                    }
                }

            }
            else if (map[player_x, player_z, player_y, 0] != 3)
            {
                damageTime = 0;
            }

            // x,z==4 : �÷��̾ ������ ���� ������ ������
            // ȿ���� �� �߰� ����
            if (map[player_x, player_z, player_y, 0] == 4)
            {
                Debug.Log("�÷��̾ ���� ������ �ֽ��ϴ�.! ����!! ");
            }

            // x,z == 5 : �÷��̾ bullet�� �ִ� ��ǥ�� ������ && Bullet�� �������� ���� ��
            // ȿ����, ����Ʈ
            if (map[player_x, player_z, player_y, 0] == 5 && haveBullet == false)
            {
            }
        }
    }
    void BulletShootScript()
    {
        if (SceneManager.GetActiveScene().name == "Stage_1" && haveBullet == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(Bulletobj, new Vector3(Pos.x, Pos.y, Pos.z), Quaternion.identity);
                map[player_x, player_z, player_y, 0] = 6;
                haveBullet = false;
                Debug.Log(1);
            }
        }
    }

    public void PlayerControl()
    {
        // ���� �̵�
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow)) { }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            ChangeMoveDeley();
            if (player_z < map_z-6 && map[player_x, player_z + 1, player_y, 0] != 1  && moveCurrentTime >= autoMoveDeley)
            {
                transform.position += new Vector3(0, 0, 1);
                player_z++;
                moveType = 1;
                moveCurrentTime = 0;
                input_cnt++;
            }
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            anim.SetTrigger("Idle");
            input_cnt = 0;
        }

        // �Ʒ��� �̵�
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) { }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            ChangeMoveDeley();
            if (player_z > 5 && map[player_x, player_z - 1, player_y, 0] != 1 && moveCurrentTime >= autoMoveDeley)
            {
                transform.position += new Vector3(0, 0, -1f);
                player_z--;
                moveType = 2;
                moveCurrentTime = 0;
                input_cnt++;
            }
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            anim.SetTrigger("Idle");
            input_cnt = 0;
        }

        // �������� �̵�
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow)) { }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            ChangeMoveDeley();
            if (player_x > 5 && map[player_x - 1, player_z, player_y, 0] != 1 && moveCurrentTime >= autoMoveDeley)
            {
                transform.position += new Vector3(-1, 0, 0);
                player_x--;
                moveType = 3;
                moveCurrentTime = 0;
                input_cnt++;
            }
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            anim.SetTrigger("Idle");
            input_cnt = 0;
        }

        // ���������� �̵�
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow)) { }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            ChangeMoveDeley();
            if (player_x < map_x-5 && map[player_x + 1, player_z, player_y, 0] != 1 && moveCurrentTime >= autoMoveDeley)
            {
                transform.position += new Vector3(1, 0, 0);
                player_x++;
                moveType = 4;
                moveCurrentTime = 0;
                input_cnt++;
            }
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            anim.SetTrigger("Idle");
            input_cnt = 0;
        }
    }

    // �̵� ������ : �̹� �̵� �� ���� �̵��� �����̸� ���� 
    void ChangeMoveDeley()
    {
        moveCurrentTime += Time.deltaTime;

        if (input_cnt <= 0)
        {
            anim.SetTrigger("Idle");
            autoMoveDeley = 0;
        }
        else if (input_cnt <= 1f)
        {
            anim.SetTrigger("Walk");
            autoMoveDeley = 0.5f;
        }
        else if (input_cnt >= 2)
        {
            anim.SetTrigger("Run");
            autoMoveDeley = 0.07f;
        }
    }

    IEnumerator PlayerManagement()
    {
        // 1�������� ���� ī�޶� �����϶� �÷��̾� ����
        if (puzzClear == true && battleStart == false &&  ( ( player_x==27 && player_z==14 ) || ( player_x == 31 && player_z == 10) || (player_x == 27 && player_z == 6) || (player_x == 23 && player_z == 10) )  )
        {
            if (player_x == 31 && player_z == 10)
            {
                moveStop = true;
                yield return new WaitForSeconds(1.7f);
                battleStart = true;
                moveStop = false;
            }
            else
            {
                moveStop = true;
                yield return new WaitForSeconds(1);
                battleStart = true;
                moveStop = false;
            }
        }
    }
}
