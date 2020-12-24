using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class EventButton : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
	[SerializeField] private UnityEvent onButtonDown;
	[SerializeField] private UnityEvent onButtonUp;
	[SerializeField] private UnityEvent onButtonClick;

	private Button button;

	private void Start()
	{
		TryGetComponent(out button);
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		onButtonClick?.Invoke();
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		onButtonDown?.Invoke();
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		onButtonUp?.Invoke();
	}
}
