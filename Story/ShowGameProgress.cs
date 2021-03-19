using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGameProgress : MonoBehaviour
{
    public Canvas dynamiteCanvas;
    public Canvas caveCanvas;
    public Canvas bossCanvas;
    public StoryLine story;
    public float timeToShowProgress = 5f;

    public Canvas currentCanvas;
    void Start()
    {
        dynamiteCanvas.enabled = false;
        caveCanvas.enabled = false;
        bossCanvas.enabled = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(ShowProgress());
        }
    }

    IEnumerator ShowProgress()
    {
        ChooseCanvas();
        currentCanvas.enabled = true;
        yield return new WaitForSeconds(timeToShowProgress);
        currentCanvas.enabled = false;
    }
    public void ChooseCanvas()
    {
        switch(story.storyProgress)
        {
            case StoryProgress.FindDynamite:
                currentCanvas = dynamiteCanvas; 
                break;
            case StoryProgress.DestroyCaves:
                currentCanvas = caveCanvas;
                break;
            case StoryProgress.KillTheBoss:
                currentCanvas = bossCanvas;
                break;
        }
    }
}
