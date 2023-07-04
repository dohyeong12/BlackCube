using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzTileSpawn : MonoBehaviour
{
    S1PuzzManager puzzmanager;

    Transform[] myChildren;

    void Start()
    {
        puzzmanager = FindObjectOfType<S1PuzzManager>();
        myChildren = this.GetComponentsInChildren<Transform>();

        Spawncolor();
    }

    // Update is called once per frame
    void Update()
    {
        Spawntile();
    }
    void Spawncolor()
    {
        foreach (Transform child in myChildren)
        {
            if (child.name == "PuzzTile (2)")
            {
                child.GetComponent<Renderer>().material.color = new Color(255 / 255f, 95 / 255f, 0 / 255f);
            }
            if (child.name == "PuzzTile (3)")
            {
                child.GetComponent<Renderer>().material.color = new Color(255 / 255f, 170 / 255f, 0 / 255f);
            }
            if (child.name == "PuzzTile (4)")
            {
                child.GetComponent<Renderer>().material.color = new Color(255 / 255f, 245 / 255f, 0 / 255f);
            }
            if (child.name == "PuzzTile (5)")
            {
                child.GetComponent<Renderer>().material.color = new Color(168 / 255f, 255 / 255f, 0 / 255f);
            }
            if (child.name == "PuzzTile (6)")
            {
                child.GetComponent<Renderer>().material.color = new Color(115 / 255f, 255 / 255f, 0 / 255f);
            }
            if (child.name == "PuzzTile (7)")
            {
                child.GetComponent<Renderer>().material.color = new Color(0 / 255f, 255 / 255f, 95 / 255f);
            }
            if (child.name == "PuzzTile (8)")
            {
                child.GetComponent<Renderer>().material.color = new Color(0 / 255f, 255 / 255f, 160 / 255f);
            }
            if (child.name == "PuzzTile (9)")
            {
                child.GetComponent<Renderer>().material.color = new Color(0 / 255f, 255 / 255f, 255 / 255f);
            }
            if (child.name == "PuzzTile (10)")
            {
                child.GetComponent<Renderer>().material.color = new Color(0 / 255f, 200 / 255f, 255 / 255f);
            }
            if (child.name == "PuzzTile (11)")
            {
                child.GetComponent<Renderer>().material.color = new Color(0 / 255f, 100 / 255f, 255 / 255f);
            }
            if (child.name == "PuzzTile (12)")
            {
                child.GetComponent<Renderer>().material.color = new Color(32 / 255f, 0 / 255f, 255 / 255f);
            }
            if (child.name == "PuzzTile (13)")
            {
                child.GetComponent<Renderer>().material.color = new Color(128 / 255f, 0 / 255f, 255 / 255f);
            }
            if (child.name == "PuzzTile (14)")
            {
                child.GetComponent<Renderer>().material.color = new Color(255 / 255f, 0 / 255f, 255 / 255f);
            }
            if (child.name == "PuzzTile (15)")
            {
                child.GetComponent<Renderer>().material.color = new Color(255 / 255f, 0 / 255f, 190 / 255f);
            }
        }
    }

    void Spawntile()
    {
        foreach (Transform child in myChildren)
        {
            if (child.name == "PuzzTile (2)" && puzzmanager.inputCnt_A == 2)
            {
                child.gameObject.transform.position = new Vector3(20, -0.499f, 1);
            }
            if (child.name == "PuzzTile (3)" && puzzmanager.inputCnt_A == 3)
            {
                child.gameObject.transform.position = new Vector3(18, -0.499f, 3);
            }
            if (child.name == "PuzzTile (4)" && puzzmanager.inputCnt_A == 4)
            {
                child.gameObject.transform.position = new Vector3(18, -0.499f, 4);
            }
            if (child.name == "PuzzTile (5)" && puzzmanager.inputCnt_A == 5)
            {
                child.gameObject.transform.position = new Vector3(18, -0.499f, 6);
            }
            if (child.name == "PuzzTile (6)" && puzzmanager.inputCnt_A == 6)
            {
                child.gameObject.transform.position = new Vector3(18, -0.499f, 7);
            }
            if (child.name == "PuzzTile (7)" && puzzmanager.inputCnt_A == 7)
            {
                child.gameObject.transform.position = new Vector3(20, -0.499f, 9);
            }
            if (child.name == "PuzzTile (8)" && puzzmanager.inputCnt_A == 8)
            {
                child.gameObject.transform.position = new Vector3(21, -0.499f, 9);
            }
            if (child.name == "PuzzTile (9)" && puzzmanager.inputCnt_A == 9)
            {
                child.gameObject.transform.position = new Vector3(23, -0.499f, 9);
            }
            if (child.name == "PuzzTile (10)" && puzzmanager.inputCnt_A == 10)
            {
                child.gameObject.transform.position = new Vector3(24, -0.499f, 9);
            }
            if (child.name == "PuzzTile (11)" && puzzmanager.inputCnt_A == 11)
            {
                child.gameObject.transform.position = new Vector3(26, -0.499f, 7);
            }
            if (child.name == "PuzzTile (12)" && puzzmanager.inputCnt_A == 12)
            {
                child.gameObject.transform.position = new Vector3(26, -0.499f, 6);
            }
            if (child.name == "PuzzTile (13)" && puzzmanager.inputCnt_A == 13)
            {
                child.gameObject.transform.position = new Vector3(26, -0.499f, 4);
            }
            if (child.name == "PuzzTile (14)" && puzzmanager.inputCnt_A == 14)
            {
                child.gameObject.transform.position = new Vector3(26, -0.499f, 3);
            }
            if (child.name == "PuzzTile (15)" && puzzmanager.inputCnt_A == 15)
            {
                child.gameObject.transform.position = new Vector3(24, -0.499f, 1);
            }
        }
        
        
        foreach (Transform child in myChildren)
        {
            if(puzzmanager.inputCnt_A == 17)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
