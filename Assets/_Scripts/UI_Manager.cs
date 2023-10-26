using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public GameObject LoseText, WinText, DamagePanel;

    public void ShowLose()
    {
        LoseText.GetComponent<Animation>().Play();
    }
    
    public void ShowWin()
    {
        WinText.SetActive(true);
    }

    public void ShowDamage()
    {
        DamagePanel.GetComponent<Animation>().Play();
    }
}

