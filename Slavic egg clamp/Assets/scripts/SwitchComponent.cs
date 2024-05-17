using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.scripts
{
    public class SwitchComponent : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private bool _state;

        private string _animationKey;

        public void Switch()
        {
            _state=!_state;
            _animator.SetBool(_animationKey, _state);
        }
    }

}

