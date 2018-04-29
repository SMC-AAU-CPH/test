using UnityEngine;
using VRTK;

public class Stick : VRTK_InteractableObject
{
    private VRTK_ControllerActions controllerActions;
    private VRTK_ControllerEvents controllerEvents;
    private float impactMagnifier = 240f;
    private float collisionForce = 0f;

	GameObject snare;
	GameObject floor_tom;
	GameObject high_tom;
	GameObject mid_tom;
	GameObject high_hat;
	GameObject crash;
	GameObject crash2;



	GameObject rightStick;
	GameObject leftStick;

	AudioSource snareAudio;
	AudioSource floor_tomAudio;
	AudioSource high_tomAudio;
	AudioSource mid_tomAudio;
	AudioSource high_hatAudio;
	AudioSource crashAudio;
	AudioSource crash2Audio;

	GameObject controllerLeft;
	Transform destinationPos;
	Quaternion destinationRot;



	Vector3 velocity;
	Vector3 previous;

	public float velMag;

	public float velMagVol;

	void Start () {
		snare = GameObject.FindWithTag ("snare");
		floor_tom = GameObject.FindWithTag ("floor_tom");
		high_tom = GameObject.FindWithTag ("high_tom");
        mid_tom = GameObject.FindWithTag ("mid_tom");
        high_hat = GameObject.FindWithTag ("high_hat");
        crash = GameObject.FindWithTag ("crash");
        crash2 = GameObject.FindWithTag ("crash2");


		snareAudio = snare.GetComponent<AudioSource> ();
		floor_tomAudio = floor_tom.GetComponent<AudioSource> ();
		high_tomAudio = high_tom.GetComponent<AudioSource> ();
		mid_tomAudio = mid_tom.GetComponent<AudioSource> ();
		high_hatAudio = high_hat.GetComponent<AudioSource> ();
        crashAudio = crash.GetComponent<AudioSource> ();
        crash2Audio = crash2.GetComponent<AudioSource> ();





		//destinationPos = controllerLeft.GetComponent<Transform> ();


		//destinationPos = controllerLeft.transform.position;
		//destinationRot = controllerLeft.transform.rotation;



		//rightStick = GameObject.FindWithTag ("drumstickRight");
		//leftStick = GameObject.FindWithTag ("drumstickLeft");
	}

    public float CollisionForce()
    {
        return collisionForce;
    }

	/*
	public void TransformToModel() {
		gameObject.transform.position = controllerLeft.transform.position;
		//transform.position = destinationPos;
		//transform.rotation = destinationRot;
	}
	*/

	public void Update () {
		velocity = ((transform.position - previous)) / Time.deltaTime;
		previous = transform.position;

		velMag = velocity.magnitude;
		velMagVol = velMag / 10;
	}

    public override void Grabbed(GameObject grabbingObject)
    {
        base.Grabbed(grabbingObject);
        controllerActions = grabbingObject.GetComponent<VRTK_ControllerActions>();
        controllerEvents = grabbingObject.GetComponent<VRTK_ControllerEvents>();
    }

    protected override void Awake()
    {
        base.Awake();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (controllerActions && controllerEvents && IsGrabbed())
        {
            collisionForce = controllerEvents.GetVelocity().magnitude * impactMagnifier;
            controllerActions.TriggerHapticPulse((ushort)collisionForce, 0.5f, 0.01f);
        }
        else
        {
            collisionForce = collision.relativeVelocity.magnitude * impactMagnifier;
        }

		if (collision.gameObject.tag == "snare") {
			//Debug.Log ("Snare");
			//snareAudio.Play();
			snareAudio.PlayOneShot (snareAudio.clip, velMagVol);
		}
		else if (collision.gameObject.tag == "floor_tom") {
			//floor_tomAudio.Play ();
			floor_tomAudio.PlayOneShot (floor_tomAudio.clip, velMagVol);
		}
		else if (collision.gameObject.tag == "high_tom") {
            //tom1Audio.Play ();
            high_tomAudio.PlayOneShot (high_tomAudio.clip, velMagVol);
		}
		else if (collision.gameObject.tag == "mid_tom") {
            //tom2Audio.Play ();
            mid_tomAudio.PlayOneShot (mid_tomAudio.clip, velMagVol);
		}
		else if (collision.gameObject.tag == "high_hat") {
            //hihatAudio.Play ();
            high_hatAudio.PlayOneShot (high_hatAudio.clip, velMagVol);
		}
		else if (collision.gameObject.tag == "crash") {
            //rideAudio.Play ();
            crashAudio.PlayOneShot (crashAudio.clip, velMagVol);
		}
		else if (collision.gameObject.tag == "crash2") {
            //cymbalAudio.Play ();
            crash2Audio.PlayOneShot (crash2Audio.clip, velMagVol);
		}
    }
}