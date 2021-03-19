using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] Canvas pauseCanvas;
    [SerializeField] Canvas healtHCanvas;
    [SerializeField] Camera fpsCamera;

    DeathAndPauseHandler deathAndPauseHandler;
    private void Start()
    {
        deathAndPauseHandler = FindObjectOfType<DeathAndPauseHandler>();
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void ReloadGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Resume()
    {
        fpsCamera.fieldOfView = 60f;
        Time.timeScale = 1;
        pauseCanvas.enabled = false;
        deathAndPauseHandler.DisableOrActivatePlayer(true);
        healtHCanvas.enabled = true;
    }
    public void Credits()
    {
        SceneManager.LoadScene(2);
    }

   
       
    
}
