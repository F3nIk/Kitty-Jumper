using System.Collections;
using System.Collections.Generic;
using MalbersAnimations.Events;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpButton : MonoBehaviour, IPointerUpHandler
{
	[SerializeField] private MEvent onJump;

	private Coroutine jump;

	public void OnPointerUp(PointerEventData eventData)
	{
		jump = StartCoroutine(Jump());
	}

	private IEnumerator Jump()
	{
		onJump?.Invoke(true);
		yield return new WaitForSeconds(0.25f);
		onJump?.Invoke(false);
	}
}
