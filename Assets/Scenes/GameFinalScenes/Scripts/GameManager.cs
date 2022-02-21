using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject Player;
    public GameObject restartPosition;
    public MoveScript player;
    public Enemy1 enemy;
    public HealthPoints h_points;


    private void Awake()
    {
        if (instance != null)
        {

            Destroy(gameObject);

        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        Player.transform.position = restartPosition.transform.position;
    }

    public void RestartGame()
    {
       StartCoroutine(RestartGameTime());
    }

    public IEnumerator RestartGameTime()
    {
        Player.SetActive(false);
        enemy.SetActive = false;
        h_points.gameObject.SetActive(false);
        yield return new WaitForSeconds(1);
        Player.transform.position = restartPosition.transform.position;
        Player.SetActive(true);
        h_points.gameObject.SetActive(true  );
        h_childs();
        h_points.i = 4;
        player.health = 5;
        yield return new WaitForSeconds(1);
        enemy.SetActive = true;
        
    }

    public void h_childs()
    {
        h_points.hearts[0].gameObject.SetActive(true);
        h_points.hearts[1].gameObject.SetActive(true);
        h_points.hearts[2].gameObject.SetActive(true);
        h_points.hearts[3].gameObject.SetActive(true);
        h_points.hearts[4].gameObject.SetActive(true);

    }


}
