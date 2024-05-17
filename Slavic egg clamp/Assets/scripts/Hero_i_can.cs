using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Hero_i_can : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private float _damagejumpSpeed;

    [SerializeField] private LayerGround _groundCheck;
    [SerializeField] private HeroOut _outCheck;

    private Animator _animator;

    private Vector2 _direction;

    private Rigidbody2D _rigidbody;

    private static readonly int IsGroundKey = Animator.StringToHash("Grounded");

    private static readonly int IsRuningKey = Animator.StringToHash("Run");

    private static readonly int IsVelocityKey = Animator.StringToHash("Velocity");

    private static readonly int Hit = Animator.StringToHash("Hit");





    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator  = GetComponent<Animator>();
    }


    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(_direction.x * _speed, _rigidbody.velocity.y);

        var isJumping = _direction.y > 0;
        var isGround = _isGround();
        if (isJumping && isGround)
        {
            _rigidbody.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
        }
        _animator.SetBool(IsGroundKey, isGround);
        _animator.SetBool(IsRuningKey, _direction.x != 0);
        _animator.SetFloat(IsVelocityKey, _rigidbody.velocity.y) ;


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

    public void TakeDamage()
    {
        _animator.SetTrigger(Hit);
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _damagejumpSpeed);
    }
}
