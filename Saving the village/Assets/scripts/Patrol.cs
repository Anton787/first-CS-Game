using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.UIElements;



namespace Assets.scripts
{
    public class Patrol : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _stopingDistance;
        [SerializeField] private float _retreatDistance;
        [SerializeField] private LayerGround _vision;
        private Transform _transformPlayer; 
        private float _waitTime;
        [SerializeField] private float _startWaitTime;
        private Vector2 _direction;

        public Transform[] _moveSpots;
        private int _randomSpot;
        void Start()
        {
            _transformPlayer = GameObject.FindGameObjectWithTag("Hero").transform;
            _waitTime = _startWaitTime;
            _randomSpot= Random.Range(0, _moveSpots.Length);
        }

        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }

        // Update is called once per frame
        void Update()
        {
            

            if (_vision.IsTouchingLayer)
            {
                if (Vector2.Distance(transform.position, _transformPlayer.position) > _stopingDistance)
                {
                    transform.position = Vector2.MoveTowards(transform.position, _transformPlayer.position, _speed * Time.deltaTime);
                }
                else if ((Vector2.Distance(transform.position, _transformPlayer.position) < _stopingDistance) && (Vector2.Distance(transform.position, _transformPlayer.position) > _retreatDistance))
                {
                    transform.position = this.transform.position;
                }
                else if ((Vector2.Distance(transform.position, _transformPlayer.position) < _stopingDistance) && (Vector2.Distance(transform.position, _transformPlayer.position) < _retreatDistance))
                {
                    transform.position = Vector2.MoveTowards(transform.position, _transformPlayer.position, -_speed * Time.deltaTime);
                }
            }

            else 
            {
                transform.position = Vector2.MoveTowards(transform.position, _moveSpots[_randomSpot].position, _speed * Time.deltaTime);
                if (Vector2.Distance(transform.position, _moveSpots[_randomSpot].position) < 0.2f)
                {
                    if (_waitTime <= 0)
                    {
                        _randomSpot = Random.Range(0, _moveSpots.Length);
                        _waitTime = _startWaitTime;
                    }
                    else
                    {
                        _waitTime -= Time.deltaTime;
                    }
                }
            }

            


        }


    }
}

