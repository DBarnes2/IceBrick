using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceBricks : MonoBehaviour {

	//public GameObject brickParticle;
	public int hitsneed = 2;
	int hits;

	void OnCollisionEnter2D (Collision2D other)
	{
		//Instantiate(brickParticle, transform.position, Quaternion.identity);
		GM.instance.DestroyBrick();
		if (++hits >= hitsneed) {
			Destroy (gameObject);
		}
	}
}
