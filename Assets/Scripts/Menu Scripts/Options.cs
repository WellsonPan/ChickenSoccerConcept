using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public Button mainMenuButton;
    public Button muteAll;
    public Button muteMusic;
    public Button muteSFX;

    public Canvas mainCanvas;
    public Canvas optionsCanvas;

    // Start is called before the first frame update
    void Start()
    {
        muteAll.onClick.AddListener(MuteAllSounds);
        muteMusic.onClick.AddListener(MuteAllMusic);
        muteSFX.onClick.AddListener(MuteAllSFX);
        mainMenuButton.onClick.AddListener(BackToMainMenuFromOptions);

        GlobalVariables.mutedAllMusic = false;
        GlobalVariables.mutedAllSFX = false;
    }

    void BackToMainMenuFromOptions()
    {
        mainCanvas.enabled = true;
        optionsCanvas.enabled = false;
    }

    //TODO change all the Debug statements to actual audio logic to mute and unmute sounds

    void MuteAllSounds()
    {
        if(!GlobalVariables.mutedAllMusic || !GlobalVariables.mutedAllSFX)
        {
            Debug.Log("All sounds have been muted");
            GlobalVariables.mutedAllMusic = true;
            GlobalVariables.mutedAllSFX = true;
        }
        else
        {
            Debug.Log("All sounds have been unmuted");
            GlobalVariables.mutedAllMusic = false;
            GlobalVariables.mutedAllSFX = false;
        }
    }

    void MuteAllMusic()
    {
        if (!GlobalVariables.mutedAllMusic)
        {
            Debug.Log("All music have been muted");
            GlobalVariables.mutedAllMusic = true;
        }
        else
        {
            Debug.Log("All music have been unmuted");
            GlobalVariables.mutedAllMusic = false;
        }
    }

    void MuteAllSFX()
    {
        if (!GlobalVariables.mutedAllSFX)
        {
            Debug.Log("All SFX have been muted");
            GlobalVariables.mutedAllSFX = true;
        }
        else
        {
            Debug.Log("All SFX have been unmuted");
            GlobalVariables.mutedAllSFX = false;
        }
    }
}
