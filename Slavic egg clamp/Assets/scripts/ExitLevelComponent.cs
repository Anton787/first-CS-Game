using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Assets.scripts
{
    public class ExitLevelComponent : MonoBehaviour
    {
        [SerializeField] private string _sceneName;
        public void Exitó()
        {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(_sceneName);

        }
    }
}

