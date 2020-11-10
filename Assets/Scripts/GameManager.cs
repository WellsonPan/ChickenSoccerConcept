using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject goal;
    public GameObject chicken;
    public GameObject player;

    public bool levelCompleted;
    private float timeOfLevelCompletion;
    private byte timeCountOnce;

    // Start is called before the first frame update
    void Start()
    {
        goal = GameObject.FindGameObjectWithTag("Finish");
        chicken = GameObject.FindGameObjectWithTag("Chicken");
        player = GameObject.FindGameObjectWithTag("Player");
        levelCompleted = false;
        timeCountOnce = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(goal.GetComponent<Goal>().chickenEntered)
        {
            levelCompleted = true;
            if (timeCountOnce == 0)
            {
                timeOfLevelCompletion = Time.timeSinceLevelLoad;
                timeCountOnce++;
            }
            Debug.Log(timeOfLevelCompletion);
            chicken.GetComponent<ChickenMovement>().enabled = false;
            player.GetComponent<PlayerMovement>().enabled = false;
        }
    }
}
