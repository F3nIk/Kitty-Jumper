using System.Collections;
using System.Collections.Generic;
using SplineMesh;
using UnityEngine;

public class SplineRenderer : MonoBehaviour
{
	public Animator animator;

	private void Update()
	{
		//Debug.Log(animator.bodyPosition);
	}

	private void OnAnimatorMove()
	{
		Debug.Log(animator.rootPosition);
	}
}
