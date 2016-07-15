using System;
using UnityEngine;

public static class MouseInterpreter
{
	private static float distanceFromGround = 3f;
	private static float zScalingFactor = 0.1f;

	/// <summary>
	/// Gets the mouse position on the plane.
	/// </summary>
	/// <returns>The position on plane, if the mouse is pointed at the plane. 
	/// The zero vector if the mouse is pointed at the sky.</returns>
	public static Vector3 GetMousePosOnPlane() {
		// Debug.Log (Input.mousePosition);

		var plane = new Plane(Vector3.up, Vector3.zero);
		var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		float distance;
		if (plane.Raycast (ray, out distance)) {
			var point = ray.GetPoint (distance);
			return new Vector3 (point.x, distanceFromGround, point.z * zScalingFactor);
		}
		return Vector3.zero;
	}
}
	