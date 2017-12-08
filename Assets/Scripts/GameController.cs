using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour 
{
	public GameObject[] hazards;
	public GameObject boss;
	public Vector3 spawnValues;
	public Vector3 spawnValuesBoss;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public Text scoreText;
	public Text restartText;
	public Text gameOverText;
	public Text HighScore;

	private bool gameOver;
	private bool restart;
	private bool reset;
	private int score;
	private float totalWaves;

	void Start ()
	{
		gameOver = false;
		restart = false;
		reset = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		totalWaves = 0;
		HighScore.text = "High Score: " + PlayerPrefs.GetInt ("HighScore", 0).ToString ();
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}

	void Update ()
	{
		if (gameOver) 
		{
			restartText.text = "Press 'R' for Restart \n\nPress 'X' to Reset High Score" ;
			restart = true;
			reset = true;
		}
		if (reset) 
		{
			if (Input.GetKeyDown (KeyCode.X)) 
			{
				Reset ();
			}
		}
		if (restart) 
		{
			if (Input.GetKeyDown (KeyCode.R)) 
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			if (totalWaves == 7) 
			{
				Vector3 spawnPositionBoss = new Vector3 (Random.Range (-spawnValuesBoss.x, spawnValuesBoss.x), spawnValuesBoss.y, spawnValuesBoss.z);
				Quaternion spawnRotationBoss = Quaternion.identity;
				Instantiate (boss, spawnPositionBoss, spawnRotationBoss);
			}

			if (totalWaves == 14) 
			{
				Vector3 spawnPositionBoss = new Vector3 (Random.Range (-spawnValuesBoss.x, spawnValuesBoss.x), spawnValuesBoss.y, spawnValuesBoss.z);
				Quaternion spawnRotationBoss = Quaternion.identity;
				Instantiate (boss, spawnPositionBoss, spawnRotationBoss);
			}

			if (totalWaves == 21) 
			{
				Vector3 spawnPositionBoss = new Vector3 (Random.Range (-spawnValuesBoss.x, spawnValuesBoss.x), spawnValuesBoss.y, spawnValuesBoss.z);
				Quaternion spawnRotationBoss = Quaternion.identity;
				Instantiate (boss, spawnPositionBoss, spawnRotationBoss);
			}

			if (totalWaves == 21) 
			{
				Vector3 spawnPositionBoss = new Vector3 (Random.Range (-spawnValuesBoss.x, spawnValuesBoss.x), spawnValuesBoss.y, spawnValuesBoss.z);
				Quaternion spawnRotationBoss = Quaternion.identity;
				Instantiate (boss, spawnPositionBoss, spawnRotationBoss);
			}

			for (int i = 0; i < hazardCount; i++) 
			{
				GameObject hazard = hazards[Random.Range (0,hazards.Length)];
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);

			if (gameOver) 
			{
				break;
			}
			hazardCount++;
			if (waveWait >= 0.2f)
			{
				waveWait = waveWait - 0.2f;
			}
			totalWaves++;
		}
	}

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();

		if (score > PlayerPrefs.GetInt ("HighScore", 0)) 
		{
			PlayerPrefs.SetInt ("HighScore", score);
			HighScore.text = "High Score: " + score.ToString ();
		}
	}

	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}

	public void GameOver ()
	{
		gameOverText.text = "Game Over";
		gameOver = true;
	}

	public void Reset ()
	{
		PlayerPrefs.DeleteKey ("HighScore");
		HighScore.text = "High Score: 0";
	}
}
