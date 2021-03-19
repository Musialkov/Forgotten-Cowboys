using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class StoryLine : MonoBehaviour
{
    public PlayableDirector appearBossTimeline;
    public PlayableDirector finishBossTimeline;
    public GameObject boss;
    public StoryProgress storyProgress;
    public TextMeshProUGUI currentDynamitTMP;
    public TextMeshProUGUI currentCavesTMP;
    public int currentDynamite = 0;
    public int currentCaves = 0;
    public int requireDynamite = 3;
    public int requireCaves = 3;

    private ShowGameProgress showGameProgress;

    private void Start()
    {
        currentDynamitTMP.text = currentDynamite.ToString();
        currentCavesTMP.text = currentCaves.ToString();
        showGameProgress = FindObjectOfType<ShowGameProgress>();
        boss.SetActive(false);
    }
    public void CollectDynamite()
    {
        if(storyProgress == StoryProgress.FindDynamite)
        {
            currentDynamite++;
            currentDynamitTMP.text = currentDynamite.ToString();
            if(currentDynamite == requireDynamite)
            {
                showGameProgress.currentCanvas.enabled = false;
                storyProgress = StoryProgress.DestroyCaves;
            }
        }
    }
    public void DestroyCaves()
    {
        if (storyProgress == StoryProgress.DestroyCaves)
        {
            currentCaves++;
            currentCavesTMP.text = currentCaves.ToString();
            if (currentCaves == requireCaves)
            {
                showGameProgress.currentCanvas.enabled = false;
                storyProgress = StoryProgress.KillTheBoss;
                appearBossTimeline.Play();
                boss.SetActive(true);
            }
        }
    }
    public void AfterBossDead()
    {
        storyProgress = StoryProgress.End;
        finishBossTimeline.Play();
    }
}

public enum StoryProgress
{
    FindDynamite,
    DestroyCaves,
    KillTheBoss,
    End
}
