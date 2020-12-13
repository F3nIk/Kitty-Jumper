using UnityEngine;
using Doozy.Engine.Nody.Models;

public class LevelManager : MonoBehaviour
{
	[SerializeField] private Graph ingameGraph;

	public void EndLevel()
	{
		ingameGraph.SetActiveNodeByName("EndGameEvent");
	}
}
