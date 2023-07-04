using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Camera : MonoBehaviour
{
    public Vector3 Pos;

    Mapmanager mapmanager;
    bool cameraMove = false;

    void Start()
    {
        mapmanager = FindObjectOfType<Mapmanager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Stage_1") Stage1();


        Pos = this.gameObject.transform.position;
    }


    void Stage1()
    {

        if (mapmanager.moveStop == true && mapmanager.battleStart == false)
        {
            //transform.position = Vector3.MoveTowards(transform.position, new Vector3(5, 3.75f, 1.025f), 1);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(7, 13.125f, -7f), 1);
            cameraMove = true;
        }

        if (mapmanager.moveStop == false && mapmanager.battleStart == true && cameraMove == true)
        {
            //transform.position = new Vector3(mapmanager.Pos.x, mapmanager.Pos.y+3.75f, mapmanager.Pos.z-3.75f);
            transform.position = new Vector3(mapmanager.Pos.x, mapmanager.Pos.y+13.125f, mapmanager.Pos.z-12f);
            //transform.position = Vector3.MoveTowards(transform.position, new Vector3(mapmanager.Pos.x, mapmanager.Pos.y + 13.125f, -12f), 1);
            cameraMove = false;
        }


    }
}



//transform.Translate(transform.position = new Vector3(mapmanager.Pos.x, mapmanager.Pos.y, mapmanager.Pos.z), Space.Self);
