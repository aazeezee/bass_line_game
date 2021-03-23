using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BassLine : MonoBehaviour {

	// The speed of the Bass Line
	public float speed = 0.2f;
	
	//public Material[] material;
	//Renderer rend;
	
	// The bass line's velocity
	// The magnitude should stay the same; the direction is what changes
	private Vector3 xVeloz = new Vector3 (10, 0, 0);
	private Vector3 zVeloz = new Vector3 (0, 0, 10);
	private Vector3 yVeloz = new Vector3 (0, 10, 0);
	
	// This variable is used for switching back and forth between turning left or right
	// After every turn it gets incremented by one
	// If negative the train will turn left, if positive the train will turn right
	private int alternator = 1;
	
	// Are we alive?
	private bool alive = true;
	// Did we win?
	private bool success = false;
	
	// Are we on the ground?
	private bool grounded = true;
	// Turn gravity on?
	private bool gravity = true;
	
	// Coroutine running?
	private bool isRunning;
	
	// A reference to the results screen
	public GameObject results;
	
	// GameObject of the background music
	public GameObject bgmObject;
	// AudioClip object of the background music
	private AudioClip BGM;
	// Length of the audio in PCM samples due to audio compression
	private long lengthInSamples;
	// Playback position of the audio in PCM samples
	private long currentSamples;
	
	// Label for the percent of the stage completed
	public Text completion;
	// Label for victory
	public Text win;
	// Label for failure
	public Text lose;
	
	// Number of bonuses collected
	private int bonus = 0;
	// Label for the number of bonuses collected
	public Text bonusCollectibles;
	
	// Start() methods are used for initialization
	void Start () {
		if (GetComponent<Rigidbody>().IsSleeping()) {
			GetComponent<Rigidbody>().WakeUp();
		}
		
		results.SetActive(false);
		BGM = bgmObject.GetComponent<AudioSource>().clip;
		lengthInSamples = (long)(BGM.samples);
		StartCoroutine(gravityCoroutine());
	}
	
	// Movement of the train 
	void Update () {
		
		currentSamples = bgmObject.GetComponent<AudioSource>().timeSamples;
		
		// So that the coroutine can keep running
		if (!isRunning) {
			StartCoroutine(gravityCoroutine());
		}
		
		// The turning operation of the train
		if (Input.GetMouseButtonDown(0)){
            transform.Rotate(0, 90 * alternator, 0, Space.World);
			
			alternator = alternator * -1;
        }
		
		// Setting the inital velovity
		if (alternator < 0){
			transform.GetComponent<Rigidbody>().velocity = zVeloz * speed;
        } else if (alternator > 0) {
			transform.GetComponent<Rigidbody>().velocity = xVeloz * speed;
		}
		
		if (!gravity) {
			// We don't need no stinking gravity (on the ground)
			GetComponent<Rigidbody>().useGravity = false;
		} else if (gravity) {
			// Now we need gravity
			GetComponent<Rigidbody>().useGravity = true;
			GetComponent<Rigidbody>().AddForce(new Vector3(0, -100000, 0));
		}
	}
    
    // Coroutine to prevent premature activation of gravity due to OnTriggerStay() not being called every frame
    IEnumerator gravityCoroutine () {
		isRunning = true;
		// While we are on the ground, make sure gravity is false
        while (grounded) {
			gravity = false;
			// Exits execution until next Update
            yield return null;
        }
        
        // Gravity should ALWAYS be on UNLESS we are on the ground
		gravity = true;
		isRunning = false;
    }
	
	
	// Are we alive or nah?
	public bool getStatus() {
		return alive;
		
    }
	
	// Did we win or nah?
	public bool levelComplete() {
		return success;
    }
	
	// Raises the trigger stay event
	void OnTriggerStay(Collider other){
		// When the train is touching the ground
		if (other.gameObject.CompareTag("Ground")) {
			gravity = false;
			grounded = true;
		}
		
		// When the train touches anything other than the ground, a bonus item, or the goal
		// (which means it hit an obstacle) and meets its doom
		if (!other.gameObject.CompareTag("Ground") 
			&& !other.gameObject.CompareTag("Bonus") 
			&& !other.gameObject.CompareTag("Goal")) {
			
			// Tally up progress
			completion.text = "" + (int)((currentSamples * 1.1112 * 100) / lengthInSamples) + "%";
			// Tally up the bonuses
			bonusCollectibles.text = "" + bonus;
			
			// Stops the train
			win.text = "";
			lose.text = "Too Slow!";
			GetComponent<Rigidbody>().isKinematic = true;
			enabled = false;
			alive = false;
		}
	}
	
	// Raises the trigger enter event
	void OnTriggerEnter(Collider other){
		// When a bonus is collected
		if (other.gameObject.CompareTag("Bonus")) {
			bonus++;
		}
		
		// GOAL!
		if (other.gameObject.CompareTag("Goal")) {
			// Tally up progress
			completion.text = "" + (int)((currentSamples * 1.1112 * 100) / lengthInSamples) + "%";
			// Tally up the bonuses
			bonusCollectibles.text = "" + bonus;
			
			win.text = "A WINNER IS YOU!";
			lose.text = "";
			GetComponent<Rigidbody>().isKinematic = true;
			enabled = false;
			success = true;
		}
	}
	
	// Raises the trigger exit event
	void OnTriggerExit(Collider other){
		if (other.gameObject.CompareTag("Ground")) {
			grounded = false;	
		}	
	}	
}
