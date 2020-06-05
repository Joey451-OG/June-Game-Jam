using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public GameObject enemy;

    private void Start()
    {
        enemy.GetComponent<GameObject>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(enemy);
    }
}
