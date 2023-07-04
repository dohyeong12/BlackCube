using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzAScript : MonoBehaviour
{
    public Mapmanager mapmanager;

    Renderer Color;
    Transform[] myChildren;

    public int[] puzzA;

    void Start()
    {
        myChildren = this.GetComponentsInChildren<Transform>();

        mapmanager = FindObjectOfType<Mapmanager>();
        Color = gameObject.GetComponent<Renderer>();
        puzzA = new int[16];
    }


    void Update()
    {
        if (puzzA[0] != 1 && mapmanager.player_x == 26 && mapmanager.player_z == 6)
        {
            puzzA[0] = 1;

            foreach (Transform child in myChildren)
            {
                if (gameObject.name == "Rock (1)")
                {
                    Debug.Log(1);
                    if (child.CompareTag("RockBody"))
                        child.gameObject.GetComponent<Renderer>().material.color = new Color(255 / 255f, 0 / 255f, 0 / 255f);
                    else if (child.CompareTag("RockBorder"))
                        child.gameObject.GetComponent<Renderer>().material.color = new Color(185 / 255f, 0 / 255f, 0 / 255f);
                }
            }
        }

        if (puzzA[0] == 1 && puzzA[1] != 1 && mapmanager.player_x == 25 && mapmanager.player_z == 6)
        {
            puzzA[1] = 1;

            foreach (Transform child in myChildren)
            {
                if (child.name == "PuzzTile (2)")
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(255 / 255f, 95 / 255f, 0 / 255f);
                    child.gameObject.GetComponent<Renderer>().transform.position = new Vector3(20, -0.49f, 1);
                }

                if (gameObject.name == "Rock (2)")
                {
                    if (child.CompareTag("RockBody"))
                        child.gameObject.GetComponent<Renderer>().material.color = new Color(255 / 255f, 95 / 255f, 0 / 255f);

                    else if (child.CompareTag("RockBorder"))
                        child.gameObject.GetComponent<Renderer>().material.color = new Color(185 / 255f, 70 / 255f, 0 / 255f);
                }
            }
        }

        if (puzzA[1] == 1 && puzzA[2] != 1 && mapmanager.player_x == 23 && mapmanager.player_z == 8)
        {
            puzzA[2] = 1;

            foreach (Transform child in myChildren)
            {
                if (child.name == "PuzzTile (3)")
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(255 / 255f, 170 / 255f, 0 / 255f);
                    child.gameObject.GetComponent<Renderer>().transform.position = new Vector3(18, -0.49f, 3);
                }

                if (gameObject.name == "Rock (3)")
                {
                    if (child.CompareTag("RockBody"))
                        child.gameObject.GetComponent<Renderer>().material.color = new Color(255 / 255f, 170 / 255f, 0 / 255f);

                    else if (child.CompareTag("RockBorder"))
                        child.gameObject.GetComponent<Renderer>().material.color = new Color(185 / 255f, 123 / 255f, 0 / 255f);
                }
            }
        }

        if (puzzA[2] == 1 && puzzA[3] != 1 && mapmanager.player_x == 23 && mapmanager.player_z == 9)
        {
            puzzA[3] = 1;

            foreach (Transform child in myChildren)
            {
                if (child.name == "PuzzTile (4)")
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(255 / 255f, 245 / 255f, 0 / 255f);
                    child.gameObject.GetComponent<Renderer>().transform.position = new Vector3(18, -0.49f, 4);
                }

                if (gameObject.name == "Rock (4)")
                {
                    if (child.CompareTag("RockBody"))
                        child.gameObject.GetComponent<Renderer>().material.color = new Color(255 / 255f, 245 / 255f, 0 / 255f);

                    else if (child.CompareTag("RockBorder"))
                        child.gameObject.GetComponent<Renderer>().material.color = new Color(185 / 255f, 177 / 255f, 0 / 255f);
                }
            }
        }

        if (puzzA[3] == 1 && puzzA[4] != 1 && mapmanager.player_x == 23 && mapmanager.player_z == 11)
        {
            puzzA[4] = 1;

            foreach (Transform child in myChildren)
            {
                if (child.name == "PuzzTile (5)")
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(168 / 255f, 255 / 255f, 0 / 255f);
                    child.gameObject.GetComponent<Renderer>().transform.position = new Vector3(18, -0.49f, 6);
                }

                if (gameObject.name == "Rock (5)")
                {
                    if (child.CompareTag("RockBody"))
                        child.gameObject.GetComponent<Renderer>().material.color = new Color(168 / 255f, 255 / 255f, 0 / 255f);

                    else if (child.CompareTag("RockBorder"))
                        child.gameObject.GetComponent<Renderer>().material.color = new Color(122 / 255f, 185 / 255f, 0 / 255f);
                }
            }
        }

        if (puzzA[4] == 1 && puzzA[5] != 1 && mapmanager.player_x == 23 && mapmanager.player_z == 12)
        {
            puzzA[5] = 1;

            foreach (Transform child in myChildren)
            {
                if (child.name == "PuzzTile (6)")
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(115 / 255f, 255 / 255f, 0 / 255f);
                    child.gameObject.GetComponent<Renderer>().transform.position = new Vector3(18, -0.49f, 7);
                }

                if (gameObject.name == "Rock (6)")
                {
                    if (child.CompareTag("RockBody"))
                        child.gameObject.GetComponent<Renderer>().material.color = new Color(115 / 255f, 255 / 255f, 0 / 255f);

                    else if (child.CompareTag("RockBorder"))
                        child.gameObject.GetComponent<Renderer>().material.color = new Color(83 / 255f, 185 / 255f, 0 / 255f);
                }
            }
        }

        if (puzzA[5] == 1 && puzzA[6] != 1 && mapmanager.player_x == 25 && mapmanager.player_z == 14)
        {
            puzzA[6] = 1;

            foreach (Transform child in myChildren)
            {
                if (child.name == "PuzzTile (7)")
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(0 / 255f, 255 / 255f, 95 / 255f);
                    child.gameObject.GetComponent<Renderer>().transform.position = new Vector3(20, -0.49f, 9);
                }

                if (gameObject.name == "Rock (7)")
                {
                    if (child.CompareTag("RockBody"))
                        child.gameObject.GetComponent<Renderer>().material.color = new Color(0 / 255f, 255 / 255f, 95 / 255f);

                    else if (child.CompareTag("RockBorder"))
                        child.gameObject.GetComponent<Renderer>().material.color = new Color(0 / 255f, 185 / 255f, 70 / 255f);
                }
            }
        }

        if (puzzA[6] == 1 && puzzA[7] != 1 && mapmanager.player_x == 26 && mapmanager.player_z == 14)
        {
            puzzA[7] = 1;

            foreach (Transform child in myChildren)
            {
                if (child.name == "PuzzTile (8)")
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(0 / 255f, 255 / 255f, 160 / 255f);
                    child.gameObject.GetComponent<Renderer>().transform.position = new Vector3(21, -0.49f, 9);
                }

                if (gameObject.name == "Rock (8)")
                {
                    if (child.CompareTag("RockBody"))
                        child.gameObject.GetComponent<Renderer>().material.color = new Color(0 / 255f, 255 / 255f, 160 / 255f);

                    else if (child.CompareTag("RockBorder"))
                        child.gameObject.GetComponent<Renderer>().material.color = new Color(0 / 255f, 185 / 255f, 115 / 255f);
                }
            }
        }

        if (puzzA[7] == 1 && puzzA[8] != 1 && mapmanager.player_x == 28 && mapmanager.player_z == 14)
        {
            puzzA[8] = 1;

            foreach (Transform child in myChildren)
            {
                if (child.name == "PuzzTile (9)")
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(0 / 255f, 255 / 255f, 255 / 255f);
                    child.gameObject.GetComponent<Renderer>().transform.position = new Vector3(23, -0.49f, 9);
                }

                if (gameObject.name == "Rock (9)")
                {
                    if (child.CompareTag("RockBody"))
                        child.gameObject.GetComponent<Renderer>().material.color = new Color(0 / 255f, 255 / 255f, 255 / 255f);

                    else if (child.CompareTag("RockBorder"))
                        child.gameObject.GetComponent<Renderer>().material.color = new Color(0 / 255f, 185 / 255f, 185 / 255f);
                }
            }
        }

        if (puzzA[8] == 1 && puzzA[9] != 1 && mapmanager.player_x == 29 && mapmanager.player_z == 14)
        {
            puzzA[9] = 1;

            foreach (Transform child in myChildren)
            {
                if (child.name == "PuzzTile (10)")
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(0 / 255f, 200 / 255f, 255 / 255f);
                    child.gameObject.GetComponent<Renderer>().transform.position = new Vector3(24, -0.49f, 9);
                }

                if (gameObject.name == "Rock (10)")
                {
                    if (child.CompareTag("RockBody"))
                        child.gameObject.GetComponent<Renderer>().material.color = new Color(0 / 255f, 200 / 255f, 255 / 255f);

                    else if (child.CompareTag("RockBorder"))
                        child.gameObject.GetComponent<Renderer>().material.color = new Color(0 / 255f, 145 / 255f, 185 / 255f);
                }
            }
        }

        if (puzzA[9] == 1 && puzzA[10] != 1 && mapmanager.player_x == 31 && mapmanager.player_z == 12)
        {
            puzzA[10] = 1;

            foreach (Transform child in myChildren)
            {
                if (child.name == "PuzzTile (11)")
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(0 / 255f, 100 / 255f, 255 / 255f);
                    child.gameObject.GetComponent<Renderer>().transform.position = new Vector3(26, -0.49f, 7);
                }

                if (gameObject.name == "Rock (11)")
                {
                    if (child.CompareTag("RockBody"))
                        child.gameObject.GetComponent<Renderer>().material.color = new Color(0 / 255f, 100 / 255f, 255 / 255f);

                    else if (child.CompareTag("RockBorder"))
                        child.gameObject.GetComponent<Renderer>().material.color = new Color(0 / 255f, 73 / 255f, 185 / 255f);
                }
            }
        }

        if (puzzA[10] == 1 && puzzA[11] != 1 && mapmanager.player_x == 31 && mapmanager.player_z == 11)
        {
            puzzA[11] = 1;

            foreach (Transform child in myChildren)
            {
                if (child.name == "PuzzTile (12)")
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(32 / 255f, 0 / 255f, 255 / 255f);
                    child.gameObject.GetComponent<Renderer>().transform.position = new Vector3(26, -0.49f, 6);
                }

                if (gameObject.name == "Rock (12)")
                {
                    if (child.CompareTag("RockBody"))
                        child.gameObject.GetComponent<Renderer>().material.color = new Color(32 / 255f, 0 / 255f, 255 / 255f);

                    else if (child.CompareTag("RockBorder"))
                        child.gameObject.GetComponent<Renderer>().material.color = new Color(25 / 255f, 0 / 255f, 185 / 255f);
                }
            }
        }

        if (puzzA[11] == 1 && puzzA[12] != 1 && mapmanager.player_x == 31 && mapmanager.player_z == 9)
        {
            puzzA[12] = 1;

            foreach (Transform child in myChildren)
            {
                if (child.name == "PuzzTile (13)")
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(128 / 255f, 0 / 255f, 255 / 255f);
                    child.gameObject.GetComponent<Renderer>().transform.position = new Vector3(26, -0.49f, 4);
                }

                if (gameObject.name == "Rock (13)")
                {
                    if (child.CompareTag("RockBody"))
                        child.gameObject.GetComponent<Renderer>().material.color = new Color(128 / 255f, 0 / 255f, 255 / 255f);

                    else if (child.CompareTag("RockBorder"))
                        child.gameObject.GetComponent<Renderer>().material.color = new Color(95 / 255f, 0 / 255f, 185 / 255f);
                }
            }
        }

        if (puzzA[12] == 1 && puzzA[13] != 1 && mapmanager.player_x == 31 && mapmanager.player_z == 8)
        {
            puzzA[13] = 1;

            foreach (Transform child in myChildren)
            {
                if (child.name == "PuzzTile (14)")
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(225 / 255f, 0 / 255f, 255 / 255f);
                    child.gameObject.GetComponent<Renderer>().transform.position = new Vector3(26, -0.49f, 3);
                }

                if (gameObject.name == "Rock (14)")
                {
                    if (child.CompareTag("RockBody"))
                        child.gameObject.GetComponent<Renderer>().material.color = new Color(225 / 255f, 0 / 255f, 255 / 255f);

                    else if (child.CompareTag("RockBorder"))
                        child.gameObject.GetComponent<Renderer>().material.color = new Color(164 / 255f, 0 / 255f, 185 / 255f);
                }
            }
        }
        if (puzzA[13] == 1 && puzzA[14] != 1 && mapmanager.player_x == 29 && mapmanager.player_z == 6)
        {
            puzzA[14] = 1;

            foreach (Transform child in myChildren)
            {
                if (child.name == "PuzzTile (15)")
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(255 / 255f, 0 / 255f, 190 / 255f);
                    child.gameObject.GetComponent<Renderer>().transform.position = new Vector3(24, -0.49f, 1);
                }

                if (gameObject.name == "Rock (15)")
                {
                    if (child.CompareTag("RockBody"))
                        child.gameObject.GetComponent<Renderer>().material.color = new Color(255 / 255f, 0 / 255f, 190 / 255f);

                    else if (child.CompareTag("RockBorder"))
                        child.gameObject.GetComponent<Renderer>().material.color = new Color(185 / 255f, 0 / 255f, 140 / 255f);
                }
            }

        }
        if (puzzA[14] == 1 && puzzA[15] != 1 && mapmanager.player_x == 28 && mapmanager.player_z == 6)
        {
            puzzA[15] = 1;

            foreach (Transform child in myChildren)
            {
                if (gameObject.name == "Rock (16)")
                {
                    if (child.CompareTag("RockBody"))
                        child.gameObject.GetComponent<Renderer>().material.color = new Color(255 / 255f, 0 / 255f, 95 / 255f);

                    else if (child.CompareTag("RockBorder"))
                        child.gameObject.GetComponent<Renderer>().material.color = new Color(185 / 255f, 0 / 255f, 70 / 255f);
                }
            }

        }
    }
}
