using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : NetworkBehaviour {

	[SerializeField]
	private float speed = 5f;
	[SerializeField]
	private float lookSensitivity = 3f;
	[SerializeField]
	private float jumpForce = 1000f;
	[SerializeField]
	private bool jumpControl = false;
	[SerializeField]
	private float heightCont = 1f;
	[SerializeField]
	private bool mouseLock;

	private PlayerMotor motor;

	void Start (){

		motor = GetComponent<PlayerMotor> ();
		mouseLock = true;
	}

	void Update(){
		if (!isLocalPlayer)
			return;
		if (Input.GetKeyDown ("escape") && !mouseLock) {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			mouseLock = true;
		} else if (Input.GetKeyDown ("escape") && mouseLock) {
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			mouseLock = false;
		}

		//Calculate movement velocity as a 3d vector
		float _xMov = Input.GetAxisRaw ("Horizontal");
		float _zMov = Input.GetAxisRaw("Vertical");

		Vector3 _moveHorizontal = transform.right * _xMov;
		Vector3 _moveVertical = transform.forward * _zMov;

		GroundCheck ();

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
		
		float _cameraRotationX = _xRot*lookSensitivity;
		
		//Apply camera rotation
		motor.RotateCamera (_cameraRotationX);


		Vector3 _jumpForce = Vector3.zero;
		if (Input.GetButton ("Jump") && jumpControl) {
			_jumpForce = Vector3.up * jumpForce;
			jumpControl = ! jumpControl;
		}
		//Apply jump force
		motor.Jump (_jumpForce);

	}
	void GroundCheck()
	{
		RaycastHit hit;
		Ray isGround = new Ray (transform.position, Vector3.down);
		if (Physics.Raycast (isGround, out hit, heightCont)) {
			jumpControl = true;
		}
	}
}
