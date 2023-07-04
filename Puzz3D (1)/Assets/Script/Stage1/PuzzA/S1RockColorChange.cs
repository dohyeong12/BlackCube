using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S1RockColorChange : MonoBehaviour
{
    S1PuzzManager puzzmanager;

    Transform[] myChildren;

    void Start()
    {
        puzzmanager = FindObjectOfType<S1PuzzManager>();

        myChildren = this.GetComponentsInChildren<Transform>();

        if (gameObject.CompareTag("Rock"))
        {
            foreach (Transform child in myChildren)
            {
                if (child.CompareTag("RockBody"))
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(255 / 255f, 255 / 255f, 255/ 255f);
                }
                else if (child.CompareTag("RockBorder"))
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(170 / 255f, 170 / 255f, 170 / 255f);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Stage_1") ChangeColor();
    }

    void ChangeColor()
    {
        if (gameObject.name == "Rock (1)" && puzzmanager.inputCnt_A == 1)
        {
            foreach (Transform child in myChildren)
            {
                if (child.CompareTag("RockBody"))
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(255 / 255f, 0 / 255f, 0 / 255f);
                }
                else if (child.CompareTag("RockBorder"))
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(185 / 255f, 0 / 255f, 0 / 255f);
                }
            }
        }
        if (gameObject.name == "Rock (2)" && puzzmanager.inputCnt_A == 2)
        {
            foreach (Transform child in myChildren)
            {
                if (child.CompareTag("RockBody"))
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(255 / 255f, 95 / 255f, 0 / 255f);
                }
                else if (child.CompareTag("RockBorder"))
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(185 / 255f, 70 / 255f, 0 / 255f);
                }
            }
        }
        if (gameObject.name == "Rock (3)" && puzzmanager.inputCnt_A == 3)
        {
            foreach (Transform child in myChildren)
            {
                if (child.CompareTag("RockBody"))
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(255 / 255f, 170 / 255f, 0 / 255f);
                }
                else if (child.CompareTag("RockBorder"))
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(185 / 255f, 123 / 255f, 0 / 255f);
                }
            }
        }
        if (gameObject.name == "Rock (4)" && puzzmanager.inputCnt_A == 4)
        {
            foreach (Transform child in myChildren)
            {
                if (child.CompareTag("RockBody"))
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(255 / 255f, 245 / 255f, 0 / 255f);
                }
                else if (child.CompareTag("RockBorder"))
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(185 / 255f, 177 / 255f, 0 / 255f);
                }
            }
        }
        if (gameObject.name == "Rock (5)" && puzzmanager.inputCnt_A == 5)
        {
            foreach (Transform child in myChildren)
            {
                if (child.CompareTag("RockBody"))
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(168 / 255f, 255 / 255f, 0 / 255f);
                }
                else if (child.CompareTag("RockBorder"))
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(122 / 255f, 185 / 255f, 0 / 255f);
                }
            }
        }
        if (gameObject.name == "Rock (6)" && puzzmanager.inputCnt_A == 6)
        {
            foreach (Transform child in myChildren)
            {
                if (child.CompareTag("RockBody"))
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(115 / 255f, 255 / 255f, 0 / 255f);
                }
                else if (child.CompareTag("RockBorder"))
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(83 / 255f, 185 / 255f, 0 / 255f);
                }
            }
        }
        if (gameObject.name == "Rock (7)" && puzzmanager.inputCnt_A == 7)
        {
            foreach (Transform child in myChildren)
            {
                if (child.CompareTag("RockBody"))
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(0 / 255f, 255 / 255f, 95 / 255f);
                }
                else if (child.CompareTag("RockBorder"))
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(0 / 255f, 185 / 255f, 70 / 255f);
                }
            }
        }
        if (gameObject.name == "Rock (8)" && puzzmanager.inputCnt_A == 8)
        {
            foreach (Transform child in myChildren)
            {
                if (child.CompareTag("RockBody"))
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(0 / 255f, 255 / 255f, 160 / 255f);
                }
                else if (child.CompareTag("RockBorder"))
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(0 / 255f, 185 / 255f, 115 / 255f);
                }
            }
        }
        if (gameObject.name == "Rock (9)" && puzzmanager.inputCnt_A == 9)
        {
            foreach (Transform child in myChildren)
            {
                if (child.CompareTag("RockBody"))
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(0 / 255f, 255 / 255f, 255 / 255f);
                }
                else if (child.CompareTag("RockBorder"))
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(0 / 255f, 185 / 255f, 185 / 255f);
                }
            }
        }
        if (gameObject.name == "Rock (10)" && puzzmanager.inputCnt_A == 10)
        {
            foreach (Transform child in myChildren)
            {
                if (child.CompareTag("RockBody"))
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(0 / 255f, 200 / 255f, 255 / 255f);
                }
                else if (child.CompareTag("RockBorder"))
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(0 / 255f, 145 / 255f, 185 / 255f);
                }
            }
        }
        if (gameObject.name == "Rock (11)" && puzzmanager.inputCnt_A == 11)
        {
            foreach (Transform child in myChildren)
            {
                if (child.CompareTag("RockBody"))
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(0 / 255f, 100 / 255f, 255 / 255f);
                }
                else if (child.CompareTag("RockBorder"))
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(0 / 255f, 73 / 255f, 185 / 255f);
                }
            }
        }
        if (gameObject.name == "Rock (12)" && puzzmanager.inputCnt_A == 12)
        {
            foreach (Transform child in myChildren)
            {
                if (child.CompareTag("RockBody"))
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(32 / 255f, 0 / 255f, 255 / 255f);
                }
                else if (child.CompareTag("RockBorder"))
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(25 / 255f, 0 / 255f, 185 / 255f);
                }
            }
        }
        if (gameObject.name == "Rock (13)" && puzzmanager.inputCnt_A == 13)
        {
            foreach (Transform child in myChildren)
            {
                if (child.CompareTag("RockBody"))
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(128 / 255f, 0 / 255f, 255 / 255f);
                }
                else if (child.CompareTag("RockBorder"))
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(95 / 255f, 0 / 255f, 185 / 255f);
                }
            }
        }
        if (gameObject.name == "Rock (14)" && puzzmanager.inputCnt_A == 14)
        {
            foreach (Transform child in myChildren)
            {
                if (child.CompareTag("RockBody"))
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(225 / 255f, 0 / 255f, 255 / 255f);
                }
                else if (child.CompareTag("RockBorder"))
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(164 / 255f, 0 / 255f, 185 / 255f);
                }
            }
        }
        if (gameObject.name == "Rock (15)" && puzzmanager.inputCnt_A == 15)
        {
            foreach (Transform child in myChildren)
            {
                if (child.CompareTag("RockBody"))
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(255 / 255f, 0 / 255f, 190 / 255f);
                }
                else if (child.CompareTag("RockBorder"))
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(185 / 255f, 0 / 255f, 140 / 255f);
                }
            }
        }
        if (gameObject.name == "Rock (16)" && puzzmanager.inputCnt_A == 17)
        {
            foreach (Transform child in myChildren)
            {
                if (child.CompareTag("RockBody"))
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(255 / 255f, 0 / 255f, 95 / 255f);
                }
                else if (child.CompareTag("RockBorder"))
                {
                    child.gameObject.GetComponent<Renderer>().material.color = new Color(185 / 255f, 0 / 255f, 70 / 255f);
                }
            }
        }
        
    }
}
