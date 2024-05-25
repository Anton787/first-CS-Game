using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.scripts
{
    public class Hero_i_can : Creature
    {
        
        
        //[SerializeField] private float _damagejumpSpeed;
        [SerializeField] private float _interactionRadius;
        [SerializeField] private HeroOut _outCheck;

        //[SerializeField] private float _speed;
       // [SerializeField] private float _jumpSpeed;
        //[SerializeField] private float _damagejumpSpeed;
        //[SerializeField] private int _damage;
        [SerializeField] private LayerGround _groundCheck;
        //[SerializeField] private CheckCircleOwerlap _attackRange;


        [SerializeField] private LayerMask _interactionLauer;

       

        private Collider2D[] _interactionResult = new Collider2D[1];

        //private Animator _animator;

        //private Vector2 _direction;

        //private Rigidbody2D _rigidbody;

        //private bool _isGrounded;

        private bool _allowDobleIump;

        //private static readonly int IsGroundKey = Animator.StringToHash("Grounded");

        //private static readonly int IsRuningKey = Animator.StringToHash("Run");

        //private static readonly int IsVelocityKey = Animator.StringToHash("Velocity");

        //private static readonly int Hit = Animator.StringToHash("Hit");

        //private static readonly int Attack = Animator.StringToHash("Attack");

        private GameSession _session;

        //***
        protected override void Awake()
        {
            base.Awake();
        }
        //***

        //private void Awake()
        //{
            //_rigidbody = GetComponent<Rigidbody2D>();
            //_animator = GetComponent<Animator>();
        //}
        

        private void Start()
        {
            _session = FindObjectOfType<GameSession>();

            var health=GetComponent<HealthPoint>();
            health.SetHealth(_session.data._hp);
            
        }

         public void OnHealthChanged(int curentHealth)
         {
             _session.data._hp = curentHealth;
         }
        

        //public void SetDirection(Vector2 direction)
        //{
        //    _direction = direction;
        //}

        //private void FixedUpdate()
        //{
         //   var xVelocity = _direction.x * _speed;
         //   var yVelocity = CalculateYVelocity();
         //   _rigidbody.velocity = new Vector2(xVelocity, yVelocity);

         //   _animator.SetBool(IsGroundKey, _isGrounded);
         //   _animator.SetBool(IsRuningKey, _direction.x != 0);
         //   _animator.SetFloat(IsVelocityKey, _rigidbody.velocity.y);


       // }
       
        protected override float CalculateYVelocity()
        {

            //_rigidbody.velocity = new Vector2(_direction.x * _speed, _rigidbody.velocity.y);

            var isJumpPressing = _direction.y > 0;

            //var yVelocity = _rigidbody.velocity.y;
            if (_isGrounded) _allowDobleIump = true;
            //if (isJumpPressing)
            //{
            //    yVelocity = CalculateJumpVelocity(yVelocity);
                //_rigidbody.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
           // }
           // else if (_rigidbody.velocity.y > 0)
           // {
          //      yVelocity *= 0.5f;
          //  }

            return base.CalculateYVelocity();
        }

        protected override float CalculateJumpVelocity(float yVelocity)
        {
            //var isFalling = _rigidbody.velocity.y <= 0.001f;
            //if (!isFalling)
            //{
            //    return yVelocity;
            //}
            //if (_isGrounded)
            //{
            //    yVelocity += _jumpSpeed;
            //}
            if (!_isGrounded && _allowDobleIump)
            {
                
                _allowDobleIump = false;
                return _jumpSpeed;

            }
            return base.CalculateJumpVelocity(yVelocity);
        }
        

        protected override void Update()
        {
            base.Update();
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

        

        

        

        
    }

}

