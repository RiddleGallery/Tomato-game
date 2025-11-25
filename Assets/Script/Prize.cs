using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prize : MonoBehaviour
{
    

    
    

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _fryTransform;

    [SerializeField] private Player _player;
    
    private Rigidbody2D _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _player = GetComponent<Player>();
        _rb.isKinematic = false;
        _audioSource = GetComponent<AudioSource>();
    }

    decimal time = 0m;
    private void Start()
    {
        _audioSource.PlayOneShot(_fryTransform);
    }

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
            _player = player;
            GameManager.Instance.AddScore(5);
            _player.PlayCollectSFX();
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
