/**
* Round
* a round consists of one try by the player to reach a value
*
*/

using UnityEngine;

public abstract class Round
{
	public bool Completed = false;
	public int Index;
	public int Goal ;


	protected Round (int currentRoundIndex) {
		Index = currentRoundIndex;
		Goal = Random.Range(0, 100);
	}

	public void CheckValue(int valueToCheck)
	{
		if (IsValueCorrect(valueToCheck)) CompleteRound();
	}

	public void CompleteRound()
	{
		Debug.Log("Round is complete!");
		Completed = true;
		//freeze slider
	}

	
	protected abstract bool IsValueCorrect (int valueToCheck);
	public abstract void StartRound();
	public abstract string GetInstructions();

}
