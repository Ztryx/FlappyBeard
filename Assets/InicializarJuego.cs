using UnityEngine;
using UnityEngine.SceneManagement;
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
        SceneManager.LoadScene("MainScene");
	}

    public void VolverMenu() {
        SceneManager.LoadScene("Portada");
    }

    public void SettingsButtonBehaviour() {
        SceneManager.LoadScene("Ajustes");
    }
}
