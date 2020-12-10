using Doozy.Engine.Progress;
using MalbersAnimations;
using MalbersAnimations.Controller;
using UnityEngine;

public class JumpState : MonoBehaviour
{
	[SerializeField] private Progressor powerJumpProgressor;
	[SerializeField] private MAnimal controller;
	[SerializeField] private StateID jumpId;

	[SerializeField] [Range(0.01f, 1f)] private float powerIncreaseStep = 0.5f;
	[SerializeField] [Range(0f, 2f)] private float jumpHeightPowerMultiplier = 0;
	[SerializeField] [Range(0f, 2f)] private float jumpForwardPowerMultiplier = 0;

	[Header("POWER OF JUMP")]
	public FloatEvent OnValueChange;

	private float power = 0;
	private const float minPower = 0;
	private const float maxPower = 1f;

	private bool invokeIncrease = false;
	private float startTime = 0;

	private void Start()
	{
		if (powerJumpProgressor == null) powerJumpProgressor = GameObject.Find("Jump Progress Bar").GetComponent<Progressor>();
	}

	private void Update()
	{
		if (power <= 0) return;

		if (invokeIncrease)
		{
			IncreasePower();
		}
		else
		{
			DecreasePower();
		}

		UpdateProgressBar();
		UpdateJumpProfile();
	}

	public void Increase(bool state)
	{
		invokeIncrease = state;
	}

	private void IncreasePower()
	{
		startTime += powerIncreaseStep * Time.deltaTime;

		power = Mathf.Lerp(minPower, maxPower, startTime);

		if (startTime > 1)
		{
			return;
		}
	}

	private void DecreasePower()
	{
		startTime -= powerIncreaseStep * Time.deltaTime;

		power = Mathf.Lerp(minPower, maxPower, startTime);

		if (startTime < 0)
		{
			startTime = 0;
			return;
		}
	}

	private void UpdateProgressBar()
	{
		OnValueChange?.Invoke(power);
	}

	private void UpdateJumpProfile()
	{
		Jump jump = (Jump)controller.states.Find(state => state.ID == jumpId);
		var newProfile = jump.jumpProfiles[0];
		newProfile.HeightMultiplier = GetHeightMultiplier();
		newProfile.ForwardMultiplier = GetForwardMultiplier();
		jump.jumpProfiles[0] = newProfile;
	}

	private float GetHeightMultiplier()
	{
		return 1 + power * jumpHeightPowerMultiplier;
	}
	private float GetForwardMultiplier()
	{
		return 1 + power * jumpForwardPowerMultiplier;
	}
}
