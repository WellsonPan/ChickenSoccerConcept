using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button playButton;
    public Button levelSelectButton;
    public Button customizeButton;
    public Button optionsButton;

    public Canvas mainCanvas;
    public Canvas levelSelectCanvas;
    public Canvas optionsCanvas;

    // Start is called before the first frame update
    void Start()
    {
        ///TODO Add play button listener and logic
        levelSelectButton.onClick.AddListener(LoadLevelSelectCanvas);
        ///TODO Add customize button listener and logic
        optionsButton.onClick.AddListener(LoadOptionsCanvas);
        levelSelectCanvas.enabled = false;
        optionsCanvas.enabled = false;
    }

    void LoadLevelSelectCanvas()
    {
        levelSelectCanvas.enabled = true;
        mainCanvas.enabled = false;
    }

    void LoadOptionsCanvas()
    {
        optionsCanvas.enabled = true;
        mainCanvas.enabled = false;
    }

    //private void OnGUI()
    //{
    //    if(GUI.Button(new Rect(10, 10, 150, 100), "I am a button"))
    //    {
    //        Debug.Log("You Clicked the Button!");
    //    }
    //}
}
