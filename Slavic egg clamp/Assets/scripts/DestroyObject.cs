using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjgect : MonoBehaviour
{
    [SerializeField] private GameObject _objectdestroy;

    public void DestroyObject()
    {
        Destroy(_objectdestroy);
    }
}
