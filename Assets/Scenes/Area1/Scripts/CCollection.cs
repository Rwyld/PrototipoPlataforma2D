using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CCollection : MonoBehaviour
{
    public static CCollection Instance;
    public TextMeshProUGUI text;
    public int score;

    private void Start()
    {
        if (Instance == null)
            Instance = this;
    }

    public void Score (int coin_g)
    {
        score += coin_g;
        text.text = score.ToString(); 
    }


}
