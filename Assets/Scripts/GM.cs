using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour {

	public int lives = 3;
	public int bricks = 28;
	public float resetDelay = 1f;
	public float timeRemaining = 30f;
	public Text timerText;
	public Text livesText;
	public GameObject gameOver;
	public GameObject youWon;
	public GameObject bricksPrefab;
	public GameObject paddle;
	public GameObject deathParticles;
	public static GM instance = null;
	public GameObject stonesPrefab;

	private Ball ball;
	private GameObject clonePaddle;

	// Use this for initialization
	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		Setup();
	}

	// Update increments the countdown timer and updates the GUI with the new time
	// It is also responsible for ending the game if the timer runs out.
	void Update()
	{
		if (ball.IsInPlay())
			timeRemaining -= Time.deltaTime;
		if (timeRemaining <= 0)
			LoseGame();

		int minutes = (int)timeRemaining / 60;
		int seconds = (int)timeRemaining % 60;

		timerText.text = "Time: " + minutes + ":";
		if (seconds < 10)
			timerText.text += "0" + seconds;
		else
			timerText.text = timerText.text + seconds;
	}

	public void Setup()
	{
		SetupPaddle();
		Instantiate(bricksPrefab, transform.position, Quaternion.identity);
	}

	void CheckGameOver()
	{
		if (bricks < 1) // TODO: bricks is not always an accurate count of existing bricks!
			WinGame();
		if (lives < 1)
			LoseGame();
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
		ball = clonePaddle.GetComponentInChildren<Ball>() as Ball;
	}

	public void DestroyBrick()
	{
		bricks--;
		CheckGameOver();
	}

	public void WinGame()
	{
		youWon.SetActive(true);
		Time.timeScale = .25f;
		Invoke ("Reset", resetDelay);
	}

	public void LoseGame()
	{
		gameOver.SetActive(true);
		Time.timeScale = .25f;
		Invoke ("Reset", resetDelay);
	}
}
