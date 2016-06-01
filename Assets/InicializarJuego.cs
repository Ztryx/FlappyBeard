using UnityEngine;
using System.Collections;

public class InicializarJuego : MonoBehaviour {



	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Comenzar() {
		Application.LoadLevel ("MainScene");
	}

    public void VolverMenu()
    {
        Application.LoadLevel("Portada");
    }
}
