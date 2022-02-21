using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    [SerializeField] private GameObject meelePrefab;
    [SerializeField] private Transform spawn;
    public float MeleeCD = 0.5f;
    public float delayMelee = 0.8f;
    public Animator animator;


    void Attack()
    {
        GameObject Attack = Instantiate(meelePrefab, spawn.position, spawn.rotation);

    }

    void AttackTimer()
    {
        MeleeCD -= Time.deltaTime;
    }


    void Update()
    {
        AttackTimer();

        if (Input.GetKeyDown(KeyCode.X) && MeleeCD <= 0)
        {
            animator.SetTrigger("Attack");
            Attack();
            MeleeCD = delayMelee;
           
        }
    }
}
