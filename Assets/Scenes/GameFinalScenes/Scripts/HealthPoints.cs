using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthPoints : MonoBehaviour
{
    public static HealthPoints Instance;
    public GameObject[] hearts;
    public int i = 4;
    public TextMeshProUGUI textH;
    public float health;
    public Player player;

    private void Start()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Update()
    {

        if (player.health <= i) 
        { 
            hearts[i].gameObject.SetActive(false); 
            i--;

        }

        Score();

    }
   

    public void Score()
    {
        health = player.health;
        textH.text = health.ToString();
    }



}
