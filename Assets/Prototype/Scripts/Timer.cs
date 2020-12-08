using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField] [Tooltip("Level duration in seconds")] [Range(0, 300f)] private float duration = 0;
	[SerializeField] [Tooltip("Label to show current timer value (default = null)")] private TextMeshProUGUI label;

	public event UnityAction TimeOver;

	private float timeLeft;

	private void OnEnable()
	{
		timeLeft = duration;
	}

	private void OnDisable()
	{
		TimeOver?.Invoke();
	}

	private void Update()
	{
		timeLeft -= Time.deltaTime;

		if (timeLeft <= 0) enabled = false;

		if(label != null) UpdateLabel();
	}

	private void UpdateLabel()
	{
		DateTime left = new DateTime().AddSeconds(timeLeft > 0 ? timeLeft : 0);
		label.text = left.ToString("mm:ss");
	}
}
