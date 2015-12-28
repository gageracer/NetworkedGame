using UnityEngine;
using UnityEngine.Networking;

public class Button : NetworkBehaviour {


	[SyncVar]
	private int _cNum = 1;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {

		ColortoNumber ();
		//ButtonPushed ();
	
	}

	public void ButtonPushed(){
		if(GetComponent<MeshRenderer>().material.color == Color.red)
		_cNum = 2;

	}
	private void ColortoNumber(){
		if (_cNum == 1)
			GetComponent<MeshRenderer>().material.color = Color.red;
		else if (_cNum == 2)
			GetComponent<MeshRenderer>().material.color = Color.yellow;
		else if (_cNum == 3)
			GetComponent<MeshRenderer>().material.color = Color.green;
	}

}
