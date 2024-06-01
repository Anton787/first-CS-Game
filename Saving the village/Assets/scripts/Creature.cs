using Assets.scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.scripts
{
    public class Creature : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] protected float _jumpSpeed;
        [SerializeField] private float _damagejumpSpeed;
        [SerializeField] private int _damage;
        [SerializeField] public LayerGround _groundCheck;




        [SerializeField] private CheckCircleOwerlap _attackRange;

        private Animator _animator;

        protected Vector2 _direction;

        protected Rigidbody2D _rigidbody;

        protected bool _isGrounded;

        private static readonly int IsGroundKey = Animator.StringToHash("Grounded");

        private static readonly int IsRuningKey = Animator.StringToHash("Run");

        private static readonly int IsVelocityKey = Animator.StringToHash("Velocity");

        private static readonly int Hit = Animator.StringToHash("Hit");

        private static readonly int Attack = Animator.StringToHash("Attack");

        protected virtual void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }

        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }

        protected virtual void Update() 
        {
            _isGrounded = _isGround();
            if (_direction.x > 0)
                transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            else if (_direction.x < 0)
                transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

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

        protected virtual float CalculateYVelocity()
        {

            

            var isJumpPressing = _direction.y > 0;

            var yVelocity = _rigidbody.velocity.y;
            
            if (isJumpPressing)
            {
                var isFalling = _rigidbody.velocity.y <= 0.001f;
                yVelocity = isFalling ? CalculateJumpVelocity(yVelocity): yVelocity ;
                
            }
            else if (_rigidbody.velocity.y > 0)
            {
                yVelocity *= 0.5f;
            }

            return yVelocity;
        }

        protected virtual float CalculateJumpVelocity(float yVelocity)
        {
            
            
            if (_isGrounded)
            {
                yVelocity = _jumpSpeed;
            }
            
            return yVelocity;
        }

        
        public void TakeDamage()
        {
            _animator.SetTrigger(Hit);
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _damagejumpSpeed);
        }
        public virtual void Attacked()
        {

            _animator.SetTrigger(Attack);
        }

        public void OnAttacked()
        {
            var gos = _attackRange.GetObjectsInRange();
            foreach (var obj in gos)
            {
                var hp = obj.GetComponent<HealthPoint>();
                if (hp != null && obj.CompareTag("Enemy"))
                {
                    hp.ModifyHealthe(-_damage);
                }
            }
        }
        private bool _isGround()
        {
            return _groundCheck.IsTouchingLayer;
        }

    }

}

