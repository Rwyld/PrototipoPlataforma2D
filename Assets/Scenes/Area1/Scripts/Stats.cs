using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "EnemyStatsData", fileName = ("NewData"), order = 0)]
public class Stats : ScriptableObject
{
    [SerializeField] public float speed;
    [SerializeField] public float health;
    [SerializeField] public int damageDeal;

}
