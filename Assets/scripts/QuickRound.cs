/**
 * QuickRound : a Round of type Quick
 *
 * 
 */

using System.Collections.Generic;

public class QuickRound : Round
{
	
	private static List<int> _accLevel = new List<int>() {4,2,1}; //Accuracy values for level (one-side threshold, i.e. +-threshold)

	private int Acc; //Accuracy : precision threshold level (0-2)

	public QuickRound(int index, int difficulty) : base (index)
	{
		Acc = _accLevel[difficulty];
	}

	protected override bool IsValueCorrect(int playerValue)
	{
		int lowerGoal = Goal - Acc;
		int upperGoal = Goal + Acc;
		return playerValue >= lowerGoal && playerValue <= upperGoal;
	}
}