using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class Music : MonoBehaviour
{
    public GameObject musicPrev, musicNew;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine("SongSwitch");


        //musicPrev.SetActive(false);
        //musicNew.SetActive(true);
    }



    IEnumerator SongSwitch()
    {
        yield return new WaitForSeconds(3);
        musicNew.SetActive(true);
        yield return new WaitForSeconds(3);
        musicPrev.SetActive(false);
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }


}


