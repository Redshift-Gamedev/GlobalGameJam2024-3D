using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void OnPlayButton()
    {
        //SceneManager.LoadScene(1) TODO;
    }

    public void OnQuitButton ()
    {
        Application.Quit();
    }

}
