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


	protected Round (int index) {
		Index = index;
		Goal = Random.Range(0, 100);
	}

	protected abstract bool IsValueCorrect (int playerValue);

	public void CompleteRound()
	{
		Completed = true;
	
	}

}
