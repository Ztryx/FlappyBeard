using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

	public static int score = 0;
	static int highScore = 0;

	public Text scoreText;

	public static Score instance;

	static public void AddPoint() {
		if(instance.bird.dead)
			return;

		score++;

		if(score > highScore) {
			highScore = score;
		}
	}

	Bird_Movement bird;

	void Start() {
		instance = this;
		GameObject player_go = GameObject.FindGameObjectWithTag("Player");
		if(player_go == null) {
			Debug.LogError("Could not find an object with tag 'Player'.");
		}

		bird = player_go.GetComponent<Bird_Movement>();
		score = 0;
		highScore = PlayerPrefs.GetInt("highScore", 0);
	}

	void OnDestroy() {
		PlayerPrefs.SetInt("highScore", highScore);
		DontDestroyOnLoad (instance);
	}

	void Update () {
		if(score!=0)
			scoreText.text = (score-1).ToString();
		else
			scoreText.text = score.ToString();
	}
}
