using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour {

	public int lives = 3;
	public int bricks = 28;
	public float resetDelay = 1f;
	public Text livesText;
	public GameObject gameOver;
	public GameObject youWon;
	public GameObject bricksPrefab;
	public GameObject snowPrefab;
	public GameObject paddle;
	public GameObject ball;
	public GameObject deathParticles;
	public static GM instance = null;
	public GameObject stonesPrefab;

	private GameObject clonePaddle;
//	private GameObject cloneBall;


	// Use this for initialization
	void Awake () 
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		Setup();

	}

	public void Setup()
	{
		clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
//		Instantiate(paddle, transform.position, Quaternion.identity);
		Instantiate(bricksPrefab, transform.position, Quaternion.identity);
		Instantiate(snowPrefab, transform.position, Quaternion.identity);
//		cloneBall = Instantiate(ball, ball.transform.position, Quaternion.identity) as GameObject;
		Instantiate(ball, ball.transform.position, Quaternion.identity);
	}

	void CheckGameOver()
	{
		if (bricks < 1)
		{
			youWon.SetActive(true);
			Time.timeScale = .25f;
			Invoke ("Reset", resetDelay);
		}

		if (lives < 1)
		{
			gameOver.SetActive(true);
			Time.timeScale = .25f;
			Invoke ("Reset", resetDelay);
		}

	}

	void Reset()
	{
		Time.timeScale = 1f;
		Application.LoadLevel(Application.loadedLevel);
	}

	public void LoseLife()
	{
		lives--;
		livesText.text = "Lives: " + lives;
		Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
		Destroy(clonePaddle);
		Invoke ("SetupPaddle", resetDelay);
		CheckGameOver();
	}

	void SetupPaddle()
	{
		clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
//		cloneBall = Instantiate(ball, ball.transform.position, Quaternion.identity) as GameObject;
//		Instantiate(paddle, transform.position, Quaternion.identity); 
		Instantiate (ball, ball.transform.position, Quaternion.identity);
	}

	public void DestroyBrick()
	{
		bricks--;
		CheckGameOver();
	}

	public void HitGrass()
	{
		bricks = 0;
		CheckGameOver();
	}


		
}
