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
        if (outmino > 6) // 블럭이  7개 이상 나오면 가방을 비운다.
        {
            clearbag();
            outmino = 0; // 나온 블럭개수를 0으로 초기화
        }
        if (standby == false)
        {
            if (outmino <= 6)// 블럭이 7개 미만으로 나올때
            {
                bagCheck(); // 현재 나올 블럭이 가방에 저장되어있는지 확인한다.

                if (cut != 0) // 나온적이 있으면
                {
                    minoNumber = Random.Range(1, 8);// 새로운 블럭을 꺼낸다.
                    cut = 0; // 개수 0 초기화
                }
                else // 나온적이 없으면
                {
                    bag[sum] = minoNumber; //가방에 나온 블럭을 저장한다.
                    sum++;
                    Instantiate(Mino[minoNumber], transform.position, Quaternion.identity); // 블럭을 소환한다.
                    minoNumber = Random.Range(1, 8); // 새로운 블럭을 꺼낸다.
                    standby = true;
                    outmino++; //나온 블럭개수를 하나 더한다.
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
