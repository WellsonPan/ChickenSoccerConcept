using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject goal;
    public GameObject chicken;
    public GameObject player;

    public Canvas levelCompletedMenu;
    public Text timeCompletedText;
    public Button nextLevelButton;

    public bool levelCompleted;
    private int currentLevel;
    private float timeOfLevelCompletion;
    private byte timeCountOnce;

    private void Awake()
    {
        Application.targetFrameRate = 300; //sets the framerate, 300 = uncapped
    }

    // Start is called before the first frame update
    void Start()
    {
        levelCompletedMenu.enabled = false;
        goal = GameObject.FindGameObjectWithTag("Finish");
        chicken = GameObject.FindGameObjectWithTag("Chicken");
        player = GameObject.FindGameObjectWithTag("Player");
        levelCompleted = false;
        timeCountOnce = 0;
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        nextLevelButton.onClick.AddListener(LoadNextLevel);
        //Debug.Log(currentLevel);
    }

    // Update is called once per frame
    void Update()
    {
        if(goal.GetComponent<Goal>().chickenEntered)
        {
            levelCompleted = true;
            levelCompletedMenu.enabled = true;
            if (timeCountOnce == 0)
            {
                timeOfLevelCompletion = Time.timeSinceLevelLoad; //This grabs the time to complete the level
                timeCountOnce++; //This is so that the level completion time is only grabbed once
                //Debug.Log(timeOfLevelCompletion);
            }
            chicken.GetComponent<ChickenMovement>().enabled = false;
            player.GetComponent<PlayerMovement>().enabled = false;

            timeCompletedText.text = "Time Completed:\n" + timeOfLevelCompletion;
            GlobalVariables.unlockedLevels[currentLevel] = true;

            SaveGame();
        }
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene(currentLevel + 1);
        SceneManager.UnloadSceneAsync(currentLevel);
    }

    void SaveGame()
    {
        //TODO Add logic to save the game as binary file
    }
}
