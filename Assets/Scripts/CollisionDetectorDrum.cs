using UnityEngine;
using System.Collections;
using VRTK;

public class CollisionDetectorDrum : MonoBehaviour {
	
	private VRTK_ControllerActions controllerActions;

	public AudioSource audio;

	public GameObject grabbingObject;

	//public AudioClip clip;

	public float impactVol;

	GameObject haptic;
	PickupParent pickuparent;

	public GameObject velocityCalculatorDrumRight;
	public VelocityCalculatorDrumRight velocitycalculatordrumright;

	public GameObject velocityCalculatorDrumLeft;
	public VelocityCalculatorDrumLeft velocitycalculatordrumleft;

	public float impactRight;
	public float impactLeft;

	public float impactRightVol;
	public float impactLeftVol;


	private Quaternion originRotation;
	public float shake_decay = 0.002f;
	public float shake_intensity = .05f;

	private float temp_shake_intensity = 0;

	Vector3 startPos;
	Quaternion startRot;
	float rotationResetSpeed = 1.0f;

	DrumShake drumshake;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
	

		//controllerActions = grabbingObject.GetComponent<VRTK_ControllerActions>();

		velocityCalculatorDrumRight= GameObject.FindWithTag ("drumstickRight");
		velocitycalculatordrumright = velocityCalculatorDrumRight.GetComponent<VelocityCalculatorDrumRight> ();

		velocityCalculatorDrumLeft= GameObject.FindWithTag ("drumstickLeft");
		velocitycalculatordrumleft = velocityCalculatorDrumLeft.GetComponent<VelocityCalculatorDrumLeft> ();

	
		drumshake = gameObject.GetComponentInParent<DrumShake> ();

		//haptic = GameObject.FindWithTag ("ControllerRight");
		//pickuparent = haptic.GetComponent<PickupParent> ();

	}
	
	// Update is called once per frame
	void Update () {
		impactRight = velocitycalculatordrumright.velMagRight;
		impactLeft = velocitycalculatordrumleft.velMagLeft;

		impactRightVol = impactRight / 10;
		impactLeftVol = impactLeft / 10;
		impactVol = (impactRightVol + impactLeftVol) / 2;

		audio.volume = impactVol;

		//Debug.Log ("Vol: " + impactRightVol);
	}
		
	/*
	void FixedUpdate () {
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
	}

	
	public void Shake(){
		//originPosition = transform.position;	
		originRotation = transform.parent.rotation;
		temp_shake_intensity = shake_intensity;

	}
	*/

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "drumstickLeft" && impactLeft > 1.0f) {
			//audio.volume = impactLeftVol;
			//audio.Play ();
			//audio.PlayOneShot(audio.clip, impactLeftVol);

			controllerActions.TriggerHapticPulse((ushort)420.0f, 0.5f, 0.01f);
			drumshake.Shake();

		}

		if (col.gameObject.tag == "drumstickRight" && impactRight > 1.0f) {
			//audio.volume = impactRightVol;
			//audio.Play ();
			//audio.PlayOneShot(audio.clip, impactRightVol);

			controllerActions.TriggerHapticPulse((ushort)420.0f, 0.5f, 0.01f);
			drumshake.Shake();

		}

	}
}
