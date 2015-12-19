using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

	[SerializeField]
	private float speed = 5f;
	[SerializeField]
	private float lookSensitivity = 3f;
	private PlayerMotor motor;

	void Start (){

		motor = GetComponent<PlayerMotor> ();

	}

	void Update(){
	
		//Calculate movement velocity as a 3d vector
		float _xMov = Input.GetAxisRaw ("Horizontal");
		float _zMov = Input.GetAxisRaw("Vertical");

		Vector3 _moveHorizontal = transform.right * _xMov;
		Vector3 _moveVertical = transform.forward * _zMov;


		//Final Movement vector
		Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * speed;


		//Apply movement
		motor.Move (_velocity);

		//Calculate Rotation as a 3D vector (turning around)
		float _yRot = Input.GetAxisRaw("Mouse X");

		Vector3 _rotation = new Vector3 (0f, _yRot, 0)*lookSensitivity;

		//Apply rotation
		motor.Rotate (_rotation);

		//Calculate Camera Rotation as a 3D vector (turning around)
		float _xRot = Input.GetAxisRaw("Mouse Y");
		
		Vector3 _cameraRotation = new Vector3 (_xRot, 0, 0)*lookSensitivity;
		
		//Apply camera rotation
		motor.RotateCamera (_cameraRotation);


	
	}
}
