using UnityEngine;
using System.Collections;

public class MouseOrbit : MonoBehaviour {

	public Transform target;
	public float distance = 10.0f;
	
	public float xSpeed = 250.0f;
	public float ySpeed = 120.0f;
	
	public int yMinLimit = -20;
	public int yMaxLimit = 80;
	
	float x = 0.0f;
	float y = 0.0f;

	// Use this for initialization
	void Start () {
	
		var angles = transform.eulerAngles;
		x = angles.y;
		y = angles.x;
		
		// Make the rigid body not change rotation
		if (GetComponent<Rigidbody>())
			GetComponent<Rigidbody>().freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void LateUpdate () {

		if (target) {
			x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
			y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
			
			y = ClampAngle(y, yMinLimit, yMaxLimit);
			
			var rotation = Quaternion.Euler(y, x, 0);
			var position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position;
			
			transform.rotation = rotation;
			transform.position = position;
		}
	}
	
	static public float ClampAngle (float angle, float min, float max) {

		if (angle < -360)
			angle += 360;
		if (angle > 360)
			angle -= 360;
		return Mathf.Clamp (angle, min, max);
	}
}
