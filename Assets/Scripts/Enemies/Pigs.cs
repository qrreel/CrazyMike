using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pigs : MonoBehaviour
{
    public int Enemies;

    void Update()
    {
        Enemies = transform.childCount;
    }
}
