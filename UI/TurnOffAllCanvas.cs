using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffAllCanvas : MonoBehaviour
{
    [SerializeField] List<Canvas> canvas;
    
    void Start()
    {
        foreach (Canvas canvas in canvas)
            canvas.enabled = false;
    }
}
