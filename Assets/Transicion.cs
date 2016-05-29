using UnityEngine;
using System.Collections;

public class Transicion : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CambioEscena(){
		Application.LoadLevel ("Menu");
	}

}
