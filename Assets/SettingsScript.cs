using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;


public class SettingsScript : MonoBehaviour {

    public Button GodMode;
    public Color disabled;

    // Use this for initialization
    void Start () {
        disabled = new Color(1f, 1f, 1f);
        disabled.a = 0.4f;
        if (PlayerPrefs.GetInt("GodMode") == 1)
            GodMode.GetComponent<Image>().color = Color.white;
        else
            GodMode.GetComponent<Image>().color = disabled;
    }

    public void SettingsButtonBehaviour()
    {
        if (PlayerPrefs.GetInt("GodMode")==1)
        {
            PlayerPrefs.SetInt("GodMode", 0);
            GodMode.GetComponent<Image>().color = disabled;
            Debug.Log("Deberia apagarme");
        }
        else
        {
            PlayerPrefs.SetInt("GodMode", 1);
            GodMode.GetComponent<Image>().color = Color.white;
            Debug.Log("Deberia encenderme");
        }
    }

    public void VolverMenu()
    {
        SceneManager.LoadScene("Portada");
    }

    // Update is called once per frame
    void Update () {
	
	}
}
