using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
    public Canvas menu;
    public Canvas pausedMenu;

    public Button menuButton;

    public bool isPaused;

    //TODO add an event to send to game manager to set the time to 0 so it pauses the game

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        pausedMenu.enabled = isPaused;
        menuButton.onClick.AddListener(ShowPauseMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowPauseMenu()
    {
        if(!isPaused)
        {
            isPaused = true;
            Time.timeScale = 0f;
            pausedMenu.enabled = isPaused;
        }
        else
        {
            isPaused = false;
            Time.timeScale = 1f;
            pausedMenu.enabled = false;
        }
    }
}
