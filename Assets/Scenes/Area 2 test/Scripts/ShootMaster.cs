using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootMaster : MonoBehaviour
{
    public List<Transform> positions;

    public GameObject[] lines;
    public GameObject ball;
    public GameObject player;

   
    



    void Update()
    {
        for (int i = 0; i < lines.Length; i++)
        {
            StartCoroutine("enumerator");
        }
        
        

        if (player != null)
        {

            StartCoroutine("transforms");
        }
    }



    IEnumerator enumerator()
    {
        foreach (var gameObject in lines)
        {
            gameObject.SetActive(true);
            yield return new WaitForSeconds(5);
        }
    }

    IEnumerator transforms()
    {
        foreach (var transform in positions)
        {
            yield return new WaitForSeconds(5);

        }
    }
  
   public void Dictio() 
    {
        Dictionary<string, int> dmgObj = new Dictionary<string, int>();

        dmgObj.Add("Laser1", 1);
        dmgObj.Add("Laser2", 2);
        dmgObj.Add("Laser3", 3);

    }
    
    

}
