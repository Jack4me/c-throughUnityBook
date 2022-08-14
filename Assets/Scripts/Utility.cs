using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

    public static class Utilities
    {

        public static int playerDeathCount = 0;
    public static string UpdateDeathCounnt(ref int deaths)
    {
        deaths += 1;
        return "One more death" + deaths;
    }
        public static void RestartMetod()
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1.0f;
                
            Debug.Log("Player death : " + playerDeathCount);
        string message = UpdateDeathCounnt(ref playerDeathCount);
            Debug.Log("Player death : " + playerDeathCount);
            Debug.Log(message);
        }
      
    public static bool RestartMetod(int sceneIndex)
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1.0f;
        return true;
        }
  
    }

