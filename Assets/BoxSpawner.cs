using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoxSpawner : MonoBehaviour {

	public List<GameObject> objects;
	IEnumerator<GameObject> objectsEnumerator;
	GameObject currentObject;

	// Use this for initialization
	void Start () {
		objectsEnumerator = objects.GetEnumerator ();
		currentObject = GetNextObject();
	}

	GameObject GetNextObject() {
		if (!objectsEnumerator.MoveNext ()) {
			objectsEnumerator.Reset ();
		}
		return objectsEnumerator.Current;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Cycle Object")) {
			currentObject = GetNextObject ();
		}
		if (Input.GetButtonDown ("Spawn Object")) {
			Instantiate (currentObject, MouseInterpreter.GetMousePosAbovePlane(), Quaternion.identity);
		}
	}
}
