using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rain : MonoBehaviour {

	public GameObject drop;

	public static int count;

	// Use this for initialization
	void Start () {
		count = 0;
		Instantiate(drop, new Vector2 (3, 3), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		//if (count % 10 == 0) {
		//	for (int i = 0; i < 10; i++) {
				Instantiate(drop, new Vector2 (3, 3), Quaternion.identity);
		//	}
		//}
		count++;
	}
}
