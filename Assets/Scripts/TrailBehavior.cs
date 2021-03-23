using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailBehavior : MonoBehaviour {
	
	private float clock = 0.02f;
	private int trailLength = 0;
	public int maxLength = 100;
	// Array of cubes that make up the array
	private GameObject[] trail;
	// private GameObject trail;
	
	// A reference to the Bass Line
	public GameObject bassLine;
	
	// Prefab of the cubes that make up the trail
	public GameObject trailPrefab;
	
	// A reference to the parent GameObject made just to keep the trail organized
	public GameObject keeper;
	
	// A reference to the bass line's script
	private BassLine bassLineScript;
	
	// Use this for initialization
	void Start () {
		trail = new GameObject[maxLength];
		
		bassLineScript = bassLine.GetComponent<BassLine>();
	}
	
	// Movement of the trail 
	void Update () {
		
		// If the number of cubes in the trail exceeds the specified maximum length, 
		// return the trailLength variable back to 0 in order to cycle through the array
		if (trailLength >= maxLength) {
			trailLength = 0;
		}
		
		// Are we alive?
		// If not, stop creating the trail, play the death rattle
		if (bassLineScript.getStatus() == false) {
			bassLine.GetComponent<AudioSource>().Play();
			Explode();
			enabled = false;
		}
		
		// Did we win?
		// If not, stop creating the trail
		if (bassLineScript.levelComplete() == true) {
			enabled = false;
		}
		
		// For delaying the creation of cubes in the trail so that hundreds are not made every second
		clock = clock - Time.deltaTime;
		if (clock <= 0f) {
			if (trail[trailLength] == null) {
				trail[trailLength] = (GameObject) Instantiate(trailPrefab, bassLine.transform.position, bassLine.transform.rotation);
				trail[trailLength].name = "Trail" + trailLength;
				trail[trailLength].transform.SetParent(keeper.transform);
				trail[trailLength].GetComponent<Rigidbody>().detectCollisions = false;
			} else if (trail[trailLength] != null) {
				Destroy(trail[trailLength]);
				trail[trailLength] = (GameObject) Instantiate(trailPrefab, bassLine.transform.position, bassLine.transform.rotation);
				trail[trailLength].name = "Trail" + trailLength;
				trail[trailLength].transform.SetParent(keeper.transform);
				trail[trailLength].GetComponent<Rigidbody>().detectCollisions = false;
			}
			
			// Kills the game object in 2 seconds after loading the object
			// Destroy(trail, 0.5f);
			clock = .02f;
			trailLength++;
		}
		
	}
	
	// A grisly death indeed
	void Explode() {
		GameObject fragment1 = (GameObject) Instantiate(trailPrefab, trail[trailLength - 1].transform.position, bassLine.transform.rotation);
		fragment1.name = "Fragment";
		fragment1.GetComponent<Rigidbody>().isKinematic = false;
		fragment1.GetComponent<Rigidbody>().useGravity = true;
		fragment1.GetComponent<Rigidbody>().AddForce(new Vector3(Random.value * -500, Random.value * 1000, Random.value * -500));	
    }
}
