using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S2PuzzCKeyScript : MonoBehaviour
{
    public Vector3 Pos;
    public bool keymove = false;

    Mapmanager mapmanager;
    S2PuzzManager pz;

    void Start()
    {
        mapmanager = FindObjectOfType<Mapmanager>();
        pz = FindObjectOfType<S2PuzzManager>();

    }

    // Update is called once per frame
    void Update()
    {
        Pos = this.gameObject.transform.position;

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

            if (Pos.y > 0.2f)
                keymove = true;
            if (Pos.y <= 0)
                keymove = false;
        }
    }

    void KeyDes()
    {
        if (mapmanager.Pos.x == Pos.x && mapmanager.Pos.z == Pos.z)
        {
            pz.havePuzzCkey = true;
            Destroy(gameObject);
        }
    }
}
