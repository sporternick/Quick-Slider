using System.Collections.Generic;
using UnityEngine;

public class Level
{
    private List<Round> _rounds ;
    public int RoundNumber;
    public Round CurrentRound;
    public bool LevelCompleted = false;
    private const int NbRounds = 5; //number of rounds to complete a level of the game

    public readonly Mode _mode;
    private readonly Difficulty _difficulty;


    public Level(Mode mode, Difficulty difficulty){
        _mode = mode;
        _difficulty = difficulty;
    }

    public void InitLevel()
    {
        Debug.Log("Initiating level...");
        LevelCompleted = false;
        _rounds = new List<Round>();
        RoundNumber = 1;
        CurrentRound = NewRound();
    }

    private Round NewRound()
    {
        return
            _mode == Mode.Accuracy ?
                (Round) new AccurateRound(RoundNumber, (int) _difficulty) :
                (Round) new QuickRound(RoundNumber, (int) _difficulty) ;
    }

    private void NextRound(){
        if(_rounds.Count < NbRounds) _rounds.Add(CurrentRound);
        RoundNumber++;
        if (RoundNumber >= NbRounds)
        {
            TerminateLevel();
        }
        else
        {
            CurrentRound = NewRound();
        }
    }

    private void TerminateLevel()
    {
        LevelCompleted = true;
        ComputeScore();
    }

    private void ComputeScore()
    {
        //use _rounds
        Debug.Log("Score should be computed now.");
    }

    public override string ToString()
    {
        return _mode + " level of difficulty " + _difficulty;
    }

    public int GetNbRounds()
    {
        return NbRounds;
    }


}
