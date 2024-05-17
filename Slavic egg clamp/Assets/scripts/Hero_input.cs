using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.scripts
{
    public class Hero_input : MonoBehaviour

    {
        private Hero_i_can _hero;
        private void Awake()
        {
            _hero = GetComponent<Hero_i_can>();
        }

        public void OnMovment(InputAction.CallbackContext context)
        {
            var direction = context.ReadValue<Vector2>();

            _hero.SetDirection(direction);
        }


        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.canceled)
            {
                _hero.interacted();
            }
        }

    }

}

