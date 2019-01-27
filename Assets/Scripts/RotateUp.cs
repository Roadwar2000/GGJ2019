using UnityEngine;
using System.Collections;

public class RotateUp : MonoBehaviour {

	public float RotationSpeed;

	void Update () {
		if (RotationSpeed != 0) {
				transform.Rotate(Vector3.up, RotationSpeed * Time.deltaTime);
		}
	}
}

