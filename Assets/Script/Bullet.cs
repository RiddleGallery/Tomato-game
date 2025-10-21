using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemySpawner spawner = collision.gameObject.GetComponent<EnemySpawner>();
        if (spawner != null)
        {
            Destroy(gameObject);
        }

        Wall wall = collision.gameObject.GetComponent<Wall>();
        if (wall != null)
        {
            Destroy(gameObject);
        }
    }

}
