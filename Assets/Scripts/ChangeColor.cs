using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour {
	
	public Material antiguo;
	public Material nuevo;
	Renderer rend;
	
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		rend.enabled = true;
		rend.sharedMaterial = antiguo;
	}
	
	// Movement of the bass line 
	void Update () {
		int alt = 1;
		
		// Changing colors
		if (Input.GetKeyDown("space")){
			alt = alt * -1;
		}
		
		if (alt < 0){
			rend.sharedMaterial = nuevo;
		} else if (alt > 0){
			rend.sharedMaterial = antiguo;
		}
	}
}
