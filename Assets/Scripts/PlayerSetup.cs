using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour {

	[SerializeField]
	Behaviour[] componentsToDisable;
	[SerializeField]
	string remoteLayerName = "RemotePlayer";
	Camera sceneCamera;

	// Use this for initialization
	void Start () {
	
		if (!isLocalPlayer) {
			DisableComponents();
			AssignRemoteLayer();
		} else {
			//We are the local player:Disable the scene camere
			sceneCamera = Camera.main;
			if(sceneCamera != null)
			Camera.main.gameObject.SetActive(false);
		}
		RegisterPlayer ();

	}
	void RegisterPlayer(){
		string _ID = "Player " + GetComponent<NetworkIdentity> ().netId;
		transform.name = _ID;
	}
	void DisableComponents(){
		for (int i = 0; i <componentsToDisable.Length; i++) {
			componentsToDisable [i].enabled = false;
		}
	}

	void AssignRemoteLayer(){
		gameObject.layer = LayerMask.NameToLayer (remoteLayerName);
	}

	void OnDisable(){
	
		if (sceneCamera != null)
			sceneCamera.gameObject.SetActive (true);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
