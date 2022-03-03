using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DestroyFog : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {   

        transform.position += transform.position * 2;
        Destroy(gameObject);

        
    }



}
