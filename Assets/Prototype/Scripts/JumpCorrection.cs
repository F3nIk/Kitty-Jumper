using System.Collections;
using System.Collections.Generic;
using SplineMesh;
using UnityEngine;

public class JumpCorrection : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private List<Transform> points;
    [SerializeField] private float maxDistanceToPoint = 0;

    [SerializeField] private Spline spline;

    private float distanceToNearestPoint;
    private Vector3 directionToNearestPoint;
    private Vector3 nearestPointPosition;

    private Vector3 lookDirection => transform.position - cam.transform.position;

	private void Start()
	{
/*        Debug.Log("Point position" + FindNearestPoint());
        Debug.Log(GetDirectionToPoint(FindNearestPoint()));
        Debug.Log(GetAngle(lookDirection, GetDirectionToPoint(FindNearestPoint())));*/

    }

	private void Update()
	{
		if(Input.GetKey(KeyCode.Space))
        {
            /*var point = FindNearestPoint();
            var pointDirection = GetDirectionToPoint(point);
            DrawSpline(point, pointDirection);*/
            //float desiredY = Mathf.Abs(point.z - transform.position.z);
            //Vector3 desiredPosition = new Vector3(point.x, 1f + desiredY, point.z);
           // transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime);
        }
	}

	private Vector3 FindNearestPoint()
    {
        Vector3 nearestPoint = points[0].position;
		for (int i = 1; i < points.Count; i++)
		{
            if(GetDistanceToPoint(nearestPoint) > GetDistanceToPoint(points[i].position))
            {
                nearestPoint = points[i].position;
			}
        }

        return nearestPoint;
	}

    private float GetDistanceToPoint(Vector3 point)
    {
        return Vector3.Distance(transform.position, point); 
	}

	private Vector3 GetDirectionToPoint(Vector3 point)
	{
        return point - transform.position;
	}

    private float GetAngle(Vector3 from, Vector3 to)
    {
        return Vector3.Angle(from, to);
	}

    private void DrawSpline(Vector3 pointPosition, Vector3 pointDirection)
    {
        SplineNode selfNode = new SplineNode(transform.position, lookDirection);
        SplineNode pointNode = new SplineNode(pointPosition, pointDirection);

        //spline.InsertNode(1, selfNode);
        // spline.InsertNode(2, pointNode);
        spline.AddNode(selfNode);
        spline.AddNode(pointNode);

        spline.RemoveNode(spline.nodes[0]);
        spline.RemoveNode(spline.nodes[0]);
    }
}
