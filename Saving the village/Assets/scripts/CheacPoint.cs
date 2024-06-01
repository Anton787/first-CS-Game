using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace Assets.scripts
{
    public class CheacPoint : MonoBehaviour
    {
        //[SerializeField] private UnityEvent _action;

        void Start()
        {
            if (PlayerPrefs.GetInt("PositionPlayer") == 1)
            {
                transform.position = new Vector2(PlayerPrefs.GetFloat("xPosition"), PlayerPrefs.GetFloat("yPosition"));
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {

            if (collision.CompareTag("CheackPoint"))
            {
                PlayerPrefs.SetInt("PositionPlayer", 1);
                PlayerPrefs.SetFloat("xPosition", transform.position.x);
                PlayerPrefs.SetFloat("yPosition", transform.position.y);


            }

        }

        public void Reset()
        {
            PlayerPrefs.SetInt("PositionPlayer", 1);
        }



    }
}

