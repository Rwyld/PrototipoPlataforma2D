using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPoints : MonoBehaviour
{
    public GameObject[] hearts;
    [SerializeField] private MoveScript player;
    public int i = 4;

    private void Update()
    {

        if (player.health <= i) 
        { 
            hearts[i].gameObject.SetActive(false); 
            i--;

        }
        
    }




}
