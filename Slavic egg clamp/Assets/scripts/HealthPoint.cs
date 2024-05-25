using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.Controls.AxisControl;
using UnityEngine.Events;
using System;

namespace Assets.scripts
{
    public class HealthPoint : MonoBehaviour
    {
        [SerializeField] private int _health;
        [SerializeField] private UnityEvent _onDamage;
        [SerializeField] private UnityEvent _onHeal;
        [SerializeField] private UnityEvent _onDie;
        [SerializeField] private HealthChangeEvent _onChange;


        public void ModifyHealthe(int helthDelta)
        {
            _health += helthDelta;
            _onChange?.Invoke(_health);
            if (helthDelta < 0)
            {
                _onDamage?.Invoke();
            }
            
            if (helthDelta > 0 )
            {
              
                _onHeal?.Invoke();
                
                
            }

            if (_health <= 0)
            {
                _onDie?.Invoke();      
            }
        }


        private void Update()
        {
            _onChange?.Invoke(_health);
        }


        public void SetHealth(int health)
        {
            _health = health;
        }

        [Serializable]
        public class HealthChangeEvent : UnityEvent <int>
        {

        }

        
    }
}
