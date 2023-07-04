using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1PlayerBullet : ObjectCheck
{
    float currentTime;
    float destroyDeley = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        mapmanager = FindObjectOfType<Mapmanager>();
        objPos = this.gameObject.transform.position;

        destroyDeley = 1.4f;

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

    // Update is called once per frame
    void Update()
    {
        PositionSet();
        BulletDes();
    }

    void BulletDes()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= destroyDeley)
        {
            Destroy(gameObject);
        }
    }
}
