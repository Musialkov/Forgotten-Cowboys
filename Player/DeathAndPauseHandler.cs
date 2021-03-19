using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class DeathAndPauseHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] Canvas pauseCanvas;
    [SerializeField] Canvas crossCanvas;
    [SerializeField] ShowGameProgress showProgress;
    [SerializeField] GameObject equipment;
    [SerializeField] List<Canvas> listCanvas;
    [SerializeField] Camera camera;
    [SerializeField] GameObject snipe;
    [SerializeField] float defaultFOV = 60f;


    public bool gamePause = false;
    
    private void Start()
    {
        listCanvas.Add(showProgress.currentCanvas);
        gameOverCanvas.enabled = false;
    }
    private void Update()
    {
        ShowPauseMenu();
    }

    private void ShowPauseMenu()
    { 
        if (Input.GetKeyDown(KeyCode.Escape) && gamePause == false)
        {
            DisableOrActivatePlayer(false);
            Time.timeScale = 0;
            pauseCanvas.enabled = true;
        }
       
    }

    public void HandleDeath()
    {
        DisableOrActivatePlayer(false);
        Time.timeScale = 0;
        gameOverCanvas.enabled = true;        
    }
    public void DisableOrActivatePlayer(bool wantActivate)
    {
        crossCanvas.enabled = wantActivate;
        equipment.gameObject.SetActive(wantActivate);
        GetComponent<FirstPersonController>().enabled = wantActivate;
        snipe.GetComponent<MeshRenderer>().enabled = wantActivate;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = !wantActivate;
        camera.fieldOfView = defaultFOV;
        foreach(Canvas canvas in listCanvas)
        {
            canvas.enabled = false;
        }
    }
}
