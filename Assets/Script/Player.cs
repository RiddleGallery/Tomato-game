using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] Rigidbody2D _bulletPrefab;
    private Rigidbody2D _rb;
    private Animator _animator;

    private void Start()
    {
        transform.position = Vector3.zero;
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

    }
    

    // Update is called once per frame
    void Update()
    {
        // control player with wasd
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        _rb.velocity = new Vector2(moveX, moveY).normalized * _speed;

        // please do the animator for moving left right 
        float lastmove = moveX;

        if (moveX > 0)
        {
            _animator.SetBool("isRunning", true);
            _animator.SetBool("isRunningLeft", false);
            _animator.SetBool("isRunningRight", true) ;
        }
        else if (moveX < 0)
        {
            _animator.SetBool("isRunning", true);
            _animator.SetBool("isRunningLeft", true);
            _animator.SetBool("isRunningRight", false);
        }
        else if (moveY > 0 || moveY < 0)
        {
            if (lastmove > 0)
            {
                _animator.SetBool("isRunning", true);
                _animator.SetBool("isRunningLeft", false);
                _animator.SetBool("isRunningRight", true);
            }
            else if (lastmove < 0)
            {
                _animator.SetBool("isRunning", true);
                _animator.SetBool("isRunningLeft", true);
                _animator.SetBool("isRunningRight", false);
            }
            
        }
        else
        {
            _animator.SetBool("isRunningLeft", false);
            _animator.SetBool("isRunning", false);
            _animator.SetBool("isRunningRight", false);
        }

        // shoot bullet at mouse position when left mouse button is clicked pivot is front of the bullet
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 shootDirection = (mousePosition - transform.position);
            shootDirection.z = 0f;
            shootDirection = shootDirection.normalized;
            float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0f, 0f, angle);
            Rigidbody2D bullet = Instantiate(_bulletPrefab, transform.position + shootDirection * 0.5f, rotation);
            bullet.velocity = shootDirection * 10f;
        }
    }

    public void GotHurt()
    {
        _animator.SetTrigger("Hurt");
    }


}
