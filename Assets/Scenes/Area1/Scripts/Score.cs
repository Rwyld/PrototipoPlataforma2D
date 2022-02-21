using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int value = 1;
    public virtual void CoinsValue1()
    {
        transform.localScale *= 1.001f;
    }

    
}
