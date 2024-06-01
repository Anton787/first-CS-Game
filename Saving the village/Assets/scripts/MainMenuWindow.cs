using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.scripts
{
    public class MainMenuWindow : MonoBehaviour
    {
        
        public void OnStartGame()
        {
            SceneManager.LoadScene("FirstScene");

        }

        public void OnExit()
        {

                Application.Quit();

        }

    }





}

