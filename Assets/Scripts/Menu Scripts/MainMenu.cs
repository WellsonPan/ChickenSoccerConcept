using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        playButton.onClick.AddListener(PlayButtonClicked);
        levelSelectButton.onClick.AddListener(LoadLevelSelectCanvas);
        //TODO Change customize to "How to Play" and add custom listener for that
        optionsButton.onClick.AddListener(LoadOptionsCanvas);
        levelSelectCanvas.enabled = false;
        optionsCanvas.enabled = false;
    }

    void PlayButtonClicked()
    {
        mainCanvas.enabled = false;
        SceneManager.LoadScene(1);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
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
