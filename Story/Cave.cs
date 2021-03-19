using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class Cave : MonoBehaviour
{
    public StoryLine story;
    public GameObject toShowUp;
    public GameObject toDestoy;
    public ParticleSystem dust;
    public Canvas dark;
    [SerializeField] float timeOfDarkness;

    private ShowDistantMessage showMessage;
    public bool isDestroyed = false;

    private AudioSource audio;
    void Start()
    {
        showMessage = GetComponent<ShowDistantMessage>();
        toShowUp.SetActive(false);
        toDestoy.SetActive(true);
        dark.enabled = false;
        audio = GetComponent<AudioSource>();
    }
    void Update()
    {
       DestroyCave();
    }

    public void DestroyCave()
    {
        if (Input.GetKeyDown(KeyCode.F) && showMessage.targetSeeMessage && !isDestroyed)
        {
            story.DestroyCaves();
            Destroy(toDestoy);
            audio.Play();
            toShowUp.SetActive(true);
            dust.Play();
            showMessage.messageCanvas.enabled = false;
            StartCoroutine(ShowDark());
            isDestroyed = true;
            showMessage.enabled = false;
        }
    }
    IEnumerator ShowDark()
    {
        dark.enabled = true;
        yield return new WaitForSeconds(timeOfDarkness);
        dark.enabled = false;
    }
}
