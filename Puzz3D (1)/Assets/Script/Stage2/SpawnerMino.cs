using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMino : MonoBehaviour
{
    int[] bag = new int[7];
    public GameObject[] Mino; public int minoNumber;
    int outmino = 0;
    int cut = 0;
    int sum = 0;

    public bool standby = false;

    public static SpawnerMino instance;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            return;
        }
        else if (instance != null)
        {

            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        minoNumber = Random.Range(1, 8);
        for (int i = 0; i > 7; i++)
        {
            bag[i] = 0;
        }
    }
    // Update is called once per frame
    public void Update()
    {
        if (outmino > 6) // ����  7�� �̻� ������ ������ ����.
        {
            clearbag();
            outmino = 0; // ���� �������� 0���� �ʱ�ȭ
        }
        if (standby == false)
        {
            if (outmino <= 6)// ���� 7�� �̸����� ���ö�
            {
                bagCheck(); // ���� ���� ���� ���濡 ����Ǿ��ִ��� Ȯ���Ѵ�.

                if (cut != 0) // �������� ������
                {
                    minoNumber = Random.Range(1, 8);// ���ο� ���� ������.
                    cut = 0; // ���� 0 �ʱ�ȭ
                }
                else // �������� ������
                {
                    bag[sum] = minoNumber; //���濡 ���� ���� �����Ѵ�.
                    sum++;
                    Instantiate(Mino[minoNumber], transform.position, Quaternion.identity); // ���� ��ȯ�Ѵ�.
                    minoNumber = Random.Range(1, 8); // ���ο� ���� ������.
                    standby = true;
                    outmino++; //���� �������� �ϳ� ���Ѵ�.
                }
            }
        }
    }
    void bagCheck()
    {
        for (int i = 0; i < 7; i++)
        {
            if (bag[i] == minoNumber)
                cut++;
        }
        Debug.Log("cut : " + cut + " Mino : " + minoNumber);
    }
    void clearbag()
    {
        for (int i = 0; i < 7; i++)
        {
            bag[i] = 0;
            sum = 0;
        }
    }
}
