using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


namespace Assets.scripts
{

    public class CheckCircleOwerlap : MonoBehaviour
    {
        [SerializeField] private float _radius = 1f;
        //[SerializeField] private string _tag;
        private Collider2D[] _interactionResult = new Collider2D[5];
        public GameObject[] GetObjectsInRange()
        {
            var size = Physics2D.OverlapCircleNonAlloc(transform.position, _radius, _interactionResult);
            
            var overlaps =new List<GameObject>();

            for (int i = 0; i < size; i++)
            {
                overlaps.Add(_interactionResult[i].gameObject);

            }
            return overlaps.ToArray();
        }

        private void OnDrawGizmosSelected()
        {
            Handles.DrawSolidDisc(transform.position,Vector3.forward,_radius);
        }
    }
}

