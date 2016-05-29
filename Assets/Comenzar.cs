using UnityEngine;
using System.Collections;

public class Comenzar : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PulsarComenzar () {
		Application.LoadLevel ("MainScene");
	}

}
