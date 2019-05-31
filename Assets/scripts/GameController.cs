using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;
using Random = UnityEngine.Random;


public enum GameMode
{
    Speed, //reach the goal value as quick as possible, score based on time
    Accuracy //reach the closest value in a defined time, score based on accuracy
}

public enum GameControl
{
    Screen, //regular slider using the whole screen as input
    Radial //radial slider on the thumb side
}

public enum ThumbSide
{
    Left, //thumb on the left side of the screen = left hand
    Right //opposite, obviously == default
}


/**
 * gameController
 * a class that keeps the game state persistent between scenes
 */
public class GameController : MonoBehaviour
{
    //game settings
    public GameMode gamemode ;
    public GameControl gamecontrol ;
    public ThumbSide thumbside ;
    public int Level ;
    public int goalValue ;
    public bool levelCompleted = false;

    void Start()
    {
        Level = 1;
        goalValue = Random.Range(0, 100);
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject); //don't destroy game controller between scenes
    }
    
    public void CheckValue(int value)
    {
        Debug.Log("checking value : " + value);

        levelCompleted = value == goalValue; //level is complete if the user value equals the goal

    }
    
        
}