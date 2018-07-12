using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour 
{
    public GameObject PausePanel;
    public GameObject EndPanel;

    public bool IsPaused;
    public bool GameOver = false;

    void Awake()
    {
        Resume();
        EndPanel.SetActive(false);
    }

    void Update()
    {
        if (!IsPaused)
        {
            Resume();

        }
        if (IsPaused)
        {

            Pause();

        }

        if(GameOver)
        {
            EndPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }


    void Resume()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;

    }

    void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OnResumeBtnClicked()
    {
        IsPaused = false;

    }

    public void OnRestartBtnClicked()
    {
        SceneManager.LoadScene("TetrisScene");
    }

    public void OnMenuBtnClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
