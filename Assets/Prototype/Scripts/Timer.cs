using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
	[SerializeField] [Tooltip("Infinite time")] private bool testMode = false;
	[SerializeField] [Tooltip("Level duration in seconds")] [Range(0, 300f)] private float duration = 0;
	//[SerializeField] [Tooltip("Label to show current timer value (default = null)")] private TextMeshProUGUI label;

	public StringEvent OnValueChange;
	public UnityEvent OnTimeOver;

	private float timeLeft;

	#region Singleton
	public static Timer Instance;

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

	private void OnEnable()
	{
		timeLeft = duration;
	}

	private void Start()
	{
		/*if(label == null)
		{
			GameObject.FindGameObjectWithTag("Timer").TryGetComponent(out label);	
		}*/

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
			OnTimeOver?.Invoke();
			enabled = false;
		}
		UpdateLabel();
	}

	private void UpdateLabel()
	{
		if (testMode) OnValueChange?.Invoke("Infinite");
		else
		{
			DateTime left = new DateTime().AddSeconds(timeLeft > 0 ? timeLeft : 0);
			OnValueChange?.Invoke(left.ToString("mm:ss"));
		}
	}
}
