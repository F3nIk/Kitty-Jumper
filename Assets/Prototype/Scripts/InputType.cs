using MalbersAnimations;
using UnityEngine;

[RequireComponent(typeof(MalbersInput))]
public class InputType : MonoBehaviour
{


#if UNITY_STANDALONE
	private void Start()
	{
		SetInputType();
	}

	private void SetInputType()
	{
		if (TryGetComponent<MalbersInput>(out var mInput)) mInput.enabled = true;	
	}

#endif
}
