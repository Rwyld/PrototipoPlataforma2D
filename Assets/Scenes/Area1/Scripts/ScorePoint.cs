using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePoint : MonoBehaviour
{
    public int coin_g = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            CCollection.Instance.Score(coin_g);
            Destroy(gameObject);
            
        }

    }
}
