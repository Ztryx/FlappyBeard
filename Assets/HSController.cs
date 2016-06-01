using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text;
using System.Security.Cryptography;
using System;

public class HSController : MonoBehaviour
{
	private string secretKey = "FlappyOxik"; // Edit this value and make sure it's the same as the one stored on the server
	public string addScoreURL = "http://www.oxik.net/conectaconlafelicidad/access/addPuntuacionFlappy.php?"; //be sure to add a ? to your url
	public string highscoreURL = "http://www.oxik.net/conectaconlafelicidad/access/displayPuntuacionFlappy.php";
	public Text tableScores;
	public InputField nombre;
	public Animator gracias;
	public Button enviar;

	void Start()
	{
		StartCoroutine(GetScores());
	}
	
	// remember to use StartCoroutine when calling this function!
	IEnumerator PostScores(string name, string correo, int score)
	{
		Debug.Log ("Score : " + score);
		string testString = name + score + secretKey;
			byte[] asciiBytes = ASCIIEncoding.ASCII.GetBytes(testString);
			byte[] hashedBytes = MD5CryptoServiceProvider.Create().ComputeHash(asciiBytes);
			string hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
		Debug.Log ("HASH: " + hash);
		//This connects to a server side php script that will add the name and score to a MySQL DB.
		// Supply it with a string representing the players name and the players score.

		string post_url = addScoreURL + "name=" + WWW.EscapeURL(name) + "&correo=" + WWW.EscapeURL(correo) + "&score=" + score + "&hash=" + hash;
		
		// Post the URL to the site and create a download object to get the result.
		WWW hs_post = new WWW(post_url);
		yield return hs_post; // Wait until the download is done
		
		if (hs_post.error != null)
		{
			print("There was an error posting the high score: " + hs_post.error);
		}
	}
	
	// Get the scores from the MySQL DB to display in a GUIText.
	// remember to use StartCoroutine when calling this function!
	IEnumerator GetScores()
	{
		//gameObject.guiText.text = "Loading Scores";
		WWW hs_get = new WWW(highscoreURL);
		yield return hs_get;
		
		if (hs_get.error != null)
		{
			print("There was an error getting the high score: " + hs_get.error);
		}
		else
		{
			Debug.Log (hs_get.text);
			tableScores.text = hs_get.text;
			//gameObject.guiText.text = hs_get.text; // this is a GUIText that will display the scores in game.
		}
	}

	public void EnviarDatos(){
		Debug.Log(nombre.text);
		StartCoroutine (PostScores (nombre.text, "info@info.net", Score.score-1));
		gracias.Play ("GraciasParticipar");
		enviar.interactable = false;
	}
}