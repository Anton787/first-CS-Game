using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


namespace Assets.scripts
{
    public class MobAi : MonoBehaviour
    {

        [SerializeField] private LayerGround _vision;
        [SerializeField] private LayerGround _canAttack;
        [SerializeField] private float _alarmTime;

        private Coroutine _current;
        private GameObject _target;
        private Creature _creature;

        private void Awake()
        {
            _creature = GetComponent<Creature>();
        }
        private void Start ()
        {
            StartState(Patrolling());
        }

        public void OnHeroInVision (GameObject go)
        {
            _target = go;

            StartState(AgroToHero());
            
            
        }

        private IEnumerator AgroToHero()
        {
            yield return new WaitForSeconds(_alarmTime);
            StartState(GoToHero());
        }

        private IEnumerator GoToHero()
        {
            while (_vision.IsTouchingLayer) 
            {
                SetDirectionToTarget();
                yield return null;
            }
        }

        private void SetDirectionToTarget()
        { 
            var direction=_target.transform.position - transform.position;
            direction.y = 0;
            _creature.SetDirection(direction);
        
        }
        private IEnumerator Patrolling()
        { 
            yield return null;
        }

        private void StartState(IEnumerator coroutine)
        {
            if (coroutine != null) 
            
            {
                StopCoroutine(_current);
            }
            _current= StartCoroutine(coroutine);
            
        }

    }
}

