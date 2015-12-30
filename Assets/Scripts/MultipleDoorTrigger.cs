using UnityEngine;
using UnityEngine.Networking;

public class MultipleDoorTrigger : NetworkBehaviour {



	//private int _doorOpen = 0;
	[SerializeField]
	private GameObject _plat1;
	[SerializeField]
	private GameObject _plat2;
	[SerializeField]
	private GameObject _plat3;
	[SerializeField]
	private float smooth;
	[SerializeField]
	private Transform door3;
	[SerializeField]
	private Transform door2;

	[SyncVar]
	private bool _megaDoor;

	// Use this for initialization
	void Start () {
		_megaDoor = false;
	}
	
	// Update is called once per frame
	void Update () {


		if (_plat1.GetComponent<DoorTrigger> ()._doorOpen == 1 && _plat2.GetComponent<DoorTrigger> ()._doorOpen == 1 && _plat3.GetComponent<DoorTrigger> ()._doorOpen == 1) {

			door3.position =  Vector3.Lerp(door3.position,new Vector3(door3.position.x,-10,door3.position.z),Time.deltaTime * smooth);
			_megaDoor = true;
		}
		else if (_plat1.GetComponent<DoorTrigger> ()._doorOpen == 2 || _plat2.GetComponent<DoorTrigger> ()._doorOpen == 2 || _plat3.GetComponent<DoorTrigger> ()._doorOpen == 2) {

			door3.position =  Vector3.Lerp(door3.position,new Vector3(door3.position.x,13,door3.position.z),Time.deltaTime * smooth);
			_megaDoor = false;
		}
	}



}
