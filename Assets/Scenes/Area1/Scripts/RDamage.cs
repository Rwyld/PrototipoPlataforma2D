using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RDamage : MonoBehaviour 
{
    public int damage;
    public float time;
    public float timeIn;
    public float speed;
    public GameObject player;
    public Transform reset;
    public float x, y;
    public Player sc_player;



    public void ResetPos()
    {
        transform.position = reset.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();


        if (player != null)
        {
            player.PlayerTakeDamage(damage);
            Destroy(gameObject);
            ResetPos();
        }

    }

    

}
