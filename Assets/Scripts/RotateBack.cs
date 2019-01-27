using UnityEngine;
using System.Collections;

public class RotateBack : MonoBehaviour {

	public float RotationSpeed;

	void Update () {
		if (RotationSpeed != 0) {
				transform.Rotate(Vector3.back, RotationSpeed * Time.deltaTime);
		}
	}
}

