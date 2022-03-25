using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playButton : MonoBehaviour
{
    public void PlayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
