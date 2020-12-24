using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

[ExecuteAlways]
public class SimpleRigidbody : MonoBehaviour
{
	[SerializeField] private Vector3 castSize = new Vector3(.5f, .5f, .5f);
	[SerializeField] private Vector3 centerOffset = Vector3.zero;
	[SerializeField] private float size;
	[SerializeField] private float maxDistance;
	[SerializeField] private Color gizmosColor = new Color(.2f, .8f, .4f, .6f);

	private Vector3 center => transform.localPosition;
	private Vector3 impulseDirection = Vector3.zero;

	private void FixedUpdate()
	{

	}

	private void OnDrawGizmos()
	{

		/*var hits = Physics.OverlapBox(center + centerOffset, castSize / 2);

		if (hits != null && hits.Length > 0)
		{
			Gizmos.color = Color.red;

			Gizmos.DrawWireCube(center + centerOffset, castSize);
		}
		else
		{
			Gizmos.color = Color.green;

			Gizmos.DrawWireCube(center + centerOffset, castSize);
		}*/

		if(Physics.Raycast(center + centerOffset, Vector3.left, out var hit, maxDistance))
		{
			Gizmos.color = Color.red;

			Gizmos.DrawLine(center + centerOffset, hit.point);

			impulseDirection = transform.position - hit.point;
			Debug.Log("ID => " + impulseDirection);
			StartCoroutine(GetImpulse(impulseDirection));
		}
		else
		{
			Gizmos.color = Color.green;

			Gizmos.DrawLine(center + centerOffset, center + centerOffset + Vector3.left * maxDistance);
		}

		
		
	}

	IEnumerator GetImpulse(Vector3 direction)
	{
		while(Vector3.Distance(transform.position, direction) < 2f)
		{
			//Debug.Log("impuls");
			transform.Translate(direction * Time.deltaTime);
			yield return null;
		}

		impulseDirection = Vector3.zero;
		StopAllCoroutines();
	}

	

}
