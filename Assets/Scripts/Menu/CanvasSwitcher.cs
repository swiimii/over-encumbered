using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSwitcher : MonoBehaviour
{
    public GameObject thisCanvas, thatCanvas;

    public void Switch()
    {
        thisCanvas.SetActive(false);
        thatCanvas.SetActive(true);
    }
}
