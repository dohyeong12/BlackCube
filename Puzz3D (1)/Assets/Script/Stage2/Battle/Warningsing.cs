using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warningsing : MonoBehaviour
{
    S2BattleScript bt;

    //attackArea

    void Start()
    {
        bt = FindObjectOfType<S2BattleScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.K))
            Destroy(gameObject);
    }

    private void Move()
    {
        if (bt.attackArea == 2)
        {
            if (gameObject.name == "In Warning sign")
            {
                transform.position = new Vector3(18, 0, 12.5f);
                transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            else
            {
                transform.position = new Vector3(0, -2, 0);
            }
        }
        if (bt.attackArea == 3)
        {
            if (gameObject.name == "In Warning sign")
            {
                transform.position = new Vector3(15.5f, 0, 7);
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
                transform.position = new Vector3(0, -2, 0);
        }
        if (bt.attackArea == 4)
        {
            if (gameObject.name == "In Warning sign")
            {
                transform.position = new Vector3(10, 0, 9.5f);
                transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            else
                transform.position = new Vector3(0, -2, 0);
        }
        if (bt.attackArea == 5)
        {
            if (gameObject.name == "In Warning sign")
            {
                transform.position = new Vector3(12.5f, 0, 15);
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
                transform.position = new Vector3(0, -2, 0);
        }

        if (bt.attackArea == 6)
        {
            if (gameObject.name == "Out1 Warning sign")
            {
                transform.position = new Vector3(19, 0, 12);
                transform.rotation = Quaternion.Euler(0,180, 0);
            }
            else
                transform.position = new Vector3(0, -2, 0);
        }
        if (bt.attackArea == 7)
        {
            if (gameObject.name == "Out1 Warning sign")
            {
                transform.position = new Vector3(9, 0, 10);
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
                transform.position = new Vector3(0, -2, 0);
        }

        if (bt.attackArea == 8)
        {
            if (gameObject.name == "Out2 Warning sign")
                transform.position = new Vector3(16.5f, 0, 4.5f);
            else
                transform.position = new Vector3(0, -2, 0);
        }
        if (bt.attackArea == 9)
        {
            if (gameObject.name == "Out2 Warning sign")
                transform.position = new Vector3(11.5f, 0, 17.5f);
            else
                transform.position = new Vector3(0, -2, 0);
        }
    }

}
