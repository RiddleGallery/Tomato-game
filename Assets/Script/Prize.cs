using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prize : MonoBehaviour
{
    private Rigidbody2D _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.isKinematic = false;
    }

    decimal time = 0m;
    void FixedUpdate()
    {
        time += 0.02m;
        if (time > 3m && time < 4m)
        {
            float alpha = Mathf.PingPong((float)(time * 10), 1f);
            Color color = GetComponent<SpriteRenderer>().color;
            color.a = alpha;
            GetComponent<SpriteRenderer>().color = color;
        }
        else if (time >= 4m)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            GameManager.Instance.AddScore(5);
            Destroy(gameObject);
        }

        EnemySpawner spawner = collision.gameObject.GetComponent<EnemySpawner>();
        if (spawner != null)
        {
            Destroy(gameObject);
            spawner.StopThrowing();
        }
    }

}
