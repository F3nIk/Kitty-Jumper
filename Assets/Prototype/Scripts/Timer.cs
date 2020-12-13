using UnityEngine;
using UnityEngine.Events;
using System;


public class Timer : MonoBehaviour
{
	[SerializeField] [Tooltip("Infinite time")] private bool testMode = false;
	[SerializeField] [Tooltip("Level duration in seconds")] [Range(0, 300f)] private float duration = 0;

	[SerializeField] private StringEvent onValueChange;
	[SerializeField] private UnityEvent onTimeOver;

	private float timeLeft;

	private void OnEnable()
	{
		timeLeft = duration;
	}

	private void Start()
	{
		if(testMode)
		{
			UpdateLabel();
			enabled = false;
		}
	}

	private void Update()
	{
		TickTimer();
	}

	private void TickTimer()
	{
		timeLeft -= Time.deltaTime;

		if (timeLeft <= 0)
		{
			onTimeOver?.Invoke();
			enabled = false;
		}
		UpdateLabel();
	}

	private void UpdateLabel()
	{
		if (testMode) onValueChange?.Invoke("Infinite");
		else
		{
			DateTime left = new DateTime().AddSeconds(timeLeft > 0 ? timeLeft : 0);
			onValueChange?.Invoke(left.ToString("mm:ss"));
		}
	}
}
