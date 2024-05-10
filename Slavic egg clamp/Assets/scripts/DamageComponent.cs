using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.scripts
{
    public class DamageComponent : MonoBehaviour
    {
        [SerializeField] private int _damage;


        public void ApplyDamage(GameObject target)
        {
            var health = target.GetComponent<HealthPoint>();
            if (health != null)
            { 
                health.ApplyDamage(_damage); 
            }
        }
    }
}
