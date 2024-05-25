using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.scripts
{
    public class ModifyHealthComponent : MonoBehaviour
    {
        [SerializeField] private int _hpDelta;


        public void ModifyHealth(GameObject target)
        {
            var _health = target.GetComponent<HealthPoint>();
            if (_health != null)
            { 
                _health.ModifyHealthe(_hpDelta); 
            }
        }
        
    }
}
