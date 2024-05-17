using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace Assets.scripts
{
    public class InteractebleComponent : MonoBehaviour
    {
        [SerializeField] private UnityEvent _action;
        public void interact()
        {
            _action.Invoke();
        }
    }
}

public class InteractebleComponent : MonoBehaviour
{
    
}
