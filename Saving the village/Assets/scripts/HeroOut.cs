
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class HeroOut : MonoBehaviour
{
    [SerializeField] private LayerMask _outLayer;
    public bool IsTouchingOutLayer;
    private Collider2D _collider;



    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IsTouchingOutLayer = _collider.IsTouchingLayers(_outLayer);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        IsTouchingOutLayer = _collider.IsTouchingLayers(_outLayer);
    }



}
