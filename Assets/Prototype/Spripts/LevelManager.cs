using System.Collections;
using System.Collections.Generic;
using Doozy.Engine.Nody;
using Doozy.Engine.Nody.Models;
using Doozy.Engine.Progress;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	[SerializeField] private Graph ingameGraph;
	[SerializeField] private Timer timer;
	private void OnEnable()
	{
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
