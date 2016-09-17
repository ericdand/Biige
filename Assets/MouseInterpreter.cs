using System;
using UnityEngine;

public static class MouseInterpreter
{
	private static float distanceFromGround = 5f;
	private static float zScalingFactor = 1f;

	/// <summary>
	/// Gets a point under the mouse, a fixed distance above the ground.
	/// </summary>
	/// <remarks>
	/// How the position is determined:
	/// 	- We have the camera's height Hc, 
	/// 	  the distance along the ray where it intersects the plane Dc, 
	/// 	  and a desired distance above the ground Hd. 
	/// 	- We seek Dd, the distance along the ray between where it intersects
	/// 	  the plane and our desired point.
	/// 	- Dd = Hd * (Dc / Hc)
	/// 	- Finally, we compute our desired point using ray.GetPoint to get the 
	/// 	  point which is (Dc - Dd) units along the ray.
	/// </remarks>
	/// <remarks>
	/// Note that this algorithm only really "works" (feels good) at certain camera 
	/// angles and distances. It also compensates for the near culling plane, 
	/// keeping objects sqrt(2) units away from the plane.
	/// </remarks>
	/// <returns>The position above plane, if the mouse is pointed at the plane. 
	/// The zero vector if the mouse is pointed at the sky.</returns>
	public static Vector3 GetMousePosAbovePlane() {
		var plane = new Plane(Vector3.up, Vector3.zero);
		var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		float distance;
		if (plane.Raycast (ray, out distance)) {
			var cam = Camera.main;
			var cameraHeight = cam.transform.position.y;
			var cscTheta = (distance / cameraHeight);
			// Debug.LogFormat ("{0} / {1} = {2}", distance, cameraHeight, cscTheta);
			var back = distanceFromGround * cscTheta;
			var point = ray.GetPoint (distance - back);
			// Debug.Log (point);
			return new Vector3 (point.x, point.y, 
				(float)Math.Max(point.z * zScalingFactor, 
					cam.transform.position.z + cam.nearClipPlane + 1.4143));
		}
		return Vector3.zero;
	}
}
	