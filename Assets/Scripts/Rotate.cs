using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
	
	// A reference to the train
	public GameObject bassLine;

	// Creates the rotation of the bonus items 
	void FixedUpdate () {
		transform.Rotate(new Vector3 (0, 180, 0)*(Time.deltaTime));
	}
	
	// Raises the trigger enter event
	void OnTriggerEnter(Collider other){
		// When a bonus is collected
		if (other.gameObject == bassLine) {
			this.gameObject.SetActive(false);
		}
	}
	
}