using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PausedMenu : MonoBehaviour
{
    public Button muteAllButton;
    public Button muteMusicButton;
    public Button muteSfxButton;
    public Button mainMenuButton;

    public Text muteAllButtonText;
    public Text muteMusicButtonText;
    public Text muteSfxButtonText;

    private string checkedChar = "X";
    private string uncheckedChar = " ";

    // Start is called before the first frame update
    void Start()
    {
        muteAllButton.onClick.AddListener(MuteAllSounds);
        muteMusicButton.onClick.AddListener(MuteAllMusic);
        muteSfxButton.onClick.AddListener(MuteAllSFX);
        mainMenuButton.onClick.AddListener(ReturnToMainMenu);

        MuteAllSounds();
        MuteAllMusic();
        MuteAllSFX();
    }

    void MuteAllSounds()
    {
        if (!GlobalVariables.mutedAllMusic || !GlobalVariables.mutedAllSFX)
        {
            Debug.Log("All sounds have been muted");
            GlobalVariables.mutedAllMusic = true;
            GlobalVariables.mutedAllSFX = true;
            muteAllButtonText.text = checkedChar;
            muteMusicButtonText.text = checkedChar;
            muteSfxButtonText.text = checkedChar;
        }
        else
        {
            Debug.Log("All sounds have been unmuted");
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
            Debug.Log("All music have been muted");
            GlobalVariables.mutedAllMusic = true;
            muteMusicButtonText.text = checkedChar;
            if(GlobalVariables.mutedAllSFX)
            {
                muteAllButtonText.text = checkedChar;
            }
        }
        else
        {
            Debug.Log("All music have been unmuted");
            GlobalVariables.mutedAllMusic = false;
            muteMusicButtonText.text = uncheckedChar;
            muteAllButtonText.text = uncheckedChar;
        }
    }

    void MuteAllSFX()
    {
        if (!GlobalVariables.mutedAllSFX)
        {
            Debug.Log("All SFX have been muted");
            GlobalVariables.mutedAllSFX = true;
            muteSfxButtonText.text = checkedChar;
            if(GlobalVariables.mutedAllMusic)
            {
                muteAllButtonText.text = checkedChar;
            }
        }
        else
        {
            Debug.Log("All SFX have been unmuted");
            GlobalVariables.mutedAllSFX = false;
            muteSfxButtonText.text = uncheckedChar;
            muteAllButtonText.text = uncheckedChar;
        }
    }

    void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
