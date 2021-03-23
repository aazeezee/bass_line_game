using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/** 
* This class is for fading out the background music
**/
public class FadeOut : MonoBehaviour {
	
	// A reference to the Bass Line
	public GameObject bassLine;
	
	// A reference to the results screen
	public GameObject results;
	
	// A reference to the bass line's script
	private BassLine bassLineScript;
	
	// Fade the BGM or nah?
	private bool fade;
	
	// Use this for initialization
	void Start () {
		bassLineScript = bassLine.GetComponent<BassLine>();
	}
	
	void Update (){
		Fade();
		// Decrements volume
		if (fade && GetComponent<AudioSource>().volume > 0) {
			GetComponent<AudioSource>().volume = GetComponent<AudioSource>().volume - 0.003f;
		} else if (GetComponent<AudioSource>().volume <= 0) {
			GetComponent<AudioSource>().Stop();
		}
		
		if (GetComponent<AudioSource>().volume <= 0.75f) {
			results.SetActive(true);
		}
	}
	
	void Fade(){
		// YOUR LOVE IS FADE Fade fade....
		if (bassLineScript.getStatus() == false || bassLineScript.levelComplete() == true) {
			fade = true;	
		}
	}
}
