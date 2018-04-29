using UnityEngine;
using System.Collections;
using VRTK;

public class CollisionDetectorXylo : MonoBehaviour {

	private VRTK_ControllerActions controllerActions;

	public AudioSource audio;

	GameObject velocityCalculatorXyloRight;
	VelocityCalculatorXyloRight velocitycalculatorxyloright;

	GameObject velocityCalculatorXyloLeft;
	VelocityCalculatorXyloLeft velocitycalculatorxyloleft;

	public float impactRight;
	public float impactLeft;

	public float impactRightVol;
	public float impactLeftVol;

	DrumShake xyloshake;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();

		velocityCalculatorXyloRight = GameObject.FindWithTag ("xylostickRight");
		velocitycalculatorxyloright = velocityCalculatorXyloRight.GetComponent<VelocityCalculatorXyloRight> ();

		velocityCalculatorXyloLeft = GameObject.FindWithTag ("xylostickLeft");
		velocitycalculatorxyloleft = velocityCalculatorXyloLeft.GetComponent<VelocityCalculatorXyloLeft> ();


		xyloshake = gameObject.GetComponentInParent<DrumShake> ();
	}

	// Update is called once per frame
	void Update () {
		impactRight = velocitycalculatorxyloright.velMagRight;

		impactLeft = velocitycalculatorxyloleft.velMagLeft;

		impactRightVol = impactRight / 100;
		impactLeftVol = impactLeft / 100;
	}

	void OnTriggerEnter(Collider col) {

		/*
		if (col.gameObject.tag == "xylostickRight" && impactRight > 1.0f || col.gameObject.tag == "xylostickLeft" && impactLeft > 1.0f) {	
			audio.Play ();
		}
		*/
		if (col.gameObject.tag == "xylostickRight" && impactRight > 1.0f) {
			audio.volume = impactRightVol;
			audio.Play ();
			controllerActions.TriggerHapticPulse((ushort)120.0f, 0.5f, 0.01f);
			xyloshake.Shake();
		}
		if (col.gameObject.tag == "xylostickLeft" && impactLeft > 1.0f) {
			audio.volume = impactLeftVol;
			audio.Play ();
			controllerActions.TriggerHapticPulse((ushort)120.0f, 0.5f, 0.01f);
			xyloshake.Shake();
		}
	}
}