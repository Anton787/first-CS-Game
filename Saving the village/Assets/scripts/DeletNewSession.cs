using Assets.scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletNewSession : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var session = FindObjectOfType<GameSession>();
        Destroy(session);
    }

    
}
