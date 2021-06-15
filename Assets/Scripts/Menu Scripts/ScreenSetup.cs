using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenSetup : MonoBehaviour
{
    public Canvas mainCanvas;
    public Canvas levelSelectCanvas;
    public Canvas optionsCanvas;

    private Vector2 screenResolution;

    // Start is called before the first frame update
    void Start()
    {
        screenResolution = new Vector2(Screen.width, Screen.height);

        mainCanvas.GetComponent<CanvasScaler>().referenceResolution = screenResolution;
        levelSelectCanvas.GetComponent<CanvasScaler>().referenceResolution = screenResolution;
        optionsCanvas.GetComponent<CanvasScaler>().referenceResolution = screenResolution;

        if (screenResolution[1] > screenResolution[0])
        {
            mainCanvas.GetComponent<CanvasScaler>().matchWidthOrHeight = 1;
            levelSelectCanvas.GetComponent<CanvasScaler>().matchWidthOrHeight = 1;
            optionsCanvas.GetComponent<CanvasScaler>().matchWidthOrHeight = 1;
        }
        else
        {
            mainCanvas.GetComponent<CanvasScaler>().matchWidthOrHeight = 0;
            levelSelectCanvas.GetComponent<CanvasScaler>().matchWidthOrHeight = 0;
            optionsCanvas.GetComponent<CanvasScaler>().matchWidthOrHeight = 0;
        }
    }

    ///Leaving this here for later, not sure how this is going to affect stuff
    //void Start()
    //{
    //    if (Screen.height > Screen.width)
    //    {
    //        mainCanvas.GetComponent<CanvasScaler>().matchWidthOrHeight = 0;
    //        levelSelectCanvas.GetComponent<CanvasScaler>().matchWidthOrHeight = 0;
    //        optionsCanvas.GetComponent<CanvasScaler>().matchWidthOrHeight = 0;
    //    }
    //    else
    //    {
    //        mainCanvas.GetComponent<CanvasScaler>().matchWidthOrHeight = 1;
    //        levelSelectCanvas.GetComponent<CanvasScaler>().matchWidthOrHeight = 1;
    //        optionsCanvas.GetComponent<CanvasScaler>().matchWidthOrHeight = 1;
    //    }
    //}
}
