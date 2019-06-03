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
    Speed, //reach the goal value as quick as possible, score based on time
    Accuracy //reach the closest value in a defined time, score based on accuracy
}

public enum Slider
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
    public Slider Slider ;
    public ThumbSide ThumbSide ;
    public Difficulty Difficulty ;

    public Level Level;
       
    void Start()
    {
        Debug.Log("Started Game Controller");
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject); //don't destroy game controller between scenes
    }

    public void StartLevel()
    {
        Debug.Log("Creation of a new level...");
        Level = new Level(Mode, Difficulty);
        Level.InitLevel();
        Debug.Log(Level.ToString());
    }

    public int GetRoundGoal()
    {
        return Level.CurrentRound.Goal;
    }

    public int GetRoundIndex()
    {
        return Level.CurrentRound.Index;
    }

    public int GetNbRounds()
    {
        return Level.GetNbRounds();
    }

    public string GetRoundInstructions()
    {
        return Level.CurrentRound.GetInstructions();
    }

    public void QuitLevel()
    {
        Level = null;
        SceneManager.LoadScene("menu");
    }
   
}