using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform _ta;
    [SerializeField] private float _min = 1f;
    [SerializeField] private float _max = 3f;
    private Animator _animator;
    private float _many;
    float timer = 0f;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool("Happy", false);
    }

    void Update()
    {
        timer += Time.deltaTime;
        _many = Random.Range(_min, _max);

        if (timer > _many)
        {
            //Debug.Log(timer);
            SpawnEnemy();
            timer = timer - _many;
        }

    }

    private void SpawnEnemy()
    {
        // spawn enemy at object position
        Enemy spawnedEnemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
        spawnedEnemy.SetMovementTarget(_ta);
    }

    public void StopThrowing()
    {
        // stop spawning enemies
        enabled = false;
        _animator.SetBool("Happy", true);
        GameManager.Instance.InactiveSpawner(1);
    }
}
