using UnityEngine;
using System.Collections;

public class RotateLeft : MonoBehaviour {

	public float RotationSpeed;

	void Update () {
		if (RotationSpeed != 0) {
				transform.Rotate(Vector3.left, RotationSpeed * Time.deltaTime);
		}
	}
}

