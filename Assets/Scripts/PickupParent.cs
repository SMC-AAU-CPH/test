using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class PickupParent : MonoBehaviour {

	public SteamVR_TrackedObject trackedObj;
	public SteamVR_Controller.Device device;

	void Awake () {
		trackedObj = GetComponent<SteamVR_TrackedObject> ();
	}

	void FixedUpdate () {
		device = SteamVR_Controller.Input ((int)trackedObj.index);
		if (device.GetTouch (SteamVR_Controller.ButtonMask.Trigger)) {
			//Debug.Log ("Holding 'Touch' trigger");
			//device.TriggerHapticPulse (3000);
		}
	}
	void OnTriggerStay(Collider col) {
		//Debug.Log ("You have collided with " + col.name + " and activated OnTriggerStay");
		if (device.GetPressDown (SteamVR_Controller.ButtonMask.Trigger)) {
			//Debug.Log ("You have collided with " + col.name + " while holding down Touch");
			col.attachedRigidbody.isKinematic = true;
			col.gameObject.transform.SetParent (gameObject.transform);
			//device.TriggerHapticPulse (100);

		}
		if (device.GetPressUp (SteamVR_Controller.ButtonMask.Trigger)) {
			//Debug.Log ("You have released Touch while colliding with " + col.name);
			col.gameObject.transform.SetParent (null);
			col.attachedRigidbody.isKinematic = false;
		}

			
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "drumkit") {
			device.TriggerHapticPulse (500);
			//Debug.Log ("HALLO");
		}
	}

}
