using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using VRTK;

public class Maracas : MonoBehaviour {

	private VRTK_ControllerActions controllerActions;

	public Vector3 previous;
	public Vector3 velocity;
	public float velMag;
	public float velMagVol;

	public AudioSource audio;

	//DrumShake marashake;

	void Start () {
		audio = GetComponent<AudioSource>();

		//marashake = gameObject.GetComponent<DrumShake> ();

	}

	void Update () {
		velocity = ((transform.position - previous)) / Time.deltaTime;
		previous = transform.position;

		velMag = velocity.magnitude;

		velMagVol = velMag / 100;

		if (velMag > 2.0f && transform.parent != null && !audio.isPlaying) {
			audio.volume = velMagVol;
			audio.Play ();
			//controllerActions.TriggerHapticPulse((ushort)420.0f, 0.5f, 0.01f);
			//marashake.Shake ();
		}
	}
}
