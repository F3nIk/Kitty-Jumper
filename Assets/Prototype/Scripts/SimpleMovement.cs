using MalbersAnimations.Controller;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private float speedX = 0;
    [SerializeField] private float speedY = 0;
    [SerializeField] private float rotationSpeed = 0;
    [SerializeField] private float gravity = 0;

    [SerializeField] private float jumpSpeed = 0;

    private Vector3 moveDirection = Vector3.zero;
    private Vector3 rawLookDirection => transform.position - camera.transform.position;
    private Vector3 lookDirection => new Vector3(rawLookDirection.x, 0, rawLookDirection.z).normalized;
    private Vector3 gravityDirection => Vector3.down * gravity;

    private bool isGrounded = false;

    private MAnimal animalController;
    private Rigidbody rigidbody;

	private void Start()
	{
        TryGetComponent(out animalController);
        TryGetComponent(out rigidbody);

	}

	private void FixedUpdate()
	{
        //if(animalController.Grounded == false) Gravity();
    }

	public void MoveWithJoystick(Vector2 axis)
    {
        Vector3 moveToLook = new Vector3(lookDirection.x, moveDirection.y, lookDirection.z).normalized;

        float angle = CalculateRotationAngle(axis);

        //Move forward with rotation
        if (axis.y > 0)
        {
            //transform.Translate(moveToLook * Time.deltaTime, Space.World);

            //rigidbody.AddForce(moveToLook * 10f);
            rigidbody.velocity = moveToLook;

            if (axis.x < 0) angle *= -1;


        }
        //Move back with inverse rotation
        else if(axis.y < 0)
        {
            Vector3 moveToLookBack = new Vector3(-lookDirection.x, 0, -lookDirection.z).normalized;
            //transform.Translate(moveToLookBack * Time.deltaTime, Space.World);

            //rigidbody.AddForce(moveToLookBack * 10f);
            rigidbody.velocity = moveToLookBack;


            if (axis.x > 0) angle *= -1;

        }
        //Rotate in place
        else
        {
            if (axis.x < 0) angle *= -1;
        }

        if (transform.rotation.eulerAngles.y != Mathf.Abs(angle)) transform.Rotate(Vector3.up, angle * Mathf.Abs(axis.x) * Time.deltaTime);
    }

    public void Jump()
    {

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

    private void Gravity()
    {
        transform.Translate(gravityDirection * Time.deltaTime);
    }

	private void OnCollisionEnter(Collision collision)
	{
        isGrounded = true;
        Debug.Log("grounded");

    }
}
