using System.Collections.Generic;

public class Level
{
    public List<Round> Rounds ;
    public int RoundNumber;
    public Round CurrentRound;
    public bool LevelCompleted = false;
    public int NbRounds = 10 ; //number of rounds to complete a level of the game

    public readonly Mode _mode;
    private readonly Difficulty _difficulty;


    public Level(Mode mode, Difficulty difficulty){
        
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
        CurrentRound = NewRound();
    }

	

	

    
}