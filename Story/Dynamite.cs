using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamite : MonoBehaviour
{
    public StoryLine story;

    private ShowDistantMessage showMessage;

    void Start()
    {
        showMessage = GetComponent<ShowDistantMessage>();
    }

    // Update is called once per frame
    void Update()
    {
        PickupDynamite();       
    }
 

    private void PickupDynamite()
    {
        if(Input.GetKeyDown(KeyCode.F) && showMessage.targetSeeMessage)
        {
            story.CollectDynamite();
            Destroy(gameObject);
            showMessage.messageCanvas.enabled = false;
        }
    }
}
