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


public enum Mode
{
    Speedy, //reach the goal value as quick as possible, score based on time
    Accuracy //reach the closest value in a defined time, score based on accuracy
}

public enum SliderMode
{
    Vertical, //regular slider using the whole screen as input
    Radial //radial slider on the thumb side
}

public enum ThumbSide
{
    Left, //thumb on the left side of the screen = left hand
    Right //opposite, obviously == default
}

public enum Difficulty
{
    Easy,
    Medium,
    Hard
}


/**
 * gameController
 * a class that keeps the game state persistent between scenes
 */
public class GameController : MonoBehaviour
{
    //game settings
    public Mode Mode ;
    public SliderMode SliderMode ;
    public ThumbSide ThumbSide ;
    public Difficulty Difficulty ;


    public Level Level;
       
    void Start()
    {
        
    }

    public void StartLevel()
    {
        Level = new Level(Mode, Difficulty);
    }

    void Awake()
    {
        int numControllers = FindObjectsOfType<GameController>().Length;
        Debug.Log("number of game controllers : " + numControllers);
        if (numControllers != 1)
        {
            Debug.Log("destroying a game controller");
            Destroy(gameObject);
        }
        // if more then one game controller in the scene
        //destroy ourselves
        else
        {
            DontDestroyOnLoad(gameObject);
        }
        
    }

    
}