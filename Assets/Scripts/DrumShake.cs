using UnityEngine;
using System.Collections;

public class DrumShake : MonoBehaviour {


	public Vector3 previous;
	public Vector3 velocity;
	//public float volumeControl;
	//public AudioSource audio;

	GameObject childShake;
	bool childaudioIsPlaying;

	//private Vector3 originPosition;
	private Quaternion originRotation;
	public float shake_decay = 0.002f;
	public float shake_intensity = .05f;

	private float temp_shake_intensity = 0;

	Vector3 startPos;
	Quaternion startRot;
	float rotationResetSpeed = 1.0f;


	void Start() {
		//audio = GetComponent<AudioSource>();
		startPos = transform.position;
		startRot = transform.rotation;


		childaudioIsPlaying = GetComponentInChildren<AudioSource> ().isPlaying;
		//childaudioIsPlaying = childShake.isPlaying();

			

	}

	public void Shake(){
		//originPosition = transform.position;	
		originRotation = transform.rotation;
		temp_shake_intensity = shake_intensity;

	}


	//void OnGUI () {
	//	if (GUI.Button (new Rect (20,40,80,20), "Shake")){
	//		Shake ();
	//	}
	//}

	void Update () {
		//velocity = ((transform.position - previous)) / Time.deltaTime;
		//previous = transform.position;

		//volumeControl = velocity.magnitude / 10;

		//audio.volume = volumeControl;




	}



	void FixedUpdate (){



		if (temp_shake_intensity > 0) {
			//transform.position = originPosition + Random.insideUnitSphere * temp_shake_intensity;
			transform.rotation = new Quaternion (
				originRotation.x + Random.Range (-temp_shake_intensity, temp_shake_intensity) * .2f,
				originRotation.y + Random.Range (-temp_shake_intensity, temp_shake_intensity) * .2f,
				originRotation.z + Random.Range (-temp_shake_intensity, temp_shake_intensity) * .2f,
				originRotation.w + Random.Range (-temp_shake_intensity, temp_shake_intensity) * .2f);
			temp_shake_intensity -= shake_decay;

		} else {
			transform.rotation = Quaternion.Slerp (transform.rotation, startRot, 1.0f);
			transform.position = startPos;
		}
		//Debug.Log (temp_shake_intensity);

		if(childaudioIsPlaying == true) {
			Shake ();
		}

	}
		


	/*
	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "drumstick") {
			Shake ();
			audio.Play ();
			//Debug.Log ("HALLO");

		}
	}
	*/
}