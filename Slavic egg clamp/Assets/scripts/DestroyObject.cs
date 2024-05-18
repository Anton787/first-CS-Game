using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.scripts
{
    public class DestroyObjgect : MonoBehaviour
    {
        [SerializeField] private GameObject _objectdestroy;

        public void DestroyObject()
        {
            Destroy(_objectdestroy);
        }
        public void lookfor()
        {
             _objectdestroy.GetComponent<SpriteRenderer>().enabled = false;
        }

    }
}

