using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    public bool IsOpen = false;

    public Sprite ClosedSprite, OpenedSprite;
    
    public void Start()
    {
        Close();
    }

    public void Open()
    {
        GetComponent<SpriteRenderer>().sprite = OpenedSprite;
        IsOpen = true;
    }
    
    public void Close()
    {
        GetComponent<SpriteRenderer>().sprite = ClosedSprite;
        IsOpen = false;
    }
}
