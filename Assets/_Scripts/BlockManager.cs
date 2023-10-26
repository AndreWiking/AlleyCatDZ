using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public GameObject[] spikes;
    public float delay1, delay2;
    public void Start()
    {
        StartCoroutine(ControlSpikes(delay1));
        StartCoroutine(ControlSpikes(delay2));
    }
    
    IEnumerator ControlSpikes(float delay)
    {
        int num = 0;
        while (true)
        {
            spikes[num].SetActive(false);
            num = Random.Range(0, spikes.Length);
            spikes[num].SetActive(true);
            yield return new WaitForSeconds(delay);
        }
    }
}
