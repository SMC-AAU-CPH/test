using UnityEngine;
using System.Collections;

public class DrumCollision : MonoBehaviour {
	AudioSource drumSound;

	// Use this for initialization
	void Start () {
		drumSound = GetComponent<AudioSource>();
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "drumstick") {
			drumSound.Play ();
		}
			
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
