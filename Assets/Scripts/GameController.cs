using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(MazeConstructor))]               // 1

public class GameController : MonoBehaviour
{
    public static int hei;
    public static int hai;
    [SerializeField] private FpsMovement player;
    [SerializeField] private Text timeLabel;
    [SerializeField] private Text scoreLabel;

    private MazeConstructor generator;

    private DateTime strtTime;
    private int tmeLimit;
    private int reduceLimitBy;

    private int scre;
    private bool goalReached;

    // Use this for initialization
    void Start()
    {
        generator = GetComponent<MazeConstructor>();
        StartNewGame();
    }

    private void StartNewGame()
    {
        tmeLimit = 100;
        reduceLimitBy = 5;
        strtTime = DateTime.Now;

        scre = 0;
        scoreLabel.text = scre.ToString();

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
        tmeLimit -= reduceLimitBy;
        strtTime = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.enabled)
        {
            return;
        }

        int timeUsed = (int)(DateTime.Now - strtTime).TotalSeconds;
        int timeLeft = tmeLimit - timeUsed;

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

        scre += 1;
        scoreLabel.text = scre.ToString();

        
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