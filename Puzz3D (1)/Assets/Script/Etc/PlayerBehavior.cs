using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public bool move;
    float Time;
    public Animator anim;

    int a;

    void Start()
    {
        a = 1;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // 위로 이동
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow)) { }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            move = true;
        }

        // 아래로 이동
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) { }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            move = true;
        }

        // 왼쪽으로 이동
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow)) { }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0, 270, 0);
            move = true;
        }

        // 오른쪽으로 이동
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow)) { }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
            move = true;
        }


        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            StartCoroutine(IdelDeley());


        if (move == true && a == 1)
        {
            //anim.SetTrigger("Walk");
            a = 2;
        }
        if (move == false && a == 2)
        {
            //anim.SetTrigger("Idle");
            a = 1;
        }
    }

    IEnumerator IdelDeley()
    {
            yield return new WaitForSecondsRealtime(0.5f); move = false;
    }
}
