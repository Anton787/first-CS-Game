using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Hero_i_can : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpSpeed;

    [SerializeField] private LayerGround _groundCheck;
    [SerializeField] private HeroOut _outCheck;

    private Animator m_animator;

    private Vector2 _direction;

    private Rigidbody2D _rigidbody;




    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }


    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(_direction.x * _speed , _rigidbody.velocity.y);

        var isJumping = _direction.y > 0;
        if (isJumping && _isGround()) 
        {
            _rigidbody.AddForce(Vector2.up * _jumpSpeed , ForceMode2D.Impulse);
        }
        
    }

    private void Update()
    {
        if (_direction.x > 0)
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (_direction.x < 0)
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }

   

    private bool _isGround()
    {
        return _groundCheck.IsTouchingLayer;
    }

    public void SaySomething()
    {
        Debug.Log("Something!");
    }
}
