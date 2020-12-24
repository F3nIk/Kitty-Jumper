using UnityEngine;

public class FreeLookCamera : MonoBehaviour
{
	private Vector3 followDirection = Vector3.zero; 
	private Vector2 joystickAxis = Vector2.zero;

	private bool isUnlock = false;

	private void Start()
	{
		followDirection = transform.localRotation.eulerAngles;
	}

	private void Update()
	{
		if (isUnlock == false)
		{
			RotateToForward();
			return; // todo: smooth movement or something cool for camera
		}

		if (joystickAxis != Vector2.zero)
		{
			FreeRotateCamera();
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
		transform.localRotation = Quaternion.Euler(followDirection);
	}

	private void FreeRotateCamera()
	{
		float angle = CalculateRotationAngle(joystickAxis);

		if (joystickAxis.x < 0) angle *= -1;

		Vector3 rotation = new Vector3(22, angle, 0);

		transform.localRotation = Quaternion.Euler(rotation);
	}

	private float CalculateRotationAngle(Vector2 axis)
	{
		Vector2 forwardAxis = new Vector2(0, 1);
		Vector2 currentAxis = axis;

		float dot = Vector2.Dot(forwardAxis, currentAxis);
		float cosA = dot / (forwardAxis.magnitude * currentAxis.magnitude);
		float angle = Mathf.Acos(cosA) * Mathf.Rad2Deg;

		return angle;
	}
}
