using MalbersAnimations;
using UnityEngine;

[RequireComponent(typeof(MalbersInput))]
public class InputType : MonoBehaviour
{
	private void Start()
	{
		SetInputType();
	}

#if UNITY_STANDALONE

	private void SetInputType()
	{
		if (TryGetComponent<MalbersInput>(out var mInput)) mInput.enabled = true;	
	}

#endif
}
