using UnityEngine;
using Doozy.Engine.Nody.Models;

[RequireComponent(typeof(Timer))]
public class LevelManager : MonoBehaviour
{
	#region Singleton
	public static LevelManager Instance;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			Destroy(this);
		}
	}
	#endregion

	[SerializeField] private Graph ingameGraph;

	public void EndLevel()
	{
		ingameGraph.SetActiveNodeByName("EndGameEvent");

	}
}
