using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField] [Tooltip("Time in seconds")] [Range(0, 300f)] private float Duration = 0;

	public event UnityAction TimeOver;

	private TextMeshProUGUI label;
	private float timeLeft;

	private void OnEnable()
	{
		timeLeft = Duration;
	}

	private void OnDisable()
	{
		TimeOver?.Invoke();
	}

	private void Start()
	{
		label = GetComponent<TextMeshProUGUI>();
	}

	private void Update()
	{
		timeLeft -= Time.deltaTime;

		if (timeLeft <= 0) enabled = false;

		UpdateLabel();
	}

	private void UpdateLabel()
	{
		DateTime left = new DateTime().AddSeconds(timeLeft > 0 ? timeLeft : 0);
		label.text = left.ToString("mm:ss");
	}
}
