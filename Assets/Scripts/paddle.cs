using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle : MonoBehaviour {

	public float paddleSpeed = 5f;
	public float xPos = 0f;

	private Vector3 playerPos = new Vector3 (0, 15f, 0);

	void Update ()
	{
		xPos = transform.position.x + (Input.GetAxis ("Horizontal") * paddleSpeed);
		playerPos = new Vector3 (Mathf.Clamp (xPos, -10f, 10f), 15f, 0f);
		transform.position = playerPos;


		if (Input.GetMouseButton (0)) {
			if (Input.mousePosition.x < Screen.width / 2f) {
				xPos = transform.position.x - (paddleSpeed)*5f*Time.deltaTime ;
				playerPos = new Vector3 (Mathf.Clamp (xPos, -10f, 10f), 15f, 0f);
				transform.position = playerPos;
			} else
				xPos = transform.position.x + (paddleSpeed) * 5f*Time.deltaTime;
			playerPos = new Vector3 (Mathf.Clamp (xPos, -10f, 10f), 15f, 0f);
			transform.position = playerPos;
		}
	}


}
