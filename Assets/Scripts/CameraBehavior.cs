using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraBehavior : MonoBehaviour {
	public GameObject player;
	private Vector3 offset;

	// Start() methods are used for initialization
	void Start () {
		offset = transform.position;
	}
	
	// Update methods are always called once per frame
	void Update () {
		transform.position = player.transform.position + offset;
	}
}