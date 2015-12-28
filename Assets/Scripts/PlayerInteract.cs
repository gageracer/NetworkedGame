using UnityEngine;
using UnityEngine.Networking;

public class PlayerInteract : NetworkBehaviour {

	private const string PLAYER_TAG = "Player";
	private const string BUTTON_TAG = "Button";
	[SerializeField]
	private Camera cam;
	[SerializeField]
	private float range = 1f;
	[SerializeField]
	private LayerMask mask;

	// Use this for initialization
	void Start () {

		if (cam == null)
			this.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("Fire1"))
			Shoot ();
	}
	[Client]
	void Shoot(){

		RaycastHit _hit;
		if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, range, mask)) {
			CmdPlayerHit(_hit.collider.name);
			if(_hit.collider.tag == PLAYER_TAG){

			}
			if(_hit.collider.tag == BUTTON_TAG){
				CmdButtonPushed(_hit.collider.gameObject);
			}
		}

	}

	[Command]
	void CmdPlayerHit(string _ID)
	{
		Debug.Log (_ID + " has been hit.");

	}
	[Command]
	void CmdButtonPushed(GameObject _button){

		_button.GetComponent<Button> ().ButtonPushed();
	}
}
