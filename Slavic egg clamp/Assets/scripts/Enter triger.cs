using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static Assets.scripts.EnterCollision;

public class Entertriger : MonoBehaviour
{
    [SerializeField] private string _tag;

    [SerializeField] private EnterEvent _action;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(_tag))
        {
            _action?.Invoke(other.gameObject);  
        }
    }



}
