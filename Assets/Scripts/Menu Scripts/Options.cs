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

    public Text muteAllButtonText;
    public Text muteMusicButtonText;
    public Text muteSfxButtonText;

    public Canvas mainCanvas;
    public Canvas optionsCanvas;

    private string checkedChar = "X";
    private string uncheckedChar = " ";

    // Start is called before the first frame update
    void Start()
    {
        muteAll.onClick.AddListener(MuteAllSounds);
        muteMusic.onClick.AddListener(MuteAllMusic);
        muteSFX.onClick.AddListener(MuteAllSFX);
        mainMenuButton.onClick.AddListener(BackToMainMenuFromOptions);

        //Write logic to read from save to set global variables and the menu items
    }

    void BackToMainMenuFromOptions()
    {
        mainCanvas.enabled = true;
        optionsCanvas.enabled = false;
    }

    //TODO change all the Debug statements to actual audio logic to mute and unmute sounds

    void MuteAllSounds()
    {
        if (!GlobalVariables.mutedAllMusic || !GlobalVariables.mutedAllSFX)
        {
            //Debug.Log("All sounds have been muted");
            GlobalVariables.mutedAllMusic = true;
            GlobalVariables.mutedAllSFX = true;
            muteAllButtonText.text = checkedChar;
            muteMusicButtonText.text = checkedChar;
            muteSfxButtonText.text = checkedChar;
        }
        else
        {
            //Debug.Log("All sounds have been unmuted");
            GlobalVariables.mutedAllMusic = false;
            GlobalVariables.mutedAllSFX = false;
            muteAllButtonText.text = uncheckedChar;
            muteMusicButtonText.text = uncheckedChar;
            muteSfxButtonText.text = uncheckedChar;
        }
    }

    void MuteAllMusic()
    {
        if (!GlobalVariables.mutedAllMusic)
        {
            //Debug.Log("All music have been muted");
            GlobalVariables.mutedAllMusic = true;
            muteMusicButtonText.text = checkedChar;
            if (GlobalVariables.mutedAllSFX)
            {
                muteAllButtonText.text = checkedChar;
            }
        }
        else
        {
            //Debug.Log("All music have been unmuted");
            GlobalVariables.mutedAllMusic = false;
            muteMusicButtonText.text = uncheckedChar;
            muteAllButtonText.text = uncheckedChar;
        }
    }

    void MuteAllSFX()
    {
        if (!GlobalVariables.mutedAllSFX)
        {
            //Debug.Log("All SFX have been muted");
            GlobalVariables.mutedAllSFX = true;
            muteSfxButtonText.text = checkedChar;
            if (GlobalVariables.mutedAllMusic)
            {
                muteAllButtonText.text = checkedChar;
            }
        }
        else
        {
            //Debug.Log("All SFX have been unmuted");
            GlobalVariables.mutedAllSFX = false;
            muteSfxButtonText.text = uncheckedChar;
            muteAllButtonText.text = uncheckedChar;
        }
    }
}
