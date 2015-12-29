using UnityEngine;
using UnityEngine.Networking;

public class Button : NetworkBehaviour {

	private Vector3 _from;
	private Vector3 _to;
	private Vector3 _result;
	private Vector3 velocity = Vector3.zero;
	private bool _move = false;
	private bool i = true;

	[SerializeField]
	private float speed = 10;
	[SerializeField]
	GameObject otherDoor;
	private Transform boss;
	[SyncVar]
	private int _cNum;

	// Use this for initialization
	void Start () {
			
		if (transform.parent.tag == "Pink Door")
			_cNum = 2;
		if (transform.parent.tag == "Yellow Door")
			_cNum = 1;
		boss = otherDoor.transform.parent.transform;


	}
	
	// Update is called once per frame
	void Update () {

		if (i) {

			Debug.Log (boss.position);
			i= false;
		
		}
		ColortoNumber ();
		if(_move)


			//_result = Vector3.MoveTowards(_from,_to, speed *Time.deltaTime);
			otherDoor.transform.parent.position =  Vector3.Lerp(boss.position,new Vector3(boss.position.x,-20,boss.position.z),Time.deltaTime * speed);
		//otherDoor.transform.parent.transform.position= Vector3.SmoothDamp (otherDoor.transform.parent.position,_to,ref velocity,1f);
		//ButtonPushed ();
	
	}

	public void ButtonPushed(){
		if (_cNum == 1) {
			_cNum =4;
			if(otherDoor.transform.GetChild(0).GetComponent<MeshRenderer>().material.color == Color.blue)
			{	
				_cNum = 3;
				otherDoor.transform.GetChild(0).GetComponent<Button>()._cNum = 3;
				_move = true;
				otherDoor.transform.GetChild(0).GetComponent<Button>()._move = true;
		//		otherDoor.transform.parent.position = _result;
		//		_ofrom = otherDoor.transform.position;
		//		_oto = new Vector3 (0f, 10f, 0f) + _ofrom;
		//		otherDoor.transform.position = Vector3.MoveTowards(_ofrom,_oto,speed *Time.deltaTime);
			}

		} else if (_cNum == 2) {
			_cNum = 4;
			if(otherDoor.transform.GetChild(0).GetComponent<MeshRenderer>().material.color == Color.blue)
			{
				_cNum = 3;
				otherDoor.transform.GetChild(0).GetComponent<Button>()._cNum = 3;
				_move = true;
				otherDoor.transform.GetChild(0).GetComponent<Button>()._move = true;
		//		otherDoor.transform.parent.position = _result;
		//		_ofrom = otherDoor.transform.position;
		//		_oto = new Vector3 (0f, 10f, 0f) + _ofrom;
		//		otherDoor.transform.position = Vector3.MoveTowards(_ofrom,_oto,speed *Time.deltaTime);

			}
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
