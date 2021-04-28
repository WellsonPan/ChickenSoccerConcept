using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class LevelSelect : MonoBehaviour
{
    private List<Button> levelSelectButtons;
    public Button BackToMainMenuFromLevelSelectButton;

    public Canvas mainCanvas;
    public Canvas levelSelectCanvas;
    public GameObject levelSelectButtonGroup;

    private float calculateLargerScreenVal;
    private float calculateCellSize;
    private float calculateSpacing;
    private float calculateFontSize;

    private GridLayoutGroup levelSelectGrid;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Screen.width);
        Debug.Log(Screen.height);
        levelSelectButtonGroup.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
        levelSelectGrid = levelSelectButtonGroup.GetComponent<GridLayoutGroup>();
        if(Screen.width > Screen.height)
        {
            calculateLargerScreenVal = Screen.width;
        }
        else
        {
            calculateLargerScreenVal = Screen.height;
        }

        calculateCellSize = calculateLargerScreenVal / levelSelectGrid.constraintCount;
        calculateSpacing = calculateCellSize / 2f;
        calculateCellSize = (calculateLargerScreenVal - (levelSelectGrid.constraintCount * calculateSpacing)) / (levelSelectGrid.constraintCount * 2f);
        calculateSpacing = calculateCellSize / 2f;
        calculateFontSize = calculateCellSize / (levelSelectGrid.constraintCount - 1f);

        levelSelectGrid.cellSize = new Vector2 (calculateCellSize, calculateCellSize);
        levelSelectGrid.spacing = new Vector2 (calculateSpacing, calculateSpacing);

        levelSelectGrid.padding.bottom = (int)(calculateCellSize * 2f);
        levelSelectCanvas.GetComponent<VerticalLayoutGroup>().spacing = calculateCellSize * -2f;

        levelSelectButtons = levelSelectButtonGroup.GetComponentsInChildren<Button>(true).ToList();
        BackToMainMenuFromLevelSelectButton.onClick.AddListener(BackToMainMenuFromLevelSelect); //This is the main menu button

        for (int i = 0; i < levelSelectButtons.Count; i++)
        {
            int temp = i + 1;
            levelSelectButtons[i].GetComponentInChildren<Text>().text = temp.ToString();
            levelSelectButtons[i].GetComponentInChildren<Text>().fontSize = (int)calculateFontSize;
            levelSelectButtons[i].onClick.AddListener(delegate { LoadSelectedLevel(temp); });
        }
    }

    void BackToMainMenuFromLevelSelect()
    {
        mainCanvas.enabled = true;
        levelSelectCanvas.enabled = false;
    }

    void PrintSceneCount()
    {
        Debug.Log(SceneManager.sceneCount);
    }

    void LoadSelectedLevel(int sceneID)
    {
        Debug.Log("Loaded Level: " + sceneID);
        //TODO add actual logic for loading the correct scene and unloading the main menu scene
        SceneManager.LoadScene(sceneID);
        //SceneManager.SetActiveScene();
        Debug.Log(SceneManager.sceneCount);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
