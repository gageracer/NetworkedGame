using UnityEngine;
using System.Collections;
 
[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {

	[SerializeField]
	private Camera cam;

	private Vector3 velocity = Vector3.zero;
	private Vector3 rotation = Vector3.zero;
	private float cameraRotationX = 0f;
	private float currentCameraRotationX = 0f;
	private Vector3 jumpForce = Vector3.zero;


	[SerializeField]
	private float cameraRotationLimit = 85f;

	private Rigidbody rb;

	void Start(){

		rb = GetComponent<Rigidbody> ();

	}

	//gets movement vector
	public void Move(Vector3 _velocity){

		velocity = _velocity;
	}
	public void Rotate(Vector3 _rotation){
		
		rotation = _rotation;
	}

	public void RotateCamera(float _cameraRotationX){
		
		cameraRotationX = _cameraRotationX;
	}
	//Get the force for jumping
	public void Jump(Vector3 _jumpforce)
	{
		jumpForce = _jumpforce;
	}
	//Run every physics iteration
	void FixedUpdate(){

		PerformMovement ();
		PerformRotation ();
	}

	//Perform rotation
	void PerformRotation(){

		rb.MoveRotation (rb.rotation * Quaternion.Euler(rotation));
		if (cam != null) {
			//Set our rotation and clamp it
			currentCameraRotationX -= cameraRotationX;
			currentCameraRotationX = Mathf.Clamp(currentCameraRotationX,-cameraRotationLimit,cameraRotationLimit);
			//Applied our rotation to the transform of our camera
			cam.transform.localEulerAngles = new Vector3 (currentCameraRotationX,0f,0f);
		}
	}
	//Perform movement based on velocity movement
	void PerformMovement(){

		if (velocity != Vector3.zero) 
			rb.MovePosition(rb.position + velocity *Time.fixedDeltaTime);
		
		if (jumpForce != Vector3.zero)
			rb.AddForce (jumpForce * Time.fixedDeltaTime, ForceMode.Impulse);
		}
}
