using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    public MoveScript player;
    void Start()
    {
        GameEvents.Ev.Boost += GainHealth;
    }


    private void GainHealth()
    {
        player.health += 1;
        Debug.LogError("Ahora tienes " + player.health + " puntos de vida");
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GainHealth();
    }
}
