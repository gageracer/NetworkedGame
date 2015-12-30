using UnityEngine;
using UnityEngine.Networking;

public class CarryCube : NetworkBehaviour {

	[SyncVar]
	private bool carried = false;

	private GameObject _player;
	[SerializeField]
	private float distance = 1f;
	[SerializeField]
	private float smooth;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

		if (carried) {
			GetComponent<Rigidbody> ().isKinematic = true;
			//GetComponent<Rigidbody> ().useGravity = false;
			transform.position = Vector3.Lerp (transform.position, _player.transform.GetComponentInChildren<Camera> ().transform.position + _player.transform.GetComponentInChildren<Camera> ().transform.forward * distance, Time.deltaTime * smooth);

		} 
	}

	public void Carry(GameObject player){

		_player = player;

		if (carried == false) {
			Debug.Log ("carried true");
			carried = true;
		} else {
			GetComponent<Rigidbody> ().isKinematic = false;
			carried = false;
			Debug.Log ("carried false");
		}
	}
}
