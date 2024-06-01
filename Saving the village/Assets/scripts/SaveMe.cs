using Assets.scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.scripts
{
    public class SaveMe : MonoBehaviour
    {
        
        private void Start()
        {
            DontDestroyOnLoad(gameObject);

            var sessions = FindObjectOfType<SaveMe>();

        }



    }
}

