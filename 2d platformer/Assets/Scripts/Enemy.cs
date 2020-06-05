using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;

    public float argoRange = 5f;

    public static float health = 100f;

    public float moveSpeed = 2f;

    public Rigidbody2D rigidbody2d;

    private void Start()
    {
        rigidbody2d.GetComponent<Rigidbody2D>();    
    }

    private void Update()
    {
        float disToPlayer = Vector2.Distance(transform.position, player.position);

        if( disToPlayer < argoRange)
        {
            StartChaceing();
        }
        else
        {
            StopChaceing();
        }

    }

    void StartChaceing()
    {
        if(transform.position.x < player.position.x)
        {
            rigidbody2d.velocity = new Vector2(moveSpeed, 0);
        }
        else if(transform.position.x > player.position.x)
        {
            rigidbody2d.velocity = new Vector2(-moveSpeed, 0);
        }
    }

    void StopChaceing()
    {
        rigidbody2d.velocity = Vector2.zero;
    }

}
