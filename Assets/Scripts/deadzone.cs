using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadzone : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other)
	{
		GM.instance.LoseLife();
	}
}
