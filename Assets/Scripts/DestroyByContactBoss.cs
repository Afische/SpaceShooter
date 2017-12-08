using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContactBoss : MonoBehaviour 
{
	public GameObject explosion;
	public GameObject playerExplosion;

	public int BossHealth;
	private int scoreValue2 = 500;
	private GameController gameController;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) 
		{
			gameController = gameControllerObject.GetComponent <GameController> ();
		}
		if (gameController == null) 
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Bolt"))
		{
			if (BossHealth > 0) 
			{
				Instantiate (explosion, transform.position, transform.rotation);
				Destroy(other.gameObject);
				BossHealth -= 1;
				return;
			}

			if (BossHealth <= 0) 
			{
				Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
				Destroy(other.gameObject);
				Destroy(gameObject);
				gameController.AddScore (scoreValue2);
				return;
			}
		}
	}

}