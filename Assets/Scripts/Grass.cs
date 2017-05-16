using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour {


	void OnCollisionEnter2D (Collision2D other)
	{
		GM.instance.WinGame();
	}
}
