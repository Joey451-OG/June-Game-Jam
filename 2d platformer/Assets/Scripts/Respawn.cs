using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject player;

    public GameObject respawn;

    private void Start()
    {
        player.GetComponent<GameObject>();
        respawn.GetComponent<GameObject>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        player.transform.position = respawn.transform.position;
    }
}
