using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Prize _PrizePrefab;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void SetMovementTarget(Transform target)
    {
        Vector3 moveDirection = (target.position - transform.position).normalized;
        _rb.velocity = moveDirection * _speed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            Debug.Log("Hit player!");
            GameManager.Instance.Hurt(1);
            Destroy(gameObject);
        }

        Wall wall = collision.gameObject.GetComponent<Wall>();
        if (wall != null)
        {
            Destroy(gameObject);
        }

        Bullet bullet = collision.gameObject.GetComponent<Bullet>();
        if (bullet != null)
        {
            Destroy(gameObject);
            Destroy(bullet.gameObject);
            Prize prize = Instantiate(_PrizePrefab, transform.position, Quaternion.identity);
        }

    }
}
