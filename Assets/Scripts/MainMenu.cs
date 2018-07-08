using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void OnPlayClicked()
    {
        SceneManager.LoadScene("TetrisScene");
    }

    public void OnQuitClicked()
    {
        Application.Quit();
        //System.Diagnostics.Process.GetCurrentProcess().Kill();
    }

}