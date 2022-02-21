using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlats : MonoBehaviour
{
    public GameObject[] platforms;
    public bool startplats = false;
    public GameObject laser;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        startplats = true;
    }

    IEnumerator platsOn()
    {
        foreach (var gameObject in platforms)
        {
            gameObject.SetActive(true);
            yield return new WaitForSeconds(2);
        }
    }

    void Update()
    {
        if (startplats)
        {
            for (int i = 0; i<platforms.Length; i++)
            {
                StartCoroutine("platsOn");
                laser.SetActive(true);
            }
        }
            
    }
}
