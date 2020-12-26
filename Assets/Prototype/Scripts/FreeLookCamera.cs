using System.Collections;
using UnityEngine;

public class FreeLookCamera : MonoBehaviour
{
	[SerializeField] private float forwardLoopSensitivity = 1.25f;
	[SerializeField] private float freelookLoopSensitivity = 0.05f;
	
	private Vector3 forwardDirection = Vector3.zero; 
	private Vector2 joystickAxis = Vector2.zero;

	private Quaternion lastCameraRotation = Quaternion.identity;
	private bool isUnlock = false;
	private float freeLoopTimer = 0;
	private float forwardLoopTimer = 0;

	private void Start()
	{
		forwardDirection = transform.localRotation.eulerAngles;
		lastCameraRotation = transform.localRotation;
	}

	private void Update()
	{
		if(isUnlock)
		{
			FreeRotateCamera();
		}
		else
		{
			RotateToForward();
		}
	}

    public void UnlockCamera(bool state)
    {
		isUnlock = state;
	}

	public void GetJoystickAxis(Vector2 axis)
	{
		joystickAxis = axis;
	}

	private void RotateToForward()
	{
		freeLoopTimer = 0;

		if (Vector3.Distance(lastCameraRotation.eulerAngles, forwardDirection) > 1)
		{
			if (forwardLoopTimer >= 1) return;

			transform.localRotation = Quaternion.Lerp(lastCameraRotation, Quaternion.Euler(forwardDirection), forwardLoopTimer);
			forwardLoopTimer += forwardLoopSensitivity * Time.deltaTime;
		}
	}

	private void FreeRotateCamera()
	{
		float angle = GetRotationAngle();

		if (float.IsNaN(angle)) return;

		Vector3 rotation = new Vector3(forwardDirection.x, angle, 0);

		freeLoopTimer += freeLoopTimer > 1 ? -freeLoopTimer : freelookLoopSensitivity * Time.deltaTime;

		transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(rotation), freeLoopTimer);
		lastCameraRotation = transform.localRotation;

		forwardLoopTimer = 0;
	}

	private float GetRotationAngle()
	{
		Vector2 axis = new Vector2(joystickAxis.x, Mathf.Abs(joystickAxis.y));

		Vector2 forwardAxis = new Vector2(0, 1);
		Vector2 currentAxis = axis;

		float dot = Vector2.Dot(forwardAxis, currentAxis);
		float cosA = dot / (forwardAxis.magnitude * currentAxis.magnitude);
		float angle = Mathf.Acos(cosA) * Mathf.Rad2Deg;

		if (joystickAxis.x < 0) angle *= -1;

		return angle;
	}
}
