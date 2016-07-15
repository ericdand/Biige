using UnityEngine;
using System.Collections;

public class MouseDrag : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDrag() {
		var mousePos = MouseInterpreter.GetMousePosOnPlane ();
		if (mousePos != Vector3.zero) {
			transform.position = mousePos;
		}
	}
}
