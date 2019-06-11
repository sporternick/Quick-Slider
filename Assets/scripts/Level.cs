using System.Collections.Generic;
using UnityEngine;

public class Level
{
    public List<Round> Rounds ;
    public int RoundNumber;
    public Round CurrentRound;
    public bool Completed = false;
    public int NbRounds = 10 ; //number of rounds to complete a level of the game

    private readonly Mode _mode;
    private readonly Difficulty _difficulty;


    public Level(Mode mode, Difficulty difficulty){
        
        Debug.Log("creating level " + mode);
        
        _mode = mode;
        _difficulty = difficulty;
        
        Rounds = new List<Round>();
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

    public void NextRound(){
        Rounds.Add(CurrentRound);
        RoundNumber++;
        if (RoundNumber > NbRounds)
        {
            Completed = true;
        }
        else
        {
            CurrentRound = NewRound();    
        }
        
    }

	

	

    
}