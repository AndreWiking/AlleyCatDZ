using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WindowsManager : MonoBehaviour
{
    public GameObject[] windows;
    [SerializeField]
    private float delay = 3.0f;
    
    public GameObject bullet;
    [SerializeField]
    private float bulletForce = 6.0f; 
    public void Start()
    {
        StartCoroutine(OpenWindows());
    }
    
    IEnumerator OpenWindows()
    {
        int num = 0;
        while (true)
        {
            windows[num].GetComponent<Window>().Close();
            num = Random.Range(0, windows.Length);
            windows[num].GetComponent<Window>().Open();
            yield return new WaitForSeconds(delay);
            SpawnBullet(windows[num].transform.position);
            SpawnBullet(windows[num].transform.position);
            SpawnBullet(windows[num].transform.position);
        }
    }

    void SpawnBullet(Vector3 pos)
    {
        var obj = Instantiate(bullet, pos, Quaternion.identity);
        Vector2 dir = new Vector2(Random.Range(-1.0f, 1.0f), 0.5f);
        obj.GetComponent<Rigidbody2D>().AddForce(dir * bulletForce, ForceMode2D.Impulse);
    }
}
