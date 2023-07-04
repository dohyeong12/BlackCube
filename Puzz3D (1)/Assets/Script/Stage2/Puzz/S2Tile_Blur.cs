using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S2Tile_Blur : MonoBehaviour
{
    S2PuzzManager pz;

    void Start()
    {
        pz = FindObjectOfType<S2PuzzManager>();
    }

    void Update()
    {
        if (pz.correctNum >= 12)
            Destroy(this.gameObject);
    }
}
