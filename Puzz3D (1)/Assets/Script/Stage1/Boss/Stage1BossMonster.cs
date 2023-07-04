using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1BossMonster : ObjectCheck
{
    Stage1BossManager bossmanager;

    public bool inputDamage = false;

    float currentTime;
    float inputDamageDeley;
    void Start()
    {
        mapmanager = FindObjectOfType<Mapmanager>();
        bossmanager = FindObjectOfType< Stage1BossManager>();
        

        inputDamageDeley = 1.5f;

        objPos = this.gameObject.transform.position;

        if (objPos.y >= 0)
        {
            current_x = (int)objPos.x + 5;
            current_z = (int)objPos.z + 5;
            current_y = (int)objPos.y;
            InputMap();
        }
    }

    // Update is called once per frame
    void Update()
    {
        objPos = this.gameObject.transform.position;

        if (mapmanager.battleStart == true)
        {
            PositionSet();
            Damage();
        }
    }

    void Damage()
    {
        if (mapmanager.map[current_x, current_z, current_y, 0] == 6 && inputDamage == false)
        {
            Debug.Log("À¸¾Ç!");
            bossmanager.HP--;
            inputDamage = true;
        }

        if (inputDamage == true)
        {
            currentTime += Time.deltaTime;

            if (currentTime > inputDamageDeley)
            {
                inputDamage = false;
                currentTime = 0;
            }
        }
    }

}
