using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.scripts
{
    public class Hero_i_can : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpSpeed;
        [SerializeField] private float _damagejumpSpeed;
        [SerializeField] private float _interactionRadius;
        [SerializeField] private LayerGround _groundCheck;
        [SerializeField] private HeroOut _outCheck;
        
        [SerializeField] private LayerMask _interactionLauer;

        private Collider2D[] _interactionResult = new Collider2D[1];

        private Animator _animator;

        private Vector2 _direction;

        private Rigidbody2D _rigidbody;

        private bool _isGrounded;

        private bool _allowDobleIump;

        private static readonly int IsGroundKey = Animator.StringToHash("Grounded");

        private static readonly int IsRuningKey = Animator.StringToHash("Run");

        private static readonly int IsVelocityKey = Animator.StringToHash("Velocity");

        private static readonly int Hit = Animator.StringToHash("Hit");





        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }


        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }

        private void FixedUpdate()
        {
            var xVelocity = _direction.x * _speed;
            var yVelocity = CalculateYVelocity();
            _rigidbody.velocity = new Vector2(xVelocity, yVelocity);

            _animator.SetBool(IsGroundKey, _isGrounded);
            _animator.SetBool(IsRuningKey, _direction.x != 0);
            _animator.SetFloat(IsVelocityKey, _rigidbody.velocity.y);


        }

        private float CalculateYVelocity()
        {

            //_rigidbody.velocity = new Vector2(_direction.x * _speed, _rigidbody.velocity.y);

            var isJumpPressing = _direction.y > 0;

            var yVelocity = _rigidbody.velocity.y;
            if (_isGrounded) _allowDobleIump = true;
            if (isJumpPressing)
            {
                yVelocity = CalculateJumpVelocity(yVelocity);
                //_rigidbody.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
            }
            else if (_rigidbody.velocity.y > 0)
            {
                yVelocity *= 0.5f;
            }

            return yVelocity;
        }

        private float CalculateJumpVelocity(float yVelocity)
        {
            var isFalling = _rigidbody.velocity.y <= 0.001f;
            if (!isFalling)
            {
                return yVelocity;
            }
            if (_isGrounded)
            {
                yVelocity += _jumpSpeed;
            }
            else if (_allowDobleIump)
            {
                yVelocity = _jumpSpeed;
                _allowDobleIump = false;

            }
            return yVelocity;
        }

        private void Update()
        {
            _isGrounded = _isGround();
            if (_direction.x > 0)
                transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            else if (_direction.x < 0)
                transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }



        private bool _isGround()
        {
            return _groundCheck.IsTouchingLayer;
        }

        public void interacted()
        {
            var hit = Physics2D.OverlapCircleNonAlloc(transform.position, _interactionRadius, _interactionResult, _interactionLauer);
            for (int i = 0; i < hit; i++)
            {
                var interactable = _interactionResult[i].GetComponent<InteractebleComponent>();
                if (interactable != null)
                {
                    interactable.interact();
                }
            }
        }

        public void TakeDamage()
        {
            _animator.SetTrigger(Hit);
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _damagejumpSpeed);
        }
    }

}

