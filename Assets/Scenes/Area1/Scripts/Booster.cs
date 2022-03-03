using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    public Player player;
    public int H_points;



    void Start()
    {
        GameEvents.Ev.Boost += GainHealth;
    }


    private void GainHealth()
    {
            player.health += H_points;
            Debug.LogError("Ahora tienes " + player.health + " puntos de vida");
            gameObject.SetActive(false);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (player.health < 5)
        {
            GainHealth();
        }
    }
}
