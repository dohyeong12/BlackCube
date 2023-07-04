using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetCheak : ObjectCheck
{
    void Start()
    {
        mapmanager = FindObjectOfType<Mapmanager>();
        objPos = this.gameObject.transform.position;

        if (objPos.y >= 0)
        {
            current_x = (int)objPos.x + 5;
            current_z = (int)objPos.z + 5;
            current_y = (int)objPos.y + (int)0.5f;
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
    }
}
