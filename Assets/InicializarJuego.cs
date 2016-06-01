using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class InicializarJuego : MonoBehaviour {



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
}
