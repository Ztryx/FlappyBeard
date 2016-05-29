using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Inicialización : MonoBehaviour {

	public Text titulo;

	// Use this for initialization
	void Start () {
		titulo.text = "TU PUNTUACION ES: " + Score.score;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
