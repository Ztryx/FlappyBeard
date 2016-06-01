using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InicializarJuego : MonoBehaviour {

    public Button settingsButton;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Comenzar() {
		Application.LoadLevel ("MainScene");
	}

    public void SettingsButtonBehaviour()
    {
        Application.LoadLevel("Ajustes");
    }
}
