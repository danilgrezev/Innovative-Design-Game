using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(MazeConstructor))]               // 1

//public class GameController : MonoBehaviour
//{
//    private MazeConstructor generator;

//    void Start()
//    {
//        generator = GetComponent<MazeConstructor>();      // 2
//        generator.GenerateNewMaze(31, 33);
//    }
//}


[RequireComponent(typeof(MazeConstructor))]

public class GameController : MonoBehaviour
{
    public static int hei;
    public static int hai;
    [SerializeField] private FpsMovement player;
    [SerializeField] private Text timeLabel;
    [SerializeField] private Text scoreLabel;

    private MazeConstructor generator;

    private DateTime startTime;
    private int timeLimit;
    private int reduceLimitBy;

    private int score;
    private bool goalReached;

    // Use this for initialization
    void Start()
    {
        generator = GetComponent<MazeConstructor>();
        StartNewGame();
    }

    private void StartNewGame()
    {
        timeLimit = 80;
        reduceLimitBy = 5;
        startTime = DateTime.Now;

        score = 0;
        scoreLabel.text = score.ToString();

        StartNewMaze();
    }

    private void StartNewMaze()
    {
        int[] a = new int[] {15, 17, 19, 21, 23, 25, 27, 29, 31, 33, 35 };
        System.Random rand = new System.Random();
        int i = rand.Next(0, 10);
        int i1 = rand.Next(0, 10);
        hei = a[i];
        hai = a[i1];
        Debug.Log(hei);
        Debug.Log(hai);


        generator.GenerateNewMaze(hei, hai, OnStartTrigger, OnGoalTrigger);

        float x = generator.startCol * generator.hallWidth;
        float y = 1;
        float z = generator.startRow * generator.hallWidth;
        player.transform.position = new Vector3(x, y, z);

        goalReached = false;
        player.enabled = true;

        // restart timer
        timeLimit -= reduceLimitBy;
        startTime = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.enabled)
        {
            return;
        }

        int timeUsed = (int)(DateTime.Now - startTime).TotalSeconds;
        int timeLeft = timeLimit - timeUsed;

        if (timeLeft > 0)
        {
            timeLabel.text = timeLeft.ToString();
        }
        else
        {
            timeLabel.text = "TIME UP";
            player.enabled = false;

            Invoke("StartNewGame", 4);
        }
    }
    

    private void OnGoalTrigger(GameObject trigger, GameObject other)
    {
        
        goalReached = true;

        score += 1;
        scoreLabel.text = score.ToString();

        
    }

    private void OnStartTrigger(GameObject trigger, GameObject other)
    {
        if (goalReached)
        {
            Debug.Log("Finish!");
            player.enabled = false;

            Invoke("StartNewMaze", 4);
        }

       
    }
}