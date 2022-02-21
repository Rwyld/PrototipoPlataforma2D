using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetValueCoin : Score
{
    [SerializeField] private float speed;

    void Update()
    {
        CoinsValue1();


        if (transform.localScale.x > 20)
        {
            value = 2;
        }

        if (transform.localScale.x > 30)
        {
            value = 3;
        }
    }





    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            CCollection.Instance.Score(value);
            Destroy(gameObject);

        }

    }

}
