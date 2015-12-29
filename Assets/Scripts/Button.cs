using UnityEngine;
using UnityEngine.Networking;

public class Button : NetworkBehaviour {

	private Vector3 from = this.parent.transform.position;
	[SerializeField]
	GameObject otherDoor;
	[SyncVar]
	private int _cNum;

	// Use this for initialization
	void Start () {
			
		if (transform.parent.tag == "Pink Door")
			_cNum = 2;
		if (transform.parent.tag == "Yellow Door")
			_cNum = 1;


	}
	
	// Update is called once per frame
	void Update () {


		ColortoNumber ();
		//ButtonPushed ();
	
	}

	public void ButtonPushed(){
		if (_cNum == 1) {
			_cNum =4;
			if(otherDoor.transform.GetChild(0).GetComponent<MeshRenderer>().material.color == Color.blue)
			{}

		} else if (_cNum == 2) {
			_cNum = 4;
			if(otherDoor.transform.GetChild(0).GetComponent<MeshRenderer>().material.color == Color.blue)
			{}
		}

	}

	private void ColortoNumber(){
		if (_cNum == 1)
			GetComponent<MeshRenderer>().material.color = Color.red;
		else if (_cNum == 2)
			GetComponent<MeshRenderer>().material.color = Color.yellow;
		else if (_cNum == 3)
			GetComponent<MeshRenderer>().material.color = Color.green;
		else if(_cNum == 4)
			GetComponent<MeshRenderer>().material.color = Color.blue;
	}

}
