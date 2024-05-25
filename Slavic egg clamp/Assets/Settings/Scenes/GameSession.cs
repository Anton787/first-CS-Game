using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.scripts
{
    public class GameSession : MonoBehaviour
    {
        [SerializeField] private PlayerData _data;
        public PlayerData data => _data;
        private void Awake()
        {
            DontDestroyOnLoad(this);
            if (IsSessionExit()) 
            {
                DestroyImmediate(gameObject);
            }
            else
            {
                DontDestroyOnLoad(this);
            }
        }
        private bool IsSessionExit()
        {
            var sessions = FindFirstObjectByType<GameSession>();
            if (sessions != this)
            {
                return true;
            }
            return false;
        }

            

        
    }
}



