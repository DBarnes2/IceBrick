using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour {

	//public GameObject brickParticle;
	int hits;
	public int hitsNeeded = 2;

	void OnCollisionEnter2D (Collision2D other)
	{
		GM.instance.DestroyBrick();
		if (++hits >= hitsNeeded) {
			Destroy (gameObject);
		}
	}
}
