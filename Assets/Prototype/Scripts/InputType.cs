#if UNITY_EDITOR

using MalbersAnimations;
using UnityEngine;

[RequireComponent(typeof(MalbersInput))]
public class InputType : MonoBehaviour
{

	private void Start()
	{
		GetComponent<MalbersInput>().enabled = true;
	}

}

#endif