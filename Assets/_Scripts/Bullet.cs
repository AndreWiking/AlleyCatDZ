using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float minX = 6.0f;

    private void Start()
    {
        Destroy(gameObject, 3f);
    }
}
