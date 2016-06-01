using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Inicialización : MonoBehaviour {

    public GameObject GodModeButton;

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.GetInt("GodMode") == 1)
            GodModeButton.active = true;
        else
            GodModeButton.active = false;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Menu ()
    {
        Application.LoadLevel("Portada");
    }
}
