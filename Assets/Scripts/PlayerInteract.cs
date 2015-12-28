using UnityEngine;
using UnityEngine.Networking;

public class PlayerInteract : NetworkBehaviour {

	private const string PLAYER_TAG = "Player" ;
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
			if(_hit.collider.tag == PLAYER_TAG){
				CmdPlayerHit(_hit.collider.name);
			}
		}

	}

	[Command]
	void CmdPlayerHit(string _ID)
	{
		Debug.Log (_ID + "has been hit.");

	}
}
