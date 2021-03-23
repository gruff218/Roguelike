using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolloiw : MonoBehaviour
{
	public Transform target;
	public Vector3 offset;
	[Range(0,10)]
	public float smoothFactor;
	public int cameraSize = 6;

	void Start() {
		GetComponent<Camera>().orthographicSize = cameraSize;
	}

	void FixedUpdate() {
		Follow();
	}

	void Follow() {
		Vector3 targetPosition = target.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor*Time.fixedDeltaTime);
		transform.position = smoothedPosition;
	}	
}
