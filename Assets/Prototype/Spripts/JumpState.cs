using System.Collections;
using Doozy.Engine.Progress;
using MalbersAnimations.Controller;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Animator))]
public class JumpState : MonoBehaviour
{
	[SerializeField] private Progressor powerJumpProgressor;
	[SerializeField] private Jump jump;
    private float power = 0;
	private const float minPower = 0;
	private const float maxPower = 1f;
    public float Power => power;
	private bool invokeIncrease = false;
	private float startTime = 0;

	private Animator animator;


	private void Start()
	{
		TryGetComponent(out animator);
	}

	public void Increase(bool state)
	{
		invokeIncrease = state;		
	}

	private void Update()
	{
		if(invokeIncrease)
		{
			startTime += 0.5f * Time.deltaTime;

			power = Mathf.Lerp(minPower, maxPower, startTime);

			if(startTime > 1)
			{
				return;
			}
		}
		else
		{
			//startTime = 1;
			startTime -= 0.5f * Time.deltaTime;

			power = Mathf.Lerp(minPower, maxPower, startTime);

			if(startTime < 0)
			{
				startTime = 0;
				return;
			}
		}

		var jp = jump.jumpProfiles[0];
		jp.HeightMultiplier = 1 + power;
		jump.jumpProfiles[0] = jp;
		Debug.Log(jp.HeightMultiplier);
		powerJumpProgressor.SetValue(power);
		animator.SetFloat("JumpPower", power);
		//Debug.Log(power);
	}
}
