/**
 * QuickRound : a Round of type Quick
 *
 * 
 */

using System.Collections.Generic;
using UnityEngine;

public class QuickRound : Round
{
	
	private static List<int> _accLevel = new List<int>() {4,2,1}; //Accuracy values for level (one-side threshold, i.e. +-threshold)

	private readonly int _acc; //Accuracy : precision threshold level (0-2)

	public QuickRound(int currentRoundIndex, int difficulty) : base (currentRoundIndex)
	{
		_acc = _accLevel[difficulty];
		Debug.Log("Created QuickRound, accuracy threshold = " + _acc);
	}

	protected override bool IsValueCorrect(int valueToCheck)
	{
		int lowerGoal = Goal - _acc;
		int upperGoal = Goal + _acc;
		return valueToCheck >= lowerGoal && valueToCheck <= upperGoal;
	}

	public override void StartRound()
	{
		//starting cooldown
		//start time counting
		//wait for onPointerUp
		//freeze, collect value
		//complete
	}

	public override string GetInstructions()
	{
		return "Get as fast as possible to the value !";
	}
}