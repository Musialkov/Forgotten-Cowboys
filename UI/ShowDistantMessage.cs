using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class ShowDistantMessage : MonoBehaviour
{
    public Canvas messageCanvas;
    public bool targetSeeMessage = false;
    public float distanceToShowMessage = 5f;

    private Transform target;
     
    void Start()
    {
        messageCanvas.enabled = false;
        target = FindObjectOfType<FirstPersonController>().transform;
    }

    void Update()
    {
        ShowMessage();
    }
    private void ShowMessage()
    {
        if (Vector3.Distance(target.transform.position, this.transform.position) < distanceToShowMessage)
        {
            messageCanvas.enabled = true;
            targetSeeMessage = true;
        }
        else if (Vector3.Distance(target.transform.position, this.transform.position) < distanceToShowMessage + 1)
        {
            messageCanvas.enabled = false;
            targetSeeMessage = false;
        }

    }
}
