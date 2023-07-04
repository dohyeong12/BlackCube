using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearKeyScript : ObjectCheck
{
    void Start()
    {
        mapmanager = FindObjectOfType<Mapmanager>();
        objPos = this.gameObject.transform.position;

        if (objPos.y >= 0)
        {
            current_x = (int)objPos.x + 5;
            current_z = (int)objPos.z + 5;
            current_y = (int)objPos.y;
        }

        if (objPos.y >= 0)
        {
            InputMap();
        }

    }

    void Update()
    {
        objPos = this.gameObject.transform.position;

        PositionSet();
        KeyMove();
        KeyDes();
    }

    void KeyMove()
    {
        if (gameObject.CompareTag("Key"))
        {
            transform.Rotate(new Vector3(0, 95 * Time.deltaTime, 0));

            if (keymove == false)
                transform.position += new Vector3(0, 0.1f * Time.deltaTime, 0);
            else if (keymove == true)
                transform.position += new Vector3(0, -0.1f * Time.deltaTime, 0);

            if (objPos.y > 0.2f)
                keymove = true;
            if (objPos.y <= 0)
                keymove = false;
        }
    }

    void KeyDes()
    {
        if (mapmanager.player_x == current_x && mapmanager.player_z == current_z && mapmanager.player_y == current_y)
        {
            if (gameObject.CompareTag("Key"))
            {
                mapmanager.map[current_x, current_z, current_y, 0] = 0;
                Destroy(gameObject);
            }
        }
    }
}
