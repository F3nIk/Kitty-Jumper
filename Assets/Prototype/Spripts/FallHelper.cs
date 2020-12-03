using System.Collections.Generic;
using MalbersAnimations;
using MalbersAnimations.Controller;
using UnityEngine;

public class FallHelper : MonoBehaviour
{
	[SerializeField] private List<Collider> conflictColliders;
	[SerializeField] private StateID targetState;

	private void Update()
	{
		if(GetComponent<MAnimal>().activeState.ID == targetState)
		{
			DisableColliders();
		}
		else
		{
			EnableColliders();
		}
	}

	private void EnableColliders()
	{
		foreach (Collider collider in conflictColliders)
		{
			collider.enabled = true;
		}
	}

	private void DisableColliders()
	{
		foreach (Collider collider in conflictColliders)
		{
			collider.enabled = false;
		}
	}
}
