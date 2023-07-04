using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPos : MonoBehaviour
{
    public Mapmanager mapmanager;

    public int current_x;
    public int current_z;
    public Vector3 objPos;
    public float objType;

    void Start()
    {
        mapmanager = FindObjectOfType<Mapmanager>();
        objPos = this.gameObject.transform.position;

        current_x = (int)objPos.x + 5;
        current_z = (int)objPos.z + 5;

        SettingPos();
    }


    void Update()
    {
        if (current_x != (int)objPos.x + 5 || current_z != (int)objPos.z + 5) 
            ResetPos();
    }


    void SettingPos()
    {
        if (gameObject.CompareTag("Rock") || gameObject.CompareTag("Wall"))
        {
            mapmanager.map[(int)objPos.x + 5, (int)objPos.z + 5, 0, 0] = 1;
            objType = mapmanager.map[(int)objPos.x + 5, (int)objPos.z + 5, 0, 0];
            //Debug.Log(current_x + ", " + current_z + ", " + 0 + ": '" + objType + "' ");
        }
    }


    void ResetPos()
    {
        SettingPos();

        current_x = (int)objPos.x + 5;
        current_z = (int)objPos.z + 5;
    }
}
