using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    Mapmanager mapmanager;
    [SerializeField] Vector3 Pos;


    bool move = false;

    void Start()
    {
        mapmanager = FindObjectOfType<Mapmanager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mapmanager.puzzClear == true && move == false) spawn();



    }

    void spawn()
    {
        transform.position += new Vector3(0, 2, 0);
        move = true;
    }
}
