using UnityEngine;
using System.Collections;

public class MouseDrag : MonoBehaviour {

	private Vector3 position {
		get { return transform.position; }
		set { transform.position = value; }
	}

	private float distanceFromCamera = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 leftBound = Camera.main.ScreenToWorldPoint (new Vector3 (
			0f, 0f, distanceFromCamera)),
				rightBound = Camera.main.ScreenToWorldPoint(new Vector3(
			Screen.width, Screen.height, distanceFromCamera));

		if (position.x < leftBound.x) {
			Vector3 newPos = new Vector3 (leftBound.x, position.y, position.z);
			transform.position = newPos;
		} else if (position.x > rightBound.x) {
			Vector3 newPos = new Vector3 (rightBound.x, position.y, position.z);
			transform.position = newPos;
		}
	}

	void OnMouseDrag() {
		var screenPos = new Vector3 (Input.mousePosition.x,
						Input.mousePosition.y, distanceFromCamera);
		var mousePos = Camera.main.ScreenToWorldPoint (screenPos);
		Debug.Log (mousePos);
		if (mousePos.y < 1f)
			mousePos.y = 1f;
		transform.position = mousePos;
	}
}
