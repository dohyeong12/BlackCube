using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S2HintBlockScript : MonoBehaviour
{
    S2PuzzManager pz;
    public Vector3 Pos;

    void Start()
    {
        pz = FindObjectOfType<S2PuzzManager>();
        Pos = this.gameObject.transform.position;

    }

    void Update()
    {
        if (pz.puzzCClear == true)
        {
            if (pz.patternNum1 == 1 || pz.patternNum1 == 2)
                Destroy(this.gameObject);


            if (pz.patternNum1 >= 6 && pz.patternNum1 <= 9)
            {
                if (pz.patternNum2 == 1 && Pos.z == 10)
                {
                    Destroy(this.gameObject);
                }
                if (pz.patternNum2 == 2 && Pos.z == 5)
                {
                    Destroy(this.gameObject);
                }
            }
        }

    }
}
