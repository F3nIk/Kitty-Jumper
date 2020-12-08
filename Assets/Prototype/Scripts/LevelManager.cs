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
	private Timer timer;

	private void OnEnable()
	{
		TryGetComponent(out timer);
		timer.TimeOver += OnTimeOver;
	}

	private void OnDisable()
	{
		timer.TimeOver -= OnTimeOver;
	}

	private void OnTimeOver()
	{
		ingameGraph.SetActiveNodeByName("EndGameEvent");

	}
	

}
