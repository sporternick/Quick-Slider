/**
 * AccurateRound : a Round of type Accurate
 *
 * 
 */

using System.Collections.Generic;

public class AccurateRound : Round
{
	
	private static List<int> _ttcLevel = new List<int>() {150,90,50}; //TimeToComplete values for level (seconds)
	
	private int Ttc; //TimeToComplete : allowed time level 

	public AccurateRound(int index, int difficulty) : base (index)
	{
		Ttc = _ttcLevel[difficulty];
	}
	
	protected override bool IsValueCorrect(int playerValue)
	{
		int lowerGoal = Goal - 1;
		int upperGoal = Goal + 1;
		return playerValue >= lowerGoal && playerValue <= upperGoal;
	}
	
}