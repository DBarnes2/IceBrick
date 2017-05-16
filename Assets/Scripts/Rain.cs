// Daniel Barnes
// 5/7/17
// Creates a rain animation for "iceBrick" game

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour {

    // Rain object used in animation
	public GameObject drop;

    // for the "Weather" method, to control rain spawning and shifting
	private int count;

    // When game starts
	void Awake () {
		count = 0;
        // Calls "Weather" method after 1 second, every 0.15 seconds
        InvokeRepeating("Weather", 1, 0.15f);
    }

    // Spawns rows of raindrops, and shifts them downwards. Rows have an alternating offset
    // Rows alternate between shifting to the left and to the right based upon time
    // All rain drops move the same
    void Weather () {
        // creates a row of raindrops off of the screen. Alternates between creating the rows with and without an offset
        if (count % 8 == 0) {
            for (int i = 0; i < 9; i++) {
                Instantiate(drop, new Vector3(i * 3 - 13f, 20f), Quaternion.identity);
            }
        } else if (count % 8 == 4) {
            for (int i = 0; i < 9; i++) {
                Instantiate(drop, new Vector3(i * 3 - 11.5f, 20f), Quaternion.identity);
            }
        }
        // Moves the drops downwards, and alternates between moving left and right
        foreach (GameObject drop in GameObject.FindGameObjectsWithTag("rain")) {
            // if the drop moves past the grass, destroys it (to prevent having too many objects)
            if (drop.transform.position.y < -17) {
                Destroy(drop);
            }
            if (count % 4 < 2) {
                drop.transform.position = new Vector3(drop.transform.position.x + 0.3f, drop.transform.position.y - 0.5f);
            } else {
                drop.transform.position = new Vector3(drop.transform.position.x - 0.3f, drop.transform.position.y - 0.5f);
            }
            
        }
        count++;
    }
}
