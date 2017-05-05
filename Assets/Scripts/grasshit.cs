using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grasshit : MonoBehaviour {


	void OnCollisionEnter2D (Collision2D other)
	{
		//Instantiate(brickParticle, transform.position, Quaternion.identity);
		GM.instance.HitGrass();

	}
}
