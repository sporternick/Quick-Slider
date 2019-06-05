/**
 * AccurateRound : a Round of type Accurate
 *
 * 
 */

using System.Collections.Generic;
using UnityEngine;

public class AccurateRound : Round
{
	
	private static List<int> _ttcLevel = new List<int>() {150,90,50}; //TimeToComplete values for level (seconds)
	
	private int _ttc; //TimeToComplete : allowed time level based on the difficulty (seconds)

	public AccurateRound(int currentRoundIndex, int difficulty) : base (currentRoundIndex)
	{
		_ttc = _ttcLevel[difficulty];
		Debug.Log("Created AccurateRound, time to complete = " + _ttc);
	}
	
	protected override bool IsValueCorrect(int valueToCheck)
	{
		int lowerGoal = Goal - 1;
		int upperGoal = Goal + 1;
		return valueToCheck >= lowerGoal && valueToCheck <= upperGoal;
	}

	public override void StartRound()
	{
		//starting cooldown
		//starting round cooldown Ttc
		//after Ttc, freeze and collect value
		//complete
	}

	public override string GetInstructions()
	{
		return "Get as close as possible to the value in a limited time!";
	}
}