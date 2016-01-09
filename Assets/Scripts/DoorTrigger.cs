using UnityEngine;
using UnityEngine.Networking;

public class DoorTrigger : NetworkBehaviour {

	[SyncVar]
	public int _doorOpen = 0;

	[SerializeField]
	private float smooth;
	[SerializeField]
	private Transform door1;
	// Use this for initialization
	void Start() {

	}
	
	// Update is called once per frame
	void Update () {

		if(_doorOpen == 1 && door1 != null)
			door1.position =  Vector3.Lerp(door1.position,new Vector3(door1.position.x,-10,door1.position.z),Time.deltaTime * smooth);
		if(_doorOpen == 2 && door1 != null)
			door1.position =  Vector3.Lerp(door1.position,new Vector3(door1.position.x,13,door1.position.z) ,Time.deltaTime * smooth);
	}

	void OnTriggerStay(Collider other)
	{		
		if (other.gameObject.tag == "Cube" || other.gameObject.tag == "Player") 
			if(_doorOpen != 1)
			_doorOpen = 1;
		
	}
	void OnTriggerExit(Collider other)
	{		
		if (other.gameObject.tag == "Cube" || other.gameObject.tag == "Player") {
			if(_doorOpen == 1)
			{_doorOpen = 2;
				Debug.Log ("exit exit "+ other.gameObject.tag );
			}
		}
	}
}
