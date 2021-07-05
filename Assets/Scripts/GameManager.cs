using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject goal;
    public GameObject chicken;
    public GameObject player;

    public bool levelCompleted;
    private int currentLevel;
    private float timeOfLevelCompletion;
    private byte timeCountOnce;

    //TODO add an event listener to hear from the in game menu to pause the game

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 300; //sets the framerate, 300 = uncapped
        goal = GameObject.FindGameObjectWithTag("Finish");
        chicken = GameObject.FindGameObjectWithTag("Chicken");
        player = GameObject.FindGameObjectWithTag("Player");
        levelCompleted = false;
        timeCountOnce = 0;
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        //Debug.Log(currentLevel);
    }

    // Update is called once per frame
    void Update()
    {
        if(goal.GetComponent<Goal>().chickenEntered)
        {
            levelCompleted = true;
            if (timeCountOnce == 0)
            {
                timeOfLevelCompletion = Time.timeSinceLevelLoad; //This grabs the time to complete the level
                timeCountOnce++; //This is so that the level completion time is only grabbed once
                //Debug.Log(timeOfLevelCompletion);
            }
            chicken.GetComponent<ChickenMovement>().enabled = false;
            player.GetComponent<PlayerMovement>().enabled = false;
        }
    }
}
