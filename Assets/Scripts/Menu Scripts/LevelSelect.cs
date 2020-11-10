using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class LevelSelect : MonoBehaviour
{
    public List<Button> levelSelectButtons;

    public Canvas mainCanvas;
    public Canvas levelSelectCanvas;

    // Start is called before the first frame update
    void Start()
    {
        levelSelectButtons = levelSelectCanvas.GetComponentsInChildren<Button>(true).ToList();
        levelSelectButtons[0].onClick.AddListener(BackToMainMenuFromLevelSelect); //This is the main menu button

        for (int i = 1; i < levelSelectButtons.Count; i++)
        {
            int temp = i;
            levelSelectButtons[i].onClick.AddListener(delegate { LoadSelectedLevel(temp); });
        }
    }

    void BackToMainMenuFromLevelSelect()
    {
        mainCanvas.enabled = true;
        levelSelectCanvas.enabled = false;
    }

    void LoadSelectedLevel(int sceneID)
    {
        Debug.Log("Loaded Level: " + sceneID);
        ///TODO add actual logic for loading the correct scene and unloading the main menu scene
    }
}
